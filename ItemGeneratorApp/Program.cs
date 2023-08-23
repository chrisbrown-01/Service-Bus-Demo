using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace ItemGeneratorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        // By default, sagas are in-memory, but should be changed to a durable saga repository.
                        x.SetInMemorySagaRepositoryProvider();

                        var entryAssembly = Assembly.GetEntryAssembly();

                        x.AddConsumers(entryAssembly);
                        x.AddSagaStateMachines(entryAssembly);
                        x.AddSagas(entryAssembly);
                        x.AddActivities(entryAssembly);

                        //x.UsingInMemory((context, cfg) =>
                        //{
                        //    cfg.ConfigureEndpoints(context);
                        //});

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });

                            cfg.ConfigureEndpoints(context);

                            cfg.UseMessageRetry(r => r.Interval(3, 1));

                            cfg.UseInMemoryOutbox();
                        });

                        // TODO: add outbox, redelivery
                    });

                    services.AddHostedService<ItemGeneratorWorker>();
                });
    }
}