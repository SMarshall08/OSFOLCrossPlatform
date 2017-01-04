using System;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSFOLCrossPlatform.Model
{
    public class Expense
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class, made for the logged on user. Chain calls the standard constructure 
        /// </summary>
        /// <param name="loginID"></param>
        public Expense(int loginID) :this()
        {
            LoginID = loginID;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class. Sets the default modified date of the expense to be now
        /// </summary>
        public Expense()
        {
            ModifiedDT = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement, Unique]
        public int ExpenseID             { get; set; }
        public int SalesOpportunityID    { get; set; }
        public int LoginID               { get; set; }
        public int MonthReportIdentifier { get; set; }
        public string LocationFrom       { get; set; }
        public string LocationTo         { get; set; }
        public int CustomerID            { get; set; }
        public string ExpenseDetails     { get; set; }
        public int ContactID             { get; set; }
        public int rfCurrencyID          { get; set; }
        public decimal ExchangeRate      { get; set; }
        public int ExpenseAmountCur      { get; set; }
        public int ExpenseAmount         { get; set; }
        public int rfExpenseTypeID       { get; set; }
        public int rfExpenseMethodID     { get; set; }
        public bool IsRechargeable       { get; set; }
        public int VendorID              { get; set; }
        public DateTime ModifiedDT       { get; set; }
        public DateTime CreatedDT        { get; set; }
        public int rfBusinessOwner       { get; set; }

    }
}
