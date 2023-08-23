using AppLibrary;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Consumers
{
    public class ItemProcessedConsumer : IConsumer<ItemProcessed>
    {
        public Task Consume(ConsumeContext<ItemProcessed> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed ItemProcessed with Id {context.Message.Id.ToString()}.");
            return Task.CompletedTask;
        }
    }
}