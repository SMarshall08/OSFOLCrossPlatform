using System;
using OSFOLCrossPlatform.Infrastructure;
using SQLite;


namespace OSFOLCrossPlatform.Model
{
    public class ExpenseModel : ObservableObject
    {
        DateTime _modifiedDT;
        String _customer;
        String _opportunity;
        int _expenseID;
        int _loginID;

        [PrimaryKey, AutoIncrement, Unique]
        public int ExpenseID
        {
            get { return _expenseID; }
            set
            {
                _expenseID = value;
                RaisePropertyChanged();
            }
        }
        public int LoginID {get; set;}

        public DateTime ModifiedDT { get; set; }

        public String Customer { get; set; }

        public String Opportunity { get; set; }


        public ExpenseModel()
        {

        }


    }
}
