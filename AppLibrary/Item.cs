using Bogus;

namespace AppLibrary
{
    public record Item(Guid Id, string ItemName, string ItemDescription, int Price, DateTime CreationDateTime)
    {
        public Item() : this(
            Guid.NewGuid(),
            new Faker().Internet.DomainName(),
            new Faker().Internet.Email(),
            new Random().Next(1, 100), DateTime.Now)
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}\nItemName: {ItemName}\nItemDescription: {ItemDescription}\nPrice: {Price}\nCreationDateTime: {CreationDateTime}";
        }
    }
}