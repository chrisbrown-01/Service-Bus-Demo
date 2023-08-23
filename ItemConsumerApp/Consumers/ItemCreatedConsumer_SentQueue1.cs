using AppLibrary;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Consumers
{
    public class ItemCreatedConsumer_SentQueue1 : IConsumer<ItemCreated>
    {
        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed queue1-sent item with Id {context.Message.Id.ToString()}.");
            return Task.CompletedTask;
        }
    }
}