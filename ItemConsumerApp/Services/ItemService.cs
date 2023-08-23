using AppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemConsumerApp.Services
{
    public class ItemService : IItemService
    {
        public int CalculateItemAdjustedPrice(ItemCreated item)
        {
            return item.Price * 10;
        }

        public void DisplayItem(ItemCreated item)
        {
            Console.WriteLine("Displaying item:");
            Console.WriteLine(item.ToString());
        }
    }
}