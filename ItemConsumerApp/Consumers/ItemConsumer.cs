using AppLibrary;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Consumers
{
    // TODO: add ConsumerDefinition class. old one was being marked as obsolete

    public class ItemConsumer :
        IConsumer<Item>
    {
        public Task Consume(ConsumeContext<Item> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed item with Id {context.Message.Id.ToString()}.");
            return Task.CompletedTask;
        }
    }
}