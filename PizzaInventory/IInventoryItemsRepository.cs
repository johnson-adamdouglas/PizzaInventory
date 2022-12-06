using System;
using System.Data;
using PizzaInventory.Models;

namespace PizzaInventory
{
    public interface IInventoryItemsRepository
    {
        // Must use PizzaInventory.Models directive to access IEnumerable<InventoryItems>
        public IEnumerable<InventoryItems> GetAllInventoryItems();

        public InventoryItems GetInventoryItem(int id);//Stubbed out method to be implemented in the repository

        public void BulkCountInventory(IEnumerable<InventoryItems> inventoryItems);

        public double GetCountUnitPerOrderUnit(int id);

        //public void FoodOrder(IEnumerable<InventoryItems> inventoryItems);
    }


}
