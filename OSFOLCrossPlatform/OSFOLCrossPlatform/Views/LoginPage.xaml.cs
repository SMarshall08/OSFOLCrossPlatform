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
        public int _loginID;

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
                //Login user = data.GetLogin(this.usernameEntry.Text);
                Login user = data.GetLogin(usernameListView.SelectedValue.ToString());

                // If user returned null error message will be shown
                if (user == null)
                {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }

                var isValid = AreCredentialsCorrect(user);

                // If true continue
                if (isValid)
                {
                    _loginID = user.LoginID;

                    App.IsUserLoggedIn = true;

                    //Navigation.InsertPageBefore(new MainPage(_loginID), this);
                    await Navigation.PushAsync(new MainPage(_loginID));
                    Navigation.RemovePage(this);
                    //await Navigation.PopAsync();
                }
                else {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Checks to see if the login credentials are correct
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AreCredentialsCorrect(Login user)
        {
            if (user.IsRetired == false && user.UserName == usernameListView.SelectedValue.ToString() && user.Password == passwordEntry.Text)
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

        /// <summary>
        /// Navigates the user to the Sign Up PAge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void GoToSignUpButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpView());
        }

        // Get all data from database on page appearing
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Get all list view data on appearing so user can quickly choose expense options. 
            usernameListView.ItemsSource = App.Database.GetUserNames();
        }

    }
}
