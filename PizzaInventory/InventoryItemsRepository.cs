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

        public void BulkCountInventory(IEnumerable<InventoryItems> inventoryItem)
        {
            foreach (var item in inventoryItem)
            {
                item.AmtOnHand = item.OrderUnitQuantity * GetCountUnitPerOrderUnit(item.InventoryID) + item.CountUnitQuantity;
                _conn.Execute("UPDATE INVENTORY_ITEMS SET AMTONHAND = @amtOnHand WHERE INVENTORYID = @id;",
                    new { amtOnHand = item.AmtOnHand, id = item.InventoryID });
            }
        }

        public void FoodOrder(IEnumerable<InventoryItems> inventoryItems)
        {
            Random rnd = new Random();
            int orderID = rnd.Next(1000, 9999);
            _conn.Execute("CREATE TABLE orderID = @orderID (" +
                "InventoryID int NOT NULL," +
                "Name string," +
                "AmtOnHand double," +
                "Margin double," +
                "SuggestedOrder int," +
                "Order int," +
                "FOREIGN KEY (InventoryID) REFERENCES INVENTORY_ITEMS (InventoryID)");
            //foreach (var item in inventoryItems)
            //{
            //    _conn.Execute
            //}
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

        public double GetCountUnitPerOrderUnit(int id)
        {
            return _conn.QuerySingle<double>
                ("SELECT COUNTUNITPERORDERUNIT FROM INVENTORY_ITEMS WHERE INVENTORYID = @id", new {id = id });
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
