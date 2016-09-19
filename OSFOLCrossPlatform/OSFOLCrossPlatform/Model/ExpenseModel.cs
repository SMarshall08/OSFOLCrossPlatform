using System;
using OSFOLCrossPlatform.Infrastructure;
using SQLite;
using System.Collections.Generic;

namespace OSFOLCrossPlatform.Model
{
    public class Expense : ObservableObject
    {
        //DateTime _modifiedDT;
        //IList<Customers> _customer;
        //IList<SalesOpportunity> _opportunity;
        //int _expenseID;
        //int _loginID;

        public Expense(int loginID)
        {
            LoginID = loginID;
        }

        public Expense() { }

        [PrimaryKey, AutoIncrement, Unique]
        public int ExpenseID          { get; set; }
        public int SaleOpportunityID  { get; set; }
        public int LoginID            { get; set; }
        public int rfDayPeriodID      { get; set; }
        public string Locationfrom    { get; set; }
        public string LocationTo      { get; set; }
        public int CustomerID         { get; set; }
        public string ExpenseDetails  { get; set; }
        public int ContactID          { get; set; }
        public string Currency        { get; set; }
        public decimal ExchangeRate   { get; set; }
        public int ExpenseAmountCur   { get; set; }
        public int ExpenseAmount      { get; set; }
        public int rfExpensetypeID    { get; set; }
        public int rfExpenseMethodID  { get; set; }
        public bool IsRechargeable    { get; set; }
        public string Vendor          { get; set; }
        public DateTime ModifiedDT    { get; set; }
        public int rfBusinessOwner    { get; set; }
        public DateTime PaidDT        { get; set; }
      

    }
}
