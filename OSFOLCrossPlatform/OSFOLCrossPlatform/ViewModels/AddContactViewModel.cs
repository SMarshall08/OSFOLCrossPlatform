﻿using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace OSFOLCrossPlatform.ViewModels
{
    public class AddContactViewModel : ObservableObject
    {
        public Command SaveButtonTapped { get; private set; }
        ExpenseDatabase _database;
        Contact _contact;

        int _CustomerID;

        string _Title;
        string _FirstName;
        string _LastName;
        string _Email;
        string _Telephone;
        string _MobilePhone;
        string _JobTitle;
        string _Department;

        int _IsRetired;
        DateTime _CreatedDT;
        DateTime _ModifiedDT;

        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged();
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                RaisePropertyChanged();
            }
        }

        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                RaisePropertyChanged();
            }
        }

        public string MobilePhone
        {
            get { return _MobilePhone; }
            set
            {
                _MobilePhone = value;
                RaisePropertyChanged();
            }
        }

        public string JobTitle
        {
            get { return _JobTitle; }
            set
            {
                _JobTitle = value;
                RaisePropertyChanged();
            }
        }

        public string Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
                RaisePropertyChanged();
            }
        }

        public int IsRetired
        {
            get { return _IsRetired; }
            set
            {
                _IsRetired = value;
                RaisePropertyChanged();
            }
        }

        public DateTime CreatedDT
        {
            get { return _CreatedDT; }
            set
            {
                _CreatedDT = value;
                RaisePropertyChanged();
            }
        }

        public DateTime ModifiedDT
        {
            get { return _ModifiedDT; }
            set
            {
                _ModifiedDT = value;
                RaisePropertyChanged();
            }
        }

        public AddContactViewModel()
        {
            _database = new ExpenseDatabase();
            _ModifiedDT = DateTime.Now;
            _CreatedDT = DateTime.Now;

            // save expense 
            SaveButtonTapped = new Command(() =>
            {

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveContact(new Contact
                {

                    CustomerID = _CustomerID,
                    Title = "",
                    FirstName = _FirstName,
                    LastName = _LastName,
                    Email = "",
                    Telephone = "",
                    MobilePhone = "",
                    JobTitle = "",
                    Department = "",
                    IsRetired = 0,
                    CreatedDT = _CreatedDT,
                    ModifiedDT = _ModifiedDT

                }));


            });
        }
    }
}
