using ItemConsumerApp.Services;
using MassTransit;
using System.Reflection;

namespace ItemConsumerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        // By default, sagas are in-memory, but should be changed to a durable
                        // saga repository.
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
                        });
                    });

                    //services.AddScoped<IItemService, ItemService>();
                    services.AddScoped<ItemService>(); // TODO: delete
                })
                .Build();

            host.Run();
        }
    }
}