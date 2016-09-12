using System;
using SQLite;

namespace OSFOLCrossPlatform.Model
{
    public class Customers
    {
        public Customers() { }

        [PrimaryKey, AutoIncrement]
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

    public class Opportunity
    {
        public int ID { get; set; }
        public string SalesOpportunity { get; set; }
        public Opportunity() { }
    }
}
