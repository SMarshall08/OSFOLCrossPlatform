using OSFOLCrossPlatform.Infrastructure;
using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Data;

namespace OSFOLCrossPlatform
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            using (var data = new ExpenseDatabase())
            {
                Login _user = data.GetLogin(this.usernameEntry.Text);

                if(_user == null)
                {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }

                var isValid = AreCredentialsCorrect(_user);
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
                    Navigation.InsertPageBefore(new MainPage(), this);
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
