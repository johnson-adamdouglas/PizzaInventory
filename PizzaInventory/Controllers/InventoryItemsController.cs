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

        public IActionResult BulkUpdateInventoryItems(IEnumerable<InventoryItems> inventoryItems)
        {
            repo.BulkCountInventory(inventoryItems);

            return RedirectToAction("CountInventory");
        }

        //public IActionResult FoodOrder(IEnumerable<InventoryItems> inventoryItems)
        //{
        //    repo.FoodOrder(inventoryItems);
        //    return View(inventoryItems);
        //}
    }
}
