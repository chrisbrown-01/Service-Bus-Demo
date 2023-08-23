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

        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.WriteLine($"Item Consumer App: Consumed item with Id {context.Message.Id.ToString()}.");
            //Console.WriteLine();

            //var itemCreated = context.Message;
            //_itemService.DisplayItem(itemCreated);
            //Console.WriteLine("Adjusted price: " + _itemService.CalculateItemAdjustedPrice(itemCreated));
            //Console.WriteLine();

            return Task.CompletedTask;
        }

        /*
        class SubmitOrderConsumer :
            IConsumer<SubmitOrder>
        {
            public async Task Consume(ConsumeContext<SubmitOrder> context)
            {
                await context.Publish<OrderSubmitted>(new
                {
                    context.Message.OrderId
                });
            }
        }
        */
    }
}