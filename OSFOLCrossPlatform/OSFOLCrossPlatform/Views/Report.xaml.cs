using System;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class Report : ContentPage
    {
        public Report()
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
