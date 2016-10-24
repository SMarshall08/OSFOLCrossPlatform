using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using System.Diagnostics;
using OSFOLCrossPlatform.ViewModels;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddExpense : ContentPage
    {
        int _loginID;
        int _customerID;
        int _opportunityID;
        int _rfExpenseTypeID;
        int _vendorID;

        AddExpenseViewModel viewModel;

        public AddExpense(int loginID)
        {
            InitializeComponent();
            _loginID = loginID;

            viewModel = new AddExpenseViewModel(_loginID);
            BindingContext = viewModel;
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
            await Navigation.PushAsync(new MainPage(_loginID));
            //Navigation.InsertPageBefore(new MainPage(), this);
            //await Navigation.PopAsync();
        }
        #endregion

        // Get all data from database on page appearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            customerListView.ItemsSource = App.Database.GetCustomers();
            opportunityListView.ItemsSource = App.Database.GetOpportunities();
            expenseTypeListView.ItemsSource = App.Database.GetExpenseTypes();
            //vendorListView.ItemsSource = App.Database.GetVendor();
        }

        #region List item selected within the general tab
        void customerListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var customer = (Customers)e.SelectedItem;
            _customerID = customer.CustomerID;

            //((App)App.Current).ResumeAtExpenseId = customer.CustomerID;
            Debug.WriteLine("setting customer ID = " + customer.CustomerID);
        }

        void opportunityListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var opportunity = (SalesOpportunity)e.SelectedItem;
            _opportunityID = opportunity.SalesOpportunityID;

            Debug.WriteLine("setting sales opportunity ID = " + opportunity.SalesOpportunityID);
        }

        void expenseTypeListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var expenseType = (ExpenseType)e.SelectedItem;
            _rfExpenseTypeID = expenseType.rfExpenseTypeID;

            Debug.WriteLine("setting expense Type ID = " + expenseType.rfExpenseTypeID);
        }

        void vendorListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vendor = (rfVendor)e.SelectedItem;
            _vendorID = vendor.VendorID;

            Debug.WriteLine("setting Vendor ID = " + vendor.VendorID);
        }
        #endregion
    }
}
