using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddVendorViewModel : ObservableObject
    {
        public Command SaveButtonTapped { get; private set; }
        ExpenseDatabase _database;
        rfVendor _vendor;

        int _VendorID;
        string _Vendor;

        public string Vendor
        {
            get { return _Vendor; }
            set
            {
                _Vendor = value;
                RaisePropertyChanged();
            }
        }


        public AddVendorViewModel()
        {
            _database = new ExpenseDatabase();

            // save expense 
            SaveButtonTapped = new Command(() =>
            {

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SaveVendor(new rfVendor
                {
                    Vendor = _Vendor

                }));


            });
        }
    }
}
