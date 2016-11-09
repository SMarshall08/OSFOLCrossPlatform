using System;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSFOLCrossPlatform.Model
{
    public class Expense : ObservableObject
    {
        public Expense(int loginID)
        {
            LoginID = loginID;
        }

        public Expense()
        {
            ModifiedDT = DateTime.Now;
        }

        //public Expense ( int salesOpportunityID, string locationFrom, string locationTo, int customerID, string expenseDetails,
        //    int contactID, string currency, decimal exchangeRate, int expenseAmountCur, int expenseAmount, int rfexpenseTypeID, int rfexpenseMethodID,
        //    bool isrechargeable, string vendor, DateTime modifiedDT, DateTime createdDT, int rfbusinessOwner)
        //{
        //    SalesOpportunityID = salesOpportunityID;
        //    Locationfrom = locationFrom;
        //    LocationTo = locationTo;
        //    CustomerID = customerID;
        //    ExpenseDetails = expenseDetails;
        //    ContactID = contactID;
        //    Currency = currency;
        //    ExchangeRate = exchangeRate;
        //    ExpenseAmountCur = expenseAmountCur;
        //    ExpenseAmount = expenseAmount;
        //    rfExpenseTypeID = rfexpenseTypeID;
        //    rfExpenseMethodID = rfexpenseMethodID;
        //    IsRechargeable = isrechargeable;
        //    Vendor = vendor;
        //    ModifiedDT = modifiedDT;
        //    rfBusinessOwner = rfbusinessOwner;
        //}


        [PrimaryKey, AutoIncrement, Unique]
        public int ExpenseID             { get; set; }
        public int SalesOpportunityID     { get; set; }
        public int LoginID               { get; set; }
        public int MonthReportIdentifier { get; set; }
        public string Locationfrom       { get; set; }
        public string LocationTo         { get; set; }
        public int CustomerID            { get; set; }
        public string ExpenseDetails     { get; set; }
        public int ContactID             { get; set; }
        public string Currency           { get; set; }
        public decimal ExchangeRate      { get; set; }
        public int ExpenseAmountCur      { get; set; }
        public int ExpenseAmount         { get; set; }
        public int rfExpenseTypeID       { get; set; }
        public int rfExpenseMethodID     { get; set; }
        public bool IsRechargeable       { get; set; }
        public string Vendor             { get; set; }
        public DateTime ModifiedDT       { get; set; }
        public DateTime CreatedDT        { get; set; }
        public int rfBusinessOwner       { get; set; }

        //public static IList<Expense> All { set; get; }


    }
}
