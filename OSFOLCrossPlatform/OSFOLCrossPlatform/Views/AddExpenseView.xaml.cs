using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using System.Diagnostics;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Helper;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddExpense : ContentPage
    {
        public int _loginID;
        private Expense _expense;


        AddExpenseViewModel viewModel;

        public AddExpense(int loginID)
        {
            InitializeComponent();
            _loginID = loginID;

            Title = "New Expense";

            viewModel = new AddExpenseViewModel(_loginID);
            BindingContext = viewModel;
        }

        // Method to gather the expensesummary selected from the review expense page
        public AddExpense(ExpenseSummary editExpense)
        {
            InitializeComponent();
            
            Title = "Edit Expense";
            
            _expense = App.Database.GetEditExpense(editExpense.ExpenseID);

            viewModel = new AddExpenseViewModel(_expense);
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
        }

        public void OnSaveButtonClicked (object sender, EventArgs e)
        {
            customerListView.SelectedIndex = -1;
            opportunityListView.SelectedIndex = -1;
            expenseTypeListView.SelectedIndex = -1;
            vendorListView.SelectedIndex = -1;
            contactListView.SelectedIndex = -1;
            expenseMethodListView.SelectedIndex = -1;
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
            contactListView.ItemsSource = App.Database.GetContact();
            expenseMethodListView.ItemsSource = App.Database.GetExpenseMethods();
            currencyListView.ItemsSource = App.Database.GetCurrency();

            if (_expense != null)
            {
                customerListView.SelectedValue = _expense.CustomerID;
                opportunityListView.SelectedValue = _expense.SalesOpportunityID;
                expenseTypeListView.SelectedValue = _expense.rfExpenseTypeID;
                vendorListView.SelectedValue = _expense.VendorID;
                contactListView.SelectedValue = _expense.ContactID;
                expenseMethodListView.SelectedValue = _expense.rfExpenseMethodID;
                locationFromEntry.Text = _expense.LocationFrom;
                locationToEntry.Text = _expense.LocationTo;
                expenseDetailsEntry.Text = _expense.ExpenseDetails;
                expenseAmountEntry.Text = _expense.ExpenseAmount.ToString();
            }
        }

    }
}
