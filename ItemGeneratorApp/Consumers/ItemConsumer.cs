namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;

    //using ItemGenerator.Contracts;
    using System;
    using AppLibrary;

    // TODO: add ConsumerDefinition class. old one was being marked as obsolete

    public class ItemConsumer :
        IConsumer<Item>
    {
        public Task Consume(ConsumeContext<Item> context)
        {
            Console.WriteLine($"Consumed item with Id {context.Message.Id.ToString()}.");
            return Task.CompletedTask;
        }
    }
}