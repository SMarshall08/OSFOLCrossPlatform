using System;
using System.Collections.Generic;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Helper;
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

        DateTime _ModifiedDT;
        DateTime _CreatedDT;

        DateTime infinity = new DateTime(2050, 12, 31, 00, 00, 00);

        string _LocationFrom;
        string _LocationTo;
        string _ExpenseDetails;


        int _LoginID;

        int _monthIdentifier;
        int _expenseID;
        int _ContactID;
        int _CustomerID;
        int _SalesOpportunityID;
        int _rfDayPeriodID;
        int _ExpenseAmountCur;
        int _ExpenseAmount;
        int _rfExpenseMethodID;
        int _rfExpenseTypeID;
        int _rfBusinessOwner;
        int _rfCurrencyID;
        int _VendorID;

        decimal _ExchangeRate;
        bool _IsRechargeable;

        #region ExpenseModel Get & Set
        public Expense Expense { get; set; }

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
            get { return _LoginID; }
            set
            {
                _LoginID = value;
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
            get { return _LocationFrom; }
            set
            {
                _LocationFrom = value;
                RaisePropertyChanged();
            }
        }

        public string LocationTo
        {
            get { return _LocationTo; }
            set
            {
                _LocationTo = value;
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
            get { return _ExpenseDetails; }
            set
            {
                _ExpenseDetails = value;
                RaisePropertyChanged("ExpenseDetails");
            }
        }

        public int ContactID
        {
            get { return _ContactID; }
            set
            {
                _ContactID = value;
                RaisePropertyChanged();
            }
        }

        public int rfCurrencyID
        {
            get { return _rfCurrencyID; }
            set
            {
                _rfCurrencyID = value;
                RaisePropertyChanged("Currency");
            }
        }

        public decimal ExchangeRate
        {
            get { return _ExchangeRate; }
            set
            {
                _ExchangeRate = value;
                RaisePropertyChanged();
            }
        }
        public int ExpenseAmountCur
        {
            get { return _ExpenseAmountCur; }
            set
            {
                _ExpenseAmountCur = value;
                RaisePropertyChanged();
            }
        }

        public int ExpenseAmount
        {
            get { return _ExpenseAmount; }
            set
            {
                _ExpenseAmount = value;
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
            get { return _IsRechargeable; }
            set
            {
                _IsRechargeable = value;
                RaisePropertyChanged();
            }
        }

        public int VendorID
        {
            get { return _VendorID; }
            set
            {
                _VendorID = value;
                RaisePropertyChanged();
            }
        }

        public DateTime ModifiedDT
        {
            get
            {
                return _ModifiedDT;
            }
            set
            {
                _ModifiedDT = infinity;
            }
        }

        public DateTime CreatedDT
        {
            get
            {
                return _CreatedDT;
            }
            set
            {
                _CreatedDT = DateTime.Now;
                RaisePropertyChanged();
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

        public AddExpenseViewModel(Expense expense)
        {
            database = new ExpenseDatabase();

            LoginID                 = expense.LoginID;
            MonthReportIdentifier   = expense.MonthReportIdentifier;
            SalesOpportunityID      = expense.SalesOpportunityID;
            LocationFrom            = expense.LocationFrom;
            LocationTo              = expense.LocationTo;
            CustomerID              = expense.CustomerID;
            ExpenseDetails          = expense.ExpenseDetails;
            ContactID               = expense.ContactID;
            rfCurrencyID            = expense.rfCurrencyID;
            ExchangeRate            = expense.ExchangeRate;
            ExpenseAmountCur        = expense.ExpenseAmountCur;
            ExpenseAmount           = expense.ExpenseAmount;
            rfExpenseTypeID         = expense.rfExpenseTypeID;
            rfExpenseMethodID       = expense.rfExpenseMethodID;
            IsRechargeable          = expense.IsRechargeable;
            VendorID                = expense.VendorID;
            ModifiedDT              = DateTime.Now;
            CreatedDT               = expense.CreatedDT;
            rfBusinessOwner         = expense.rfBusinessOwner;


            SaveButtonTapped = new Command(() =>
            {
                Task.Run(() => App.Database.SaveExpense(expense));
            });
        }

        /// <summary>
        /// LoginId passed in as param to save expenses to specific users
        /// </summary>
        /// <param name="loginID"></param>
        public AddExpenseViewModel(int loginID)
        {
            database = new ExpenseDatabase();
            _CreatedDT = DateTime.Now;
            _LoginID = loginID;

            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                _monthIdentifier = _CreatedDT.Month;

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveExpense(new Expense
                {
                    LoginID               = _LoginID,
                    MonthReportIdentifier = _monthIdentifier,
                    SalesOpportunityID    = _SalesOpportunityID,
                    LocationFrom          = _LocationFrom,
                    LocationTo            = _LocationTo,
                    CustomerID            = _CustomerID,
                    ExpenseDetails        = _ExpenseDetails,
                    ContactID             = _ContactID,
                    rfCurrencyID          = _rfCurrencyID,
                    ExchangeRate          = 1.2m,
                    ExpenseAmountCur      = 11,
                    ExpenseAmount         = _ExpenseAmount,
                    rfExpenseTypeID       = _rfExpenseTypeID,
                    rfExpenseMethodID     = _rfExpenseMethodID,
                    IsRechargeable        = _IsRechargeable,
                    VendorID              = _VendorID,
                    ModifiedDT            = _ModifiedDT,
                    CreatedDT             = _CreatedDT,
                    rfBusinessOwner       = 1
                }));


            });

        }
    }
}
