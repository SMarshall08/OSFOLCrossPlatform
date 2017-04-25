using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
	public partial class AdminView : ContentPage
	{
        int _loginID;
		public AdminView (int loginID)
		{
			InitializeComponent ();

            _loginID = loginID;
		}

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
            await Navigation.PushAsync(new MainPage(_loginID));
        }

        // On button click go to add customer page
        async void AddCustomerButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCustomerView(_loginID));
        }

        // On button click go to add customer page
        async void AddContactButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactView(_loginID));
        }

        // On button click go to add customer page
        async void AddSalesOppButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSalesOpportunityView(_loginID));
        }

        // On button click go to add customer page
        async void AddVendorButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVendorView(_loginID));
        }
    }
}
