using System;
using PizzaInventory.Models;

namespace PizzaInventory
{
    public interface IInventoryItemsRepository
    {
        // Must use PizzaInventory.Models directive to access IEnumerable<InventoryItems>
        public IEnumerable<InventoryItems> GetAllInventoryItems();
    }
}
