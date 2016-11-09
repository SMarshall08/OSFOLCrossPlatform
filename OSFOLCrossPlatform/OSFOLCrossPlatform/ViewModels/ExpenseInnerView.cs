using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpenseInnerView : ObservableObject
    {
        int _loginID;
        int _expenseID;

        ExpenseSummary viewExpense;

        DateTime _CreatedDT;
        string _Customer;
        string _Opportunity;
        string _rfExpenseType;
        string _LocationFrom;
        string _LocationTo;
        string _ExpenseDetails;
        string _Vendor;
        string _rfExpenseMethod;
        string _Currency;
        string _FirstName; // Customer contact
        string _LastName; // Customer Contact
        string _Contact;
        decimal _ExchangeRate;
        int _ExpenseAmountCur;
        int _ExpenseAmount;


        public DateTime CreatedDT
        {
            get { return _CreatedDT; }
            set
            {
                SetProperty<DateTime>(ref _CreatedDT, value);
            }
        }

        public string Customer
        {
            get { return _Customer; }
            set
            {
                SetProperty<string>(ref _Customer, value);
            }
        }

        public string Contact
        {
            get
            {
                _Contact = _FirstName + _LastName;
                return _Contact;
            }
            set
            {
                SetProperty<string>(ref _Contact, value);
            }
        }
        public string Opportunity
        {
            get { return _Opportunity; }
            set
            {
                SetProperty<string>(ref _Opportunity, value);
            }
        }

        public string rfExpenseType
        {
            get { return _rfExpenseType; }
            set
            {
                SetProperty<string>(ref _rfExpenseType, value);
            }
        }

        public string LocationFrom
        {
            get { return _LocationFrom; }
            set
            {
                SetProperty<string>(ref _LocationFrom, value);
            }
        }

        public string LocationTo
        {
            get { return _LocationTo; }
            set
            {
                SetProperty<string>(ref _LocationTo, value);
            }
        }

        public string ExpenseDetails
        {
            get { return _ExpenseDetails; }
            set
            {
                SetProperty<string>(ref _ExpenseDetails, value);
            }
        }

        public string Vendor
        {
            get { return _Vendor; }
            set
            {
                SetProperty<string>(ref _Vendor, value);
            }
        }

        public string rfExpenseMethod
        {
            get { return _rfExpenseMethod; }
            set
            {
                SetProperty<string>(ref _rfExpenseMethod, value);
            }
        }

        public string Currency
        {
            get { return _Currency; }
            set
            {
                SetProperty<string>(ref _Currency, value);
            }
        }


        public decimal ExchangeRate
        {
            get { return _ExchangeRate; }
            set
            {
                SetProperty<decimal>(ref _ExchangeRate, value);
            }
        }


        public int ExpenseAmountCur
        {
            get { return _ExpenseAmountCur; }
            set
            {
                SetProperty<int>(ref _ExpenseAmountCur, value);
            }
        }
        public int ExpenseAmount
        {
            get { return _ExpenseAmount; }
            set
            {
                SetProperty<int>(ref _ExpenseAmount, value);
            }
        }


        public void ExpenseInnverView(int aSelectedExpense)
        {
            viewExpense = App.Database.GetExpenses(aSelectedExpense);

            CreatedDT = viewExpense.CreatedDT;
            Customer = viewExpense.Customer;
            Contact = viewExpense.Contact;
            Opportunity = viewExpense.Opportunity;
            LocationFrom = viewExpense.LocationFrom;
            LocationTo = viewExpense.LocationTo;
            rfExpenseType = viewExpense.rfExpenseType;
            rfExpenseMethod = viewExpense.rfExpenseMethod;
            Vendor = viewExpense.Vendor;
            Currency = viewExpense.Currency;
            ExchangeRate = viewExpense.ExchangeRate;
            ExpenseAmountCur = viewExpense.ExpenseAmountCur;
            ExpenseAmount = viewExpense.ExpenseAmount;

        }
    }   
}
