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
        public int _expenseID;
        

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

            _expenseID = editExpense.ExpenseID;

            var expense = new Expense();

            expense = App.Database.GetEditExpense(_expenseID);

            customerListView.DisplayMemberPath = editExpense.Customer;
            opportunityListView.DisplayMemberPath = editExpense.Opportunity;
            vendorListView.DisplayMemberPath = editExpense.Vendor;
            locationFromEntry.Text = editExpense.LocationFrom;
            locationToEntry.Text = editExpense.LocationTo;
            expenseDetailsEntry.Text = editExpense.ExpenseDetails;
            contactListView.DisplayMemberPath = editExpense.Contact;
            expenseTypeListView.DisplayMemberPath = editExpense.rfExpenseType;
            expenseMethodListView.DisplayMemberPath = editExpense.rfExpenseMethod;
            currencyListView.DisplayMemberPath = editExpense.Currency;
            expenseAmountEntry.Text = editExpense.ExpenseAmount.ToString();

            customerListView.SelectedValue = expense.CustomerID;
            opportunityListView.SelectedValue = expense.SalesOpportunityID;
            vendorListView.SelectedValue = expense.VendorID;
            contactListView.SelectedValue = expense.ContactID;
            expenseTypeListView.SelectedValue = expense.rfExpenseTypeID;
            expenseMethodListView.SelectedValue = expense.rfExpenseMethodID;

            viewModel = new AddExpenseViewModel(expense);
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
            customerListView.DisplayMemberPath = null;
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

            //viewModel.ExpenseDetails = this.expenseDetailsEntry.Text;
            //viewModel.LocationFrom = this.locationFromEntry.Text;
            //viewModel.LocationTo = this.locationToEntry.Text;
        }

    }
}
