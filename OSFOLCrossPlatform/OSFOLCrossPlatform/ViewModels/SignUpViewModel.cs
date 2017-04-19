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

        string _FirstName;
        string _LastName;
        string _UserName;
        string _Password;

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

        public SignUpViewModel()
        {

            // save expense 
            SaveButtonTapped = new Command(() =>
            {

                // Task to call database and save expense with values from model 
                Task.Run(() => App.Database.SignUp(new Login
                {
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
