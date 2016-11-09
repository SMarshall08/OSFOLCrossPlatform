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

        AddExpenseViewModel viewModel;

        public AddExpense(int loginID)
        {
            InitializeComponent();
            _loginID = loginID;

            viewModel = new AddExpenseViewModel(_loginID);
            BindingContext = viewModel;
        }

        // Method to gather the expensesummary selected from the review expense page
        public AddExpense(ExpenseSummary editExpense)
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
            vendorListView.ItemsSource = App.Database.GetVendor();
        }

    }
}
