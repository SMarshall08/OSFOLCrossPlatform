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

        /// <summary>
        /// Gets or sets the expense set identifier.
        /// </summary>
        /// <value>
        /// The expense set identifier Unique primiary key).
        /// </value>
        [PrimaryKey, Unique]
        public int ExpenseSetID { get; set; }

        /// <summary>
        /// Gets or sets the name of the expense set.
        /// </summary>
        /// <value>
        /// The name of the expense set.
        /// </value>
        public string ExpenseSetName { get; set; }

        /// <summary>
        /// Gets or sets the expense image - an image corroborating the expenses (such as a ttendees, or receipt photo?)
        /// </summary>
        /// <value>
        /// The expense image.
        /// </value>
        public Image ExpenseImage { get; set; }

        /// <summary>
        /// Gets or sets the date the expense ran from
        /// </summary>
        /// <value>
        /// From dt.
        /// </value>
        public DateTime FromDT { get; set; }

        /// <summary>
        /// Gets or sets the date the expense ran to
        /// </summary>
        /// <value>
        /// To dt.
        /// </value>
        public DateTime ToDT { get; set; }
    }

    /// <summary>
    /// Summary details of an expense incurred. Maps to a view in the database to expose the string names of records joined by ID
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
        public string Currency          { get; set; }
        public decimal ExchangeRate     { get; set; }
        public int ExpenseAmountCur     { get; set; }
        public int ExpenseAmount        { get; set; }
    }

    /// <summary>
    /// Customer details to whom expenses may relate
    /// </summary>
    public class Customers
    {
        public Customers() { }

        [PrimaryKey, Unique]
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

        [PrimaryKey,Unique]
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

        [PrimaryKey,Unique]
        public int VendorID  { get; set; }
        public string Vendor { get; set; }
    }

    /// <summary>
    /// Customer contact who may have been involved with the expense
    /// </summary>
    public class Contact
    {
        public Contact() { }

        [PrimaryKey,Unique]
        public int ContactID        { get; set; }
        public int CustomerID       { get; set; }
        public string FirstName     { get; set; }
        public string LastName      { get; set; }
        public string Email         { get; set; }
        public string Telephone     { get; set; }
        public string MobilePhone   { get; set; }
        public string JobTitle      { get; set; }
        public string Department    { get; set; }
        public bool IsRetired       { get; set; }
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
}
