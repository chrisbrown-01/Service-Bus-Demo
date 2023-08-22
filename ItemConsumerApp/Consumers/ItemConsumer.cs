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

    public class ItemConsumer :
        IConsumer<Item>
    {
        private readonly IItemService _itemService;

        public ItemConsumer(IItemService itemService)
        {
            _itemService = itemService;
        }

        public Task Consume(ConsumeContext<Item> context) // TODO: change to ItemCreatedEvent, see if queues are created accordingly
        {
            Console.WriteLine($"Item Consumer App: Consumed item with Id {context.Message.Id.ToString()}.");
            Console.WriteLine();

            //var item = new Item();
            //_itemService.DisplayItem(item);
            //Console.WriteLine("Adjusted price: " + _itemService.CalculateItemAdjustedPrice(item));
            //Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}