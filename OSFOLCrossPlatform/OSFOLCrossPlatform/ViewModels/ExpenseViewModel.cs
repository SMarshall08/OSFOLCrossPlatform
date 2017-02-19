using System;
using System.Threading.Tasks;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Helper;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpenseViewModel : ObservableObject
    {
        private ExpenseSummary currrentExpense;

        public ExpenseViewModel()
        {
            
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
        string _rfCurrency;
        string _FirstName; // Customer contact
        string _LastName; // Customer Contact
        string _Contact;
        decimal _ExchangeRate;
        decimal _ExpenseAmountCur;
        decimal _ExpenseAmount;

        string _receiptImageUri;


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
                return _Contact;
            }
            set
            {
                SetProperty<string>(ref _Contact, value);

                string[] names = _Contact.Split(' ');
                SetProperty<string>(ref _FirstName, names[0]);
                SetProperty<string>(ref _LastName, names[1]);
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

        public string rfCurrency
        {
            get { return _rfCurrency; }
            set
            {
                SetProperty<string>(ref _rfCurrency, value);
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


        public decimal ExpenseAmountCur
        {
            get { return _ExpenseAmountCur; }
            set
            {
                SetProperty<decimal>(ref _ExpenseAmountCur, value);
            }
        }
        public decimal ExpenseAmount
        {
            get { return _ExpenseAmount; }
            set
            {
                SetProperty<decimal>(ref _ExpenseAmount, value);
            }
        }

        public string ReceiptImageUri
        {
            get { return _receiptImageUri; }
            set
            {
                SetProperty<string>(ref _receiptImageUri, value);
            }
        }
    }
}
