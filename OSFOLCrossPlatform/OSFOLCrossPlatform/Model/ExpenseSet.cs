using System;
using SQLite;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Model
{
    public class ExpenseSet
    {
        /// <summary>
        /// A set of expenses? Corresponds to a SQLite table of the same name
        /// </summary>
        public ExpenseSet() { }


        [PrimaryKey, AutoIncrement, Unique]
        public int ExpenseSetID         { get; set; }
        public string ExpenseSetName    { get; set; }
        public int LoginID              { get; set; }
        public DateTime FromDT          { get; set; }
        public DateTime ToDT            { get; set; }
        public DateTime CreatedDT       { get; set; }

    }

    /// <summary>
    /// Summary details of an expense incurred. Maps to a view in the database to expose the string names of records joined by ID
    /// Used for the View Expense Form
    /// </summary>
    public class ExpenseSummary 
    {
        public ExpenseSummary() { }

        public int ExpenseID            { get; set; }
        public int LoginID              { get; set; }
        public DateTime CreatedDT       { get; set; }
        public string Customer          { get; set; }
        public string Contact           { get; set; }
        public string Opportunity       { get; set; }
        public string LocationFrom      { get; set; }
        public string LocationTo        { get; set; }
        public string rfExpenseType     { get; set; }
        public string rfExpenseMethod   { get; set; }
        public string ExpenseDetails    { get; set; }
        public string Vendor            { get; set; }
        public string rfCurrency        { get; set; }
        public decimal ExchangeRate     { get; set; }
        public decimal ExpenseAmountCur { get; set; }
        public decimal ExpenseAmount    { get; set; }
        public string ReceiptImageUri   { get; set; }
        public string ExpenseSetName    { get; set; }
    }

    /// <summary>
    /// Customer details to whom expenses may relate
    /// </summary>
    public class Customers
    {
        public Customers() { }

        [PrimaryKey, AutoIncrement, Unique]
        public int CustomerID               { get; set; }
        public int rfBusinessOwnerID        { get; set; }
        public string Customer              { get; set; }
        public string Location              { get; set; }
        public string Country               { get; set; }
        public int IsRetired                { get; set; }
        public string TelephoneNum          { get; set; }
        public string Website               { get; set; }
        public DateTimeOffset ModifiedDT    { get; set; }
        public int LoginID                  { get; set; }
        public int RevisionNo               { get; set; }        
    }

    /// <summary>
    /// Sales opportunity against which the expense may be booked
    /// </summary>
    public class SalesOpportunity
    {
        public SalesOpportunity() { }

        [PrimaryKey,AutoIncrement, Unique]
        public int SalesOpportunityID       { get; set; }
        public int rfBusinessOwnerID        { get; set; }
        public int PersonnelOwnerID         { get; set; }
        public int CustomerID               { get; set; }
        public string Opportunity           { get; set; }
        public string BusinessOwnercurrency { get; set; }
        public DateTime ModifiedDT          { get; set; }

    }

    /// <summary>
    /// Type of expense
    /// </summary>
    public class ExpenseType
    {
        public ExpenseType() { }

        [PrimaryKey, Unique]
        public int rfExpenseTypeID  { get; set; }
        public string rfExpenseType { get; set; }
        public string Description   { get; set; }
    }

    /// <summary>
    /// How the expense was incurred
    /// </summary>
    public class ExpenseMethod
    {
        public ExpenseMethod() { }

        [PrimaryKey, Unique]
        public int rfExpenseMethodID  { get; set; }
        public string rfExpenseMethod { get; set; }
    }

    /// <summary>
    /// Who the expense was paid to
    /// </summary>
    public class rfVendor
    {
        public rfVendor() { }

        [PrimaryKey, AutoIncrement, Unique]
        public int VendorID  { get; set; }
        public string Vendor { get; set; }
    }

    /// <summary>
    /// Customer contact who may have been involved with the expense
    /// </summary>
    public class Contact
    {
        public Contact() { }

        [PrimaryKey, AutoIncrement, Unique]
        public int ContactID        { get; set; }
        public int CustomerID       { get; set; }
        public string Title         { get; set; }
        public string FirstName     { get; set; }
        public string LastName      { get; set; }
        public string Email         { get; set; }
        public string Telephone     { get; set; }
        public string MobilePhone   { get; set; }
        public string JobTitle      { get; set; }
        public string Department    { get; set; }
        public int IsRetired       { get; set; }
        public DateTime CreatedDT   { get; set; }
        public DateTime ModifiedDT  { get; set; }
    }

    /// <summary>
    /// The currency in which the expense was incurred
    /// </summary>
    public class Currency
    {
        public Currency() { }

        [PrimaryKey,Unique]
        public int rfCurrencyID     { get; set; }
        public string rfCurrency    { get; set; }
        public string Description   { get; set; }
    }

    public class ExpenseMonth
    {
        public ExpenseMonth() { }

        public string Month { get; set; }
        public string Year  { get; set; }
        public int MonthID  { get; set; }
    }

   
}
