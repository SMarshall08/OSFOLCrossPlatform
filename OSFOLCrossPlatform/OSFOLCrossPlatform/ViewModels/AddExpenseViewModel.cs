using System;
using System.Collections.Generic;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddExpenseViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets when update needed
        /// </summary>
        public bool UpdateNeeded { get; set; }

        ExpenseDatabase database;

        public ICommand SaveButtonTapped { protected set; get; }

        DateTime _modifiedDT;
        DateTime _createdDT;

        DateTime infinity = new DateTime(2050, 12, 31, 00, 00, 00);

        string _locationfrom;
        string _locationTo;
        string _expenseDetails;
        string _currency;
        string _Vendor;

        int _loginID;

        int _monthIdentifier;
        int _expenseID;
        int _contactID;
        int _CustomerID;
        int _SalesOpportunityID;
        int _rfDayPeriodID;
        int _expenseAmountCur;
        int _expenseAmount;
        int _rfExpenseMethodID;
        int _rfExpenseTypeID;
        int _rfBusinessOwner;

        decimal _exchangeRate;
        bool _isRechargeable;

        DateTime _paidDT;

        //public event EventHandler SaveError;
        //public event EventHandler SaveToDatabaseCompleted;

        #region ExpenseModel Get & Set
        public Expense Expense {get; set;}

        public int ExpenseID
        {
            get { return _expenseID; }
            set
            {
                _expenseID = value;
                RaisePropertyChanged("ExpenseID");
            }
        }

        public int LoginID
        {
            get { return _loginID; }
            set
            {
                _loginID = value;
                RaisePropertyChanged();
            }
        }

        public int MonthReportIdentifier
        {
            get { return _monthIdentifier; }
            set
            {   
                _monthIdentifier = value;
                RaisePropertyChanged();
            }
        }

        public int SalesOpportunityID
        {
            get { return _SalesOpportunityID; }
            set
            {
                _SalesOpportunityID = value;
                RaisePropertyChanged("SalesOpportunityID");
            }
        }
        public int rfDayPeriodID
        {
            get { return _rfDayPeriodID; }
            set
            {
                _rfDayPeriodID = value;
                RaisePropertyChanged();
            }
        }

        public string LocationFrom
        {
            get { return _locationfrom; }
            set
            {
                _locationfrom = value;
                RaisePropertyChanged();
            }
        }

        public string LocationTo
        {
            get { return _locationTo; }
            set
            {
                _locationTo = value;
                RaisePropertyChanged();
            }
        }

        public int CustomerID
        {
            get
            {
                 return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged();
            }
        }

        public string ExpenseDetails
        {
            get { return _expenseDetails; }
            set
            {
                _expenseDetails = value;
                RaisePropertyChanged();
            }
        }

        public int ContactID
        {
            get { return _contactID; }
            set
            {
                _contactID = value;
                RaisePropertyChanged();
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                RaisePropertyChanged();
            }
        }

        public decimal ExchangeRate
        {
            get { return _exchangeRate; }
            set
            {
                _exchangeRate = value;
                RaisePropertyChanged();
            }
        }
        public int ExpenseAmountCur
        {
            get { return _expenseAmountCur; }
            set
            {
                _expenseAmountCur = value;
                RaisePropertyChanged();
            }
        }

        public int ExpenseAmount
        {
            get { return _expenseAmount; }
            set
            {
                _expenseAmount = value;
                RaisePropertyChanged();
            }
        }

        public int rfExpenseTypeID
        {
            get
            {
                return _rfExpenseTypeID;
            }
            set
            {
                _rfExpenseTypeID = value;
                RaisePropertyChanged();
            }
        }

        public int rfExpenseMethodID
        {
            get { return _rfExpenseMethodID; }
            set
            {
                _rfExpenseMethodID = value;
                RaisePropertyChanged();
            }
        }

        public bool IsRechargeable
        {
            get { return _isRechargeable; }
            set
            {
                _isRechargeable = value;
                RaisePropertyChanged();
            }
        }

        public string Vendor
        {
            get { return _Vendor; }
            set
            {
                _Vendor = value;
                RaisePropertyChanged();
            }
        }

        public DateTime ModifiedDT
        {
            get
            {
                return _modifiedDT;
            }
            set
            {
                _modifiedDT = infinity;
            }
        }

        public DateTime CreatedDT
        {
            get
            {
                return _createdDT;
            }
            set
            {
                _createdDT = DateTime.Now;
            }
        }

        public int rfBusinessOwner
        {
            get { return _rfBusinessOwner; }
            set
            {
                _rfBusinessOwner = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        public AddExpenseViewModel(int expenseID, int loginID)
        {
            Task.Run(() => App.Database.GetExpenseItems(Expense));
        }


        /// <summary>
        /// LoginId passed in as param to save expenses to specific users
        /// </summary>
        /// <param name="loginID"></param>
        public AddExpenseViewModel(int loginID)
        {
            database = new ExpenseDatabase();
            var Expense = new Expense();

            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                // Task to call database and save expense with values from model 
                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveExpense(new Expense
                {
                    LoginID = loginID,
                    MonthReportIdentifier = 10,
                    SalesOpportunityID = _SalesOpportunityID,
                    Locationfrom = "Madrid",
                    LocationTo = "London",
                    CustomerID = _CustomerID,
                    ExpenseDetails = "Expense Test",
                    ContactID = 1,
                    Currency = "£",
                    ExchangeRate = 1.2m,
                    ExpenseAmountCur = 11,
                    ExpenseAmount = 15,
                    rfExpenseTypeID = _rfExpenseTypeID,
                    rfExpenseMethodID = _rfExpenseMethodID,
                    IsRechargeable = true,
                    Vendor = _Vendor,
                    ModifiedDT = _modifiedDT,
                    CreatedDT = DateTime.Now,
                    rfBusinessOwner = 1
                }));

            });

        }

    
        

        //private ObservableCollection<Expense> expenses = new ObservableCollection<Expense>();

        //public ObservableCollection<Expense> Expenses
        //{
        //    get { return expenses; }
        //    set { expenses = value; RaisePropertyChanged("Expenses"); }
        //}

        //public async Task UpdateExpenseData(int expenseID, int loginID)
        //{
        //    Expenses.Clear();
        //    UpdateNeeded = false;

        //    try
        //    {
        //        var exps = await App.Database.GetExpenseItems();

        //        foreach (var expense in exps)
        //        {

        //            Expenses.Add(expense);
        //        }
        //    }
        //}
    }
}
