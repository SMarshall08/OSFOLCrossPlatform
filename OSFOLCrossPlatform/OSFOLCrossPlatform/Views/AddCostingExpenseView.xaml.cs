using System;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddCostingExpenseView : ContentPage
    {
        public AddCostingExpenseView(int loginID)
        {
            InitializeComponent();
        }

        #region Toolbar button click events
        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
        #endregion
    }
}
