using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}
