using System;
using OSFOLCrossPlatform.Infrastructure;
using SQLite;


namespace OSFOLCrossPlatform.Model
{
    public class Expense : ObservableObject
    {
        DateTime _modifiedDT;
        String _customer;
        String _opportunity;
        int _expenseID;
        int _loginID;

        [PrimaryKey, AutoIncrement]
        public int ExpenseID
        {
            get { return _expenseID; }
            set
            {
                _expenseID = value;
                RaisePropertyChanged();
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

        public DateTime ModifiedDT
        {
            get { return _modifiedDT; }
            set
            {
                _modifiedDT = value;
                RaisePropertyChanged();
            }
        }

        public String Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                RaisePropertyChanged();
            }
        }

        public String Opportunity
        {
            get { return _opportunity; }
            set
            {
                _opportunity = value;
                RaisePropertyChanged();
            }
        }


        public Expense() { }


    }
}
