using System;
using Xamarin.Forms;

namespace OSFOLCrossPlatform
{
    public partial class EditExpense : ContentPage
    {
        public EditExpense()
        {
            InitializeComponent();
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }


    }
}
