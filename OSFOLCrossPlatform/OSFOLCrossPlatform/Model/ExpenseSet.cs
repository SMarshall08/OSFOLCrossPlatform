using System;
using SQLite;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Model
{
    public class ExpenseSet
    {
        public ExpenseSet() { }

        [PrimaryKey,Unique]
        public int ExpenseSetID { get; set; }
        public string ExpenseSetName { get; set; }
        public Image ExpenseImage { get; set; }
        public DateTime FromDT { get; set; }
        public DateTime ToDT { get; set; }
    }
    public class Customers
    {
        public Customers() { }

        [PrimaryKey, Unique]
        public int CustomerID { get; set; }
        public int rfBusinessOwnerID { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public int IsRetired { get; set; }
        public string TelephoneNum { get; set; }
        public string Website { get; set; }
        public DateTimeOffset ModifiedDT { get; set; }
        public int LoginID { get; set; }
        public int RevisionNo { get; set; }        
    }

    public class SalesOpportunity
    {
        public SalesOpportunity() { }

        [PrimaryKey,Unique]
        public int SalesOpportunityID { get; set; }
        public int rfBusinessOwnerID { get; set; }
        public int PersonnelOwnerID { get; set; }
        public int CustomerID { get; set; }
        public string Opportunity { get; set; }
        public string BusinessOwnercurrency { get; set; }
        public DateTime ModifiedDT { get; set; }

    }

    public class ExpenseType
    {
        public ExpenseType() { }

        [PrimaryKey, Unique]
        public int rfExpenseTypeID { get; set; }
        public string rfExpenseType { get; set; }
        public string Description { get; set; }
    }

    public class ExpenseMethod
    {
        public ExpenseMethod() { }

        [PrimaryKey, Unique]
        public int rfExpenseMethodID { get; set; }
        public string rfExpenseMetod { get; set; }
    }

    public class rfVendor
    {
        public rfVendor() { }

        [PrimaryKey,Unique]
        public int VendorID { get; set; }
        public string Vendor { get; set; }
    }
}
