using OSFOLCrossPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddVendorView : ContentPage
    {
        int _loginID;
        AddVendorViewModel viewModel;

        public AddVendorView(int loginID)
        {
            InitializeComponent();

            _loginID = loginID;

            viewModel = new AddVendorViewModel();
            BindingContext = viewModel;
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(_loginID), this);
            await Navigation.PopAsync();
        }

        // On button click go to expense report page to view most recent expense added
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AdminView(_loginID), this);
            await Navigation.PopAsync();
        }

        // On button click, clear all values to add new expense
        public void OnNextButtonClicked(Object sender, EventArgs e)
        {
            VendorEntry.Text = "";
        }
    }
}
