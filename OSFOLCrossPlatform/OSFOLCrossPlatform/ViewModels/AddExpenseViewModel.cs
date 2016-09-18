using System;
using System.Collections.Generic;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddExpenseViewModel : ObservableObject
    {
        ExpenseDatabase database;

        Expense _expense;
        int _opportunityID;
        SalesOpportunity opportunityID;
        DateTime _modifiedDT;
        int _rfDayPeriodID;
        string _locationfrom;
        string _locationTo;
        int _customerID;
        string _expenseDetails;
        int _contactID;
        string _currency;
        decimal _exchangeRate;
        int _expenseAmountCur;
        int _expenseAmount;
        int _rfExpensetypeID;
        int _rfExpenseMethodID;
        bool _isRechargeable;
        string _vendor;
        int _rfBusinessOwner;
        DateTime _paidDT;

        public event EventHandler SaveError;
        public event EventHandler SaveToDatabaseCompleted;

        #region ExpenseModel Get & Set
        public Expense Expense {get; set;}
        public SalesOpportunity SaleOpportunity { get; set; }
        public Customers Customer { get; set; }

        public int SaleOpportunityID
        {
            get { return  _opportunityID; }
            set
            {
                _opportunityID = value;
                RaisePropertyChanged();
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
            get { return Expense.CustomerID; }
            set
            {
                Expense.CustomerID = value;
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
            get { return _rfExpensetypeID; }
            set
            {
                _rfExpensetypeID = value;
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
            get { return _vendor; }
            set
            {
                _vendor = value;
                RaisePropertyChanged();
            }
        }

        public DateTime ModifiedDT
        {
            get { return Expense.ModifiedDT; }
            set
            {
                Expense.ModifiedDT = DateTime.Now;
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

        public DateTime PaidDT
        {
            get { return _paidDT; }
            set
            {
                _paidDT = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ICommand SaveButtonTapped { protected set; get; }

        public AddExpenseViewModel() { }

        /// <summary>
        /// LoginId passed in as param to save expenses to specific users
        /// </summary>
        /// <param name="loginID"></param>
        public AddExpenseViewModel(int loginID)
        {
            database = new ExpenseDatabase();
            Expense = new Expense();



            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                // all entries need to have a length greater than 0
                //if (SaleOpportunityID <= 0)
                //{
                //    SaveError(SaleOpportunityID, new EventArgs());
                //    return;
                //}

                // date = NOW
                //ModifiedDT = DateTime.Now;

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveExpense(new Expense
                {
                    LoginID = loginID,
                    SaleOpportunityID = SaleOpportunity.SalesOpportunityID,
                    rfDayPeriodID = 0,
                    Locationfrom = null,
                    LocationTo = "London",
                    CustomerID = Customer.CustomerID,
                    ExpenseDetails = "Expense Test",
                    ContactID = 0,
                    Currency = "£",
                    ExchangeRate = 1.2m,
                    ExpenseAmountCur = 11,
                    ExpenseAmount = 15,
                    rfExpensetypeID = 1,
                    rfExpenseMethodID = 1,
                    IsRechargeable = true,
                    Vendor = null,
                    ModifiedDT = DateTime.Now,
                    rfBusinessOwner = 1,
                    PaidDT = DateTime.Now
                }));


            });

        }
    }
}
