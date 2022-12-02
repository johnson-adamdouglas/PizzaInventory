using System.Data;
using Dapper;
using PizzaInventory.Models;

namespace PizzaInventory
{
    public class InventoryItemsRepository : IInventoryItemsRepository
    {
        // IDbConnection is an interface that enables the InventoryItemsRepsository class to implement a Connection
        // class which enables the SQL server connection
        private readonly IDbConnection _conn;

        public InventoryItemsRepository(IDbConnection conn)
        {
            // This constructor accepts an IDbConnection as an argument and stores that argument in _conn
            _conn = conn;
        }

        public void CountInventory(InventoryItems inventoryItem)
        {
            _conn.Execute("UPDATE INVENTORY_ITEMS SET AMTONHAND = @amtOnHand WHERE INVENTORYID = @id;", 
                new { amtOnHand = inventoryItem.AmtOnHand, id = inventoryItem.InventoryID });
        }

        public IEnumerable<InventoryItems> GetAllInventoryItems()
        {
            // This is the implementation of the method in our irepository interface
            // This method utilizes Dapper to query our Pizza Inventory database and returns
            // a collection of InventoryItems - IEnumerable<InventoryItems>
            // Dapper is an object-relational mappping (ORM) product that allows us to use SQL language
            // in our C# code to query the database.
            return _conn.Query<InventoryItems>
                ("SELECT * FROM INVENTORY_ITEMS");
        }

        public InventoryItems GetInventoryItem(int id)
        {
            // This is the implementation of the method in our irepository interface
            // This QuerySingle Dapper method returns a single row
            return _conn.QuerySingle<InventoryItems>
                ("SELECT * FROM INVENTORY_ITEMS WHERE INVENTORYID = @id", new { id = id });
        }
    }
}
