using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddCustomerViewModel : ObservableObject
    {
        ExpenseDatabase database;
        Customers _customers;

        public Command SaveButtonTapped { get; private set; }

        int _CustomerID;
        int _LoginID;
        string _Customer;
        string _Location;
        string _Country;
        string _TelephoneNumber;
        int _rfBusinessOwnerID;
        int _IsRetired;
        string _Website;
        DateTime _ModifiedDT;
        int _RevisionNumber;

        public int LoginID
        {
            get { return _LoginID; }
            set
            {
                _LoginID = value;
                RaisePropertyChanged();
            }
        }

        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged();
            }
        }

        public string Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged();
            }
        }

        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                RaisePropertyChanged();
            }
        }

        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                RaisePropertyChanged();
            }
        }

        public string TelephoneNumber
        {
            get { return _TelephoneNumber; }
            set
            {
                _TelephoneNumber = value;
                RaisePropertyChanged();
            }
        }


        public int rfBusinessOwnerID
        {
            get { return _rfBusinessOwnerID; }
            set
            {
                _rfBusinessOwnerID = 1;
                RaisePropertyChanged();
            }
        }

        public int IsRetired
        {
            get { return _IsRetired; }
            set
            {
                _IsRetired = 0;
                RaisePropertyChanged();
            }
        }


        public string Website
        {
            get { return _Website; }
            set
            {
                _Website = "";
                RaisePropertyChanged();
            }
        }

        public DateTime ModifiedDT
        {
            get { return _ModifiedDT; }
            set
            {
                ModifiedDT = DateTime.Now ;
                RaisePropertyChanged();
            }
        }


        public int RevisionNumber
        {
            get { return _RevisionNumber; }
            set
            {
                _RevisionNumber = 0;
                RaisePropertyChanged();
            }
        }



        public AddCustomerViewModel(int loginID)
        {
            database = new ExpenseDatabase();
            _ModifiedDT = DateTime.Now;
            _LoginID = loginID;

            // save expense 
            SaveButtonTapped = new Command(() =>
            {

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveCustomer(new Customers
                {
                    LoginID = _LoginID,
                    rfBusinessOwnerID = 1,
                    Customer = _Customer,
                    Location = "",
                    Country = _Country,
                    IsRetired = 0,
                    TelephoneNum = "",
                    Website = "",
                    ModifiedDT = _ModifiedDT,
                    RevisionNo = 0


                }));


            });
        }
    }
}
