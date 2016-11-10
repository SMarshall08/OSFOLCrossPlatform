using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Helper;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpenseViewModel : ObservableObject
    {
        private ExpenseService expenseService;
        private ExpenseSummary currrentExpense;

        public ExpenseViewModel()
        {
            expenseService = ServiceContainer.Resolve<ExpenseService>();
        }

        public ExpenseViewModel(ExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        public async Task InitialiseExpense(int expenseID)
        {
            if (expenseID >= 0)
                currrentExpense = await expenseService.GetExpense(expenseID);
            else
                currrentExpense = null;
            InitialiseExpense();
        }

        public void InitialiseExpense(ExpenseSummary expense)
        {
            currrentExpense = expense;
            InitialiseExpense();
        }

        private void InitialiseExpense()
        {
            if(currrentExpense == null)
            {

            }
        }


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
    }
}
