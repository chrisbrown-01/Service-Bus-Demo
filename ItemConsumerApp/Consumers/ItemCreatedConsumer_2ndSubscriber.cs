using AppLibrary;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Consumers
{
    public class ItemCreatedConsumer_2ndSubscriber : IConsumer<ItemCreated>
    {
        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed item with Id {context.Message.Id.ToString()} (2nd subscriber).");
            return Task.CompletedTask;
        }
    }
}