using AppLibrary;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ItemGeneratorApp
{
    public class ItemGeneratorWorker : BackgroundService
    {
        readonly IBus _bus;

        public ItemGeneratorWorker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var item = new Item();
                Console.WriteLine($"Item Generator App: Published item with Id {item.Id.ToString()}.");
                await _bus.Publish(item, stoppingToken); // Queue of name "item" is auto-created in RabbitMQ

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}