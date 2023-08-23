using AppLibrary;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ItemGeneratorApp
{
    // docker run -d -p 15672:15672 -p 5672:5672 masstransit/rabbitmq
    public class ItemGeneratorWorker : BackgroundService
    {
        private readonly Uri SEND_QUEUE1_URI = new Uri("rabbitmq://localhost/Queue1");
        readonly IBus _bus;

        public ItemGeneratorWorker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var itemCreated = new ItemCreated();
                Console.WriteLine($"Item Generator App: Published item with Id {itemCreated.Id.ToString()}.");
                await _bus.Publish(itemCreated, stoppingToken);

                // --- Below code is not necessary but allows you to manually specify queue names and send directly ---
                //var endPoint = await _bus.GetSendEndpoint(SEND_QUEUE1_URI);
                //var sendItemCreated = new ItemCreated();
                //Console.WriteLine($"Item Generator App: Sent item with Id {sendItemCreated.Id.ToString()}.");
                //await endPoint.Send(sendItemCreated, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}