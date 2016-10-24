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

        Expense viewExpense;
        DateTime _expenseDateData;
        string _expenseCustomerData;
        string _expenseSalesOppData;
        string _expenseTypeData;
        string _expenseLocationFromData;
        string _expenseLocationToData;
        string _expenseDetailsData;
        string _expenseVendorData;
        string _expenseExpenseMethodData;
        string _expenseCurrencyData;
        decimal _expenseExchangeRateData;
        int _expenseAmountData;

        public DateTime expenseDateData
        {
            get { return _expenseDateData; }
            set
            {
                SetProperty<DateTime>(ref _expenseDateData, value);
            }
        }

        public string expenseCustomerData
        {
            get { return _expenseCustomerData; }
            set
            {
                SetProperty<string>(ref _expenseCustomerData, value);
            }
        }

        public string expenseSalesOppData
        {
            get { return _expenseSalesOppData; }
            set
            {
                SetProperty<string>(ref _expenseSalesOppData, value);
            }
        }

        public string expenseTypeData
        {
            get { return _expenseTypeData; }
            set
            {
                SetProperty<string>(ref _expenseTypeData, value);
            }
        }

        public string expenseLocationFromData
        {
            get { return _expenseLocationFromData; }
            set
            {
                SetProperty<string>(ref _expenseLocationFromData, value);
            }
        }

        public string expenseLocationToData
        {
            get { return _expenseLocationToData; }
            set
            {
                SetProperty<string>(ref _expenseLocationToData, value);
            }
        }

        public string expenseDetailsData
        {
            get { return _expenseDetailsData; }
            set
            {
                SetProperty<string>(ref _expenseDetailsData, value);
            }
        }

        public string expenseVendorData
        {
            get { return _expenseVendorData; }
            set
            {
                SetProperty<string>(ref _expenseVendorData, value);
            }
        }

        public string expenseExpenseMethodData
        {
            get { return _expenseExpenseMethodData; }
            set
            {
                SetProperty<string>(ref _expenseExpenseMethodData, value);
            }
        }

        public string expenseCurrencyData
        {
            get { return _expenseCurrencyData; }
            set
            {
                SetProperty<string>(ref _expenseCurrencyData, value);
            }
        }


        public decimal expenseExchangeRateData
        {
            get { return _expenseExchangeRateData; }
            set
            {
                SetProperty<decimal>(ref _expenseExchangeRateData, value);
            }
        }


        public int expenseAmountData
        {
            get { return _expenseAmountData; }
            set
            {
                SetProperty<int>(ref _expenseAmountData, value);
            }
        }

        public void ExpenseInnverView(Expense aSelectedExpense)
        {
            _loginID = aSelectedExpense.LoginID;
            _expenseID = aSelectedExpense.ExpenseID;

            viewExpense = App.Database.GetExpenses(_expenseID);

            int customerID = viewExpense.CustomerID;
            Customers customer = App.Database.GetCustomer(customerID);

            int salesOppID = viewExpense.SaleOpportunityID;
            SalesOpportunity salesOpp = App.Database.GetOpportunity(salesOppID);

            int expensetypeID = viewExpense.rfExpenseTypeID;
            ExpenseType expenseType = App.Database.GetExpenseType(expensetypeID);

            int expenseMethodID = viewExpense.rfExpenseMethodID;
            ExpenseMethod expenseMethod = App.Database.GetExpenseMethod(expenseMethodID);


            expenseDateData = viewExpense.ModifiedDT;
            expenseCustomerData = customer.Customer;
            expenseSalesOppData = salesOpp.Opportunity;
            expenseTypeData = expenseType.rfExpenseType;
            expenseLocationFromData = viewExpense.Locationfrom;
            expenseLocationToData = viewExpense.LocationTo;
            expenseDetailsData = viewExpense.ExpenseDetails;
            expenseVendorData = viewExpense.Vendor;
            expenseExpenseMethodData = expenseMethod.rfExpenseMetod;
            expenseCurrencyData = viewExpense.Currency;
            expenseExchangeRateData = viewExpense.ExchangeRate;
            expenseAmountData = viewExpense.ExpenseAmount;

        }
    }
}
