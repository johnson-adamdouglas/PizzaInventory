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
        public double CountUnitQuantity { get; set; }
        public string OrderUnit { get; set; }
        public double OrderUnitQuantity { get; set; }
        public double CountUnitPerOrderUnit { get; set; }
        public double AmtOnHand { get; set; }
        public double StartingAmt { get; set; }
        public double QuantityDelivered { get; set; }
        public double BeginningAmt { get; set; }
        public double EndingAmt { get; set; }
        public double AmtUsed { get; set; }
        public int Order { get; set; }
        public int SuggestedOrder { get; set; }
        public double Yield { get; set; }
        
        public double margin { get; set; }

        #endregion

    }
}
