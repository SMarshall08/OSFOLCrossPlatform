using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddSalesOpportunityViewModel : ObservableObject
    {
        public Command SaveButtonTapped { get; private set; }
        ExpenseDatabase _database;
        SalesOpportunity _opportunity;

        int _opportunityID;
        int _maxOpportunityID;
        string _Opportunity;
        int _rfBusinessOwnerID;
        int _PersonnelOwnerID;
        int _CustomerID;
        string _BusinessOwnerCurrency;
        DateTime _ModifiedDT;

        public string Opportunity
        {
            get { return _Opportunity; }
            set
            {
                _Opportunity = value;
                RaisePropertyChanged();
            }
        }

        public int rfBusinessOwnerID
        {
            get { return _rfBusinessOwnerID; }
            set
            {
                _rfBusinessOwnerID = value;
                RaisePropertyChanged();
            }
        }

        public int PersonnelOwnerID
        {
            get { return _PersonnelOwnerID; }
            set
            {
                _PersonnelOwnerID = value;
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

        public string BusinessOwnerCurrency
        {
            get { return _BusinessOwnerCurrency; }
            set
            {
                _BusinessOwnerCurrency = value;
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



        public AddSalesOpportunityViewModel(int loginID)
        {
            _database = new ExpenseDatabase();
            _ModifiedDT = DateTime.Now;

            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                _opportunityID = App.Database.GetMaxSalesOpportunityID();
                _maxOpportunityID = _opportunityID + 1;
                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveSalesOpportunity(new SalesOpportunity
                {
                    SalesOpportunityID      = _maxOpportunityID,
                    rfBusinessOwnerID       = 1,
                    PersonnelOwnerID        = loginID,
                    CustomerID              = _CustomerID,
                    Opportunity             = _Opportunity,
                    BusinessOwnercurrency   = "",
                    ModifiedDT              = _ModifiedDT

                }));


            });
        }

    }
}
