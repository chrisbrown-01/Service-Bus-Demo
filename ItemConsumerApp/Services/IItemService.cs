using AppLibrary;

namespace ItemConsumerApp.Services
{
    public interface IItemService
    {
        int CalculateItemAdjustedPrice(ItemCreated item);

        void DisplayItem(ItemCreated item);
    }
}