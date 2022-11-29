using System.Transactions;

namespace PizzaInventory.Models
{
    public class InventoryItems
    // This is the InventoryItems Model. This contains all application business logic, validation logic,
    // and database access logic that pertains to InventoryItems.
    {
        #region properties 
        //class properties corresponding to InventoryItems column names:
        public int InventoryID { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int Inventory_TypeID { get; set; }
        public string CountUnit { get; set; }
        public string OrderUnit { get; set; }
        public int CountUnitPerOrderUnit { get; set; }
        public int AmtOnHand { get; set; }
        public int StartingAmt { get; set; }
        public int QuantityDelivered { get; set; }
        public int BeginningAmt { get; set; }
        public int EndingAmt { get; set; }
        public int AmtUsed { get; set; }
        #endregion
    }
}
