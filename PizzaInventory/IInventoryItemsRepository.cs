using System;
using PizzaInventory.Models;

namespace PizzaInventory
{
    public interface IInventoryItemsRepository
    {
        // Must use PizzaInventory.Models directive to access IEnumerable<InventoryItems>
        public IEnumerable<InventoryItems> GetAllInventoryItems();

        public InventoryItems GetInventoryItem(int id);//Stubbed out method to be implemented in the repository

        public void CountInventory(InventoryItems inventoryItem);
    }


}
