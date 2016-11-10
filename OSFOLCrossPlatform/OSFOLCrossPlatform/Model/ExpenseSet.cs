﻿using System;
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

    public class ExpenseSummary 
    {
        public ExpenseSummary() { }

        public int ExpenseID { get; set; }
        public int LoginID { get; set; }
        public DateTime CreatedDT { get; set; }
        public string Customer { get; set; }
        public string Contact { get; set; }
        public string Opportunity { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public string rfExpenseType { get; set; }
        public string rfExpenseMethod { get; set; }
        public string ExpenseDetails { get; set; }
        public string Vendor { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public int ExpenseAmountCur { get; set; }
        public int ExpenseAmount { get; set; }
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
        public string rfExpenseMethod { get; set; }
    }

    public class rfVendor
    {
        public rfVendor() { }

        [PrimaryKey,Unique]
        public int VendorID { get; set; }
        public string Vendor { get; set; }
    }

    public class Contact
    {
        public Contact() { }

        [PrimaryKey,Unique]
        public int ContactID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public bool IsRetired { get; set; }
        public DateTime CreatedDT { get; set; }
        public DateTime ModifiedDT { get; set; }
    }

    public class Currency
    {
        public Currency() { }

        [PrimaryKey,Unique]
        public int rfCurrencyID { get; set; }
        public string rfCurrency { get; set; }
        public string Description { get; set; }
    }
}
