using OSFOLCrossPlatform.Infrastructure;
using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Views;

namespace OSFOLCrossPlatform.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Async method to check if user credentials are correct and valid in order to be logged in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            using (var data = new ExpenseDatabase())
            {
                Login _user = data.GetLogin(this.usernameEntry.Text);

                // If _user returned null error message will be shown
                if(_user == null)
                {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }

                var isValid = AreCredentialsCorrect(_user);

                // If true continue
                if (isValid)
                {
                    
                    var user = new Login
                    {
                        LoginID  = _user.LoginID,
                        UserName = usernameEntry.Text,
                        Password = passwordEntry.Text,
                        FirstName = _user.FirstName,
                        LastName = _user.LastName
                    };

                    App.IsUserLoggedIn = true;

                    Navigation.InsertPageBefore(new MainPage(user.LoginID), this);
                    await Navigation.PopAsync();
                }
                else {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }
            }
        }

        bool AreCredentialsCorrect(Login user)
        {
            if (user.IsRetired == false && user.UserName == usernameEntry.Text && user.Password == passwordEntry.Text)
            {
                return true;
            }
            else if (user.IsRetired == true)
            {
                return false;
            }
            else
            {
                return false;
            }
             
        }
    }
}
