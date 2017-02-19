using System;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform.ViewModels
{
    class AddExpenseSetViewModel : ObservableObject
    {
        ExpenseDatabase database;
        public ICommand SaveButtonTapped { protected set; get; }

        int _expenseSetID;
        int _loginID;
        string _expenseSetName;
        DateTime _fromDT;
        DateTime _toDT;
        DateTime _createdDT;

        public ExpenseSet ExpenseSet { get; set; }

        public int ExpenseSetID
        {
            get { return _expenseSetID; }
            set
            {
                _expenseSetID = value;
                RaisePropertyChanged("ExpenseSetID");
            }
        }

        public string ExpenseSetName
        {
            get { return _expenseSetName; }
            set
            {
                _expenseSetName = value;
                RaisePropertyChanged("ExpenseSetName");
            }
        }

        public DateTime FromDT
        {
            get
            {
                return _fromDT;
            }
            set
            {
                _fromDT = value;
                RaisePropertyChanged();
            }
        }

        public DateTime ToDT
        {
            get
            {
                return _toDT;
            }
            set
            {
                _toDT = value;
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public AddExpenseSetViewModel(int loginID)
        {
            database    = new ExpenseDatabase();
            _createdDT  = DateTime.Now;
            _fromDT     = DateTime.Now;
            _toDT       = DateTime.Now;
            _loginID    = loginID;

            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveExpenseSet(new ExpenseSet
                {
                    ExpenseSetName  = _expenseSetName,
                    LoginID         = _loginID,
                    FromDT          = _fromDT,
                    ToDT            = _toDT,
                    CreatedDT       = _createdDT
                }));


            });
        }
    }
}
