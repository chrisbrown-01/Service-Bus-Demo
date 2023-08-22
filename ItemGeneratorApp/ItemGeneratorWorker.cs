using AppLibrary;

//using ItemGenerator.Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemGenerator
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
                Console.WriteLine($"Item with Id {item.Id.ToString()} published.");
                await _bus.Publish(item, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}