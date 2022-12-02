using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaInventory.Models;

namespace PizzaInventory.Controllers
{
    public class InventoryItemsController : Controller
    {

        private readonly IInventoryItemsRepository repo;

        public InventoryItemsController(IInventoryItemsRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var inventoryItems = repo.GetAllInventoryItems();
            return View(inventoryItems);
        }

        public IActionResult ViewInventoryItem(int id)
        {
            var inventoryItem = repo.GetInventoryItem(id);
            return View(inventoryItem);
        }

        public IActionResult CountInventory()
        {
            var inventoryItems = repo.GetAllInventoryItems();
            return View(inventoryItems);
        }

        public IActionResult UpdateInventoryItemToDatabase(InventoryItems inventoryItem)
        {
            repo.CountInventory(inventoryItem);

            return RedirectToAction("Index");
        }

        //public IActionResult BulkUpdateInventoryItems(IEnumerable<InventoryItems> inventoryItems)
        //{

        //}
    }
}
