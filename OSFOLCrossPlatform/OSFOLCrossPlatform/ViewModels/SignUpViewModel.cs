using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {
        ExpenseDatabase database;

        public ICommand SaveButtonTapped { protected set; get; }
        int _MaxLoginID;
        int _MaxLoginIDPlusOne;
        string _FirstName;
        string _LastName;
        string _UserName;
        string _Password;
        string _SecurityPin;

        public int LoginID
        {
            get { return _MaxLoginIDPlusOne; }
            set
            {
                _MaxLoginIDPlusOne = value;
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

        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                RaisePropertyChanged();
            }
        }
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                RaisePropertyChanged();
            }
        }

        public string SecurityPin
        {
            get { return _SecurityPin; }
            set
            {
                _SecurityPin = value;
                RaisePropertyChanged();
            }
        }

        public SignUpViewModel()
        {

            // save expense 
            SaveButtonTapped = new Command(() =>
            {
                _MaxLoginID = App.Database.GetMaxLoginID();
                _MaxLoginIDPlusOne = _MaxLoginID + 1;
                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SignUp(new Login
                {
                    LoginID = _MaxLoginIDPlusOne,
                    UserName = _UserName,
                    Password = _Password,
                    FirstName = _FirstName,
                    LastName = _LastName,
                    IsRetired = false

                }));


            });
        }
    }
}
