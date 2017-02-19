using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Pages;
using Plugin.Media;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddExpense : ContentPage
    {
        int _loginID;
        int _expenseSetID;
        int _month;
        private Expense _expense;
        private ExpenseSet _expenseSet;
        string _receiptImageUri;



        AddExpenseViewModel viewModel;

        public AddExpense(int loginID)
        {
            InitializeComponent();

            _loginID = loginID;

            Title = "New Expense";

            ExpenseSetNameLabel.IsVisible = false;

            Save.Text = "Save";

            AddPicture.Text = "Add Receipt Image";

            viewModel       = new AddExpenseViewModel(_loginID);
            BindingContext  = viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="expenseSetID"></param>
        public AddExpense(int loginID, int expenseSetID)
        {
            InitializeComponent();

            _loginID = loginID;
            _expenseSetID = expenseSetID;

            Title = "New Expense";

            Save.Text = "Save";

            _expenseSet = App.Database.GetExpenseSet(expenseSetID);

            ExpenseSetNameLabel.Text = _expenseSet.ExpenseSetName;

            ExpenseSetNameLabel.IsVisible = true;

            ExpenseDatePicker.MinimumDate = _expenseSet.FromDT;
            ExpenseDatePicker.MaximumDate = _expenseSet.ToDT;

            AddPicture.Text = "Add Receipt Image";

            viewModel = new AddExpenseViewModel(_loginID, _expenseSetID);
            BindingContext = viewModel;
        }

        /// <summary>
        /// add expense within an expense set and given a receipt image
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="expenseSetID"></param>
        /// <param name="receiptImageUri"></param>
        public AddExpense(int loginID, int expenseSetID, string receiptImageUri)
        {
            InitializeComponent();

            _loginID         = loginID;
            _expenseSetID    = expenseSetID;
            _receiptImageUri = receiptImageUri;

            Title = "New Expense";

            Save.Text = "Save";

            _expenseSet = App.Database.GetExpenseSet(expenseSetID);

            ExpenseSetNameLabel.Text = _expenseSet.ExpenseSetName;

            ExpenseSetNameLabel.IsVisible = true;

            ExpenseDatePicker.MinimumDate = _expenseSet.FromDT;
            ExpenseDatePicker.MaximumDate = _expenseSet.ToDT;

            if (_receiptImageUri != null)
            {
                AddPicture.Text = "Change Photo";
            }
            else
                AddPicture.Text = "Add Receipt Image";

            viewModel = new AddExpenseViewModel(_loginID,_expenseSetID, _receiptImageUri);
            BindingContext = viewModel;
        }

        /// <summary>
        /// Add expense whilst carrying the URi for receipt image attached
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="receiptImageUri"></param>
        public AddExpense(int loginID, string receiptImageUri)
        {
            InitializeComponent();
            _loginID         = loginID;
            _receiptImageUri = receiptImageUri;

            ReceiptImageUri.Text = _receiptImageUri;

            Title = "New Expense";

            Save.Text = "Save";

            ExpenseSetNameLabel.IsVisible = false;

            if (_receiptImageUri != null)
            {
                AddPicture.Text = "Change Photo";
            }
            else
                AddPicture.Text = "Add Receipt Image";

            viewModel = new AddExpenseViewModel(_loginID,_receiptImageUri);
            BindingContext = viewModel;
        }

        // Method to gather the expensesummary selected from the review expense page
        public AddExpense(ExpenseSummary editExpense)
        {
            InitializeComponent();
            
            Title = "Edit Expense";

            Save.Text = "Update";

            // Checks to see if an expense set name is associated with the expense, if true then assign value to label
            if(editExpense.ExpenseSetName != null)
            {
                ExpenseSetNameLabel.Text = editExpense.ExpenseSetName;
                ExpenseSetNameLabel.IsVisible = true;

                int expenseID = editExpense.ExpenseID;
                _expense = App.Database.GetEditExpense(expenseID);
                _expenseSet = App.Database.GetExpenseSet(_expense.ExpenseSetID);

                ExpenseDatePicker.MinimumDate = _expenseSet.FromDT;
                ExpenseDatePicker.MaximumDate = _expenseSet.ToDT;
            }

            ExpenseSetNameLabel.IsVisible = false;

            // Checks to see if a receipt imae uri is attached to the expense, if true then change dd picture text to change picture
            if (editExpense.ReceiptImageUri != null)
            {
                AddPicture.Text = "Change Photo";
            }
            else
                AddPicture.Text = "Add Receipt Image";

            _expense = App.Database.GetEditExpense(editExpense.ExpenseID);

            viewModel       = new AddExpenseViewModel(_expense);
            BindingContext  = viewModel;
        }

        // Method to gather the expensesummary selected from the review expense page
        public AddExpense(Expense ExpenseReceiptCapture)
        {
            InitializeComponent();

            _expense = ExpenseReceiptCapture;

            // If expense set is valid, we still need to add expense to this set
            if(_expense.ExpenseSetID > 0)
            {
                Title = "Add Expense";
                Save.Text = "Save";

                _expenseSet = App.Database.GetExpenseSet(_expense.ExpenseSetID);

                ExpenseSetNameLabel.Text = _expenseSet.ExpenseSetName;
                ExpenseSetNameLabel.IsVisible = true;

                ExpenseDatePicker.MinimumDate = _expenseSet.FromDT;
                ExpenseDatePicker.MaximumDate = _expenseSet.ToDT;

                if (_expense.ReceiptImageUri != null)
                {
                    AddPicture.Text = "Change Photo";
                }
                else
                {
                    AddPicture.Text = "Add Receipt Image";
                }
                    
                viewModel = new AddExpenseViewModel(_expense.LoginID,_expense.ExpenseSetID);
            }
            else
            {
                Title = "Edit Expense";

                Save.Text = "Update";

                ExpenseSetNameLabel.IsVisible = false;

                if (_expense.ReceiptImageUri != null)
                {
                    AddPicture.Text = "Change Photo";
                }
                else
                    AddPicture.Text = "Add Receipt Image";

                viewModel = new AddExpenseViewModel(_expense);
            }

            BindingContext = viewModel;
        }


        #region Tool-bar button click events

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void AddPictureButton_OnClicked (object sender, EventArgs e)
        {
            if(_expense != null)
            {
                Navigation.InsertPageBefore(new AddReceiptImage(_expense), this);
                await Navigation.PopAsync();
            }
            //else if(customerListView.SelectedValue != null || opportunityListView.SelectedValue != null || expenseTypeListView.SelectedValue != null ||
            //        vendorListView.SelectedValue != null || contactListView.SelectedValue != null || expenseMethodListView.SelectedValue != null ||
            //        currencyListView.SelectedValue != null || locationFromEntry.Text != null || locationToEntry.Text != null || expenseDetailsEntry.Text != null ||
            //         _expense.ExpenseSetID > 0)
            //{
            //    customerListView.SelectedValue = _expense.CustomerID;
            //    opportunityListView.SelectedValue = _expense.SalesOpportunityID;
            //    expenseTypeListView.SelectedValue = _expense.rfExpenseTypeID;
            //    vendorListView.SelectedValue = _expense.VendorID;
            //    contactListView.SelectedValue = _expense.ContactID;
            //    expenseMethodListView.SelectedValue = _expense.rfExpenseMethodID;
            //    currencyListView.SelectedValue = _expense.rfCurrencyID;
            //    locationFromEntry.Text = _expense.LocationFrom;
            //    locationToEntry.Text = _expense.LocationTo;
            //    expenseDetailsEntry.Text = _expense.ExpenseDetails;
            //    expenseAmountEntry.Text = _expense.ExpenseAmount.ToString();
            //    isRechargeableSwitch.IsToggled = _expense.IsRechargeable;


            //    Navigation.InsertPageBefore(new AddReceiptImage(_expense), this);
            //    await Navigation.PopAsync();

            //}
            else if(_expenseSetID > 0)
            {
                Navigation.InsertPageBefore(new AddReceiptImage(_loginID, _expenseSetID), this);
                await Navigation.PopAsync();
            }
            else
            {
                Navigation.InsertPageBefore(new AddReceiptImage(_loginID), this);
                await Navigation.PopAsync();
            }
                
        }

        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_loginID));
        }

        // On button click go to expense report page to view most recent expense added
        async void OnSaveButtonClicked (object sender, EventArgs e)
        {
            _month = ExpenseDatePicker.Date.Month;
            Navigation.InsertPageBefore(new ExpensesPage(_loginID, _month), this);
            await Navigation.PopAsync();
        }

        // On button click, clear all values to add new expense
        public void OnNextButtonClicked(Object sender, EventArgs e)
        {
            
            customerListView.SelectedIndex      = -1;
            opportunityListView.SelectedIndex   = -1;
            expenseTypeListView.SelectedIndex   = -1;
            vendorListView.SelectedIndex        = -1;
            contactListView.SelectedIndex       = -1;
            expenseMethodListView.SelectedIndex = -1;
            currencyListView.SelectedIndex      = -1;
            locationFromEntry.Text              = string.Empty;
            locationToEntry.Text                = string.Empty;
            expenseDetailsEntry.Text            = string.Empty;
            expenseAmountEntry.Text             = "0";
            ReceiptImageUri.Text                = string.Empty;
            ExpenseDatePicker.Date              = DateTime.Now;
            isRechargeableSwitch.IsToggled      = false;

            AddPicture.Text = "Add Receipt Image";
        }
        #endregion

       

        // Get all data from database on page appearing
        protected override void OnAppearing()
        {
            base.OnAppearing();
            customerListView.ItemsSource        = App.Database.GetCustomers();
            opportunityListView.ItemsSource     = App.Database.GetOpportunities();
            expenseTypeListView.ItemsSource     = App.Database.GetExpenseTypes();
            vendorListView.ItemsSource          = App.Database.GetVendor();
            contactListView.ItemsSource         = App.Database.GetContact();
            expenseMethodListView.ItemsSource   = App.Database.GetExpenseMethods();
            currencyListView.ItemsSource        = App.Database.GetCurrency();

            // If expense does not equal null fill fields with data.
            if (_expense != null)
            {
                customerListView.SelectedValue      = _expense.CustomerID;
                opportunityListView.SelectedValue   = _expense.SalesOpportunityID;
                expenseTypeListView.SelectedValue   = _expense.rfExpenseTypeID;
                vendorListView.SelectedValue        = _expense.VendorID;
                contactListView.SelectedValue       = _expense.ContactID;
                expenseMethodListView.SelectedValue = _expense.rfExpenseMethodID;
                currencyListView.SelectedValue      = _expense.rfCurrencyID;
                locationFromEntry.Text              = _expense.LocationFrom;
                locationToEntry.Text                = _expense.LocationTo;
                expenseDetailsEntry.Text            = _expense.ExpenseDetails;
                expenseAmountEntry.Text             = _expense.ExpenseAmount.ToString();
                ReceiptImageUri.Text                = _expense.ReceiptImageUri;
                isRechargeableSwitch.IsToggled      = _expense.IsRechargeable;
            }
        }

        

    }
}
