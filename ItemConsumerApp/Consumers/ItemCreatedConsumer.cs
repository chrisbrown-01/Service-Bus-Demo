using AppLibrary;
using ItemConsumerApp.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Consumers
{
    // TODO: add ConsumerDefinition class. old one was being marked as obsolete

    public class ItemCreatedConsumer : IConsumer<ItemCreated>
    {
        private readonly IItemService _itemService;

        public ItemCreatedConsumer(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed item with Id {context.Message.Id.ToString()}.");
            //Console.WriteLine();

            //var itemCreated = context.Message;
            //_itemService.DisplayItem(itemCreated);
            //Console.WriteLine("Adjusted price: " + _itemService.CalculateItemAdjustedPrice(itemCreated));
            //Console.WriteLine();

            await Task.Delay(500);
            Console.WriteLine($"Publishing ItemProcessed event for item Id {context.Message.Id.ToString()}.");
            await context.Publish(new ItemProcessed(context.Message.Id));
        }
    }
}