using AppLibrary;

namespace ItemConsumerApp.Services
{
    public interface IItemService
    {
        int CalculateItemAdjustedPrice(Item item);
        void DisplayItem(Item item);
    }
}