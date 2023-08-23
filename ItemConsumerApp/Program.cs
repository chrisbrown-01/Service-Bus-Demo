using ItemConsumerApp.Consumers;
using ItemConsumerApp.Services;
using MassTransit;
using System.Reflection;

namespace ItemConsumerApp
{
    public class Program
    {
        private const string SEND_QUEUE1 = "Queue1";

        [Obsolete]
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
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

                            // --- Not necessary, ConfigureEndpoints auto-creates a queue of different name. ---
                            //cfg.ReceiveEndpoint(SEND_QUEUE1, e =>
                            //{
                            //    e.ConfigureConsumer<ItemCreatedConsumer_SentQueue1>(context);
                            //});

                            cfg.UseMessageRetry(r => r.Interval(3, 1));

                            cfg.UseInMemoryOutbox();
                        });
                    });

                    services.AddScoped<IItemService, ItemService>();
                })
                .Build();

            host.Run();
        }
    }
}