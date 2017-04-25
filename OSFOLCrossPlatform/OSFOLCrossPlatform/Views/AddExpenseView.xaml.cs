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
        int _customerID;
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

            ExpenseSetNameLabel.Text = "Trip Name:";
            ExpenseSetNameLabel.IsVisible = true;
            ExpenseSetNameData.Text = _expenseSet.ExpenseSetName;
            ExpenseSetNameData.IsVisible = true;
            

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

            // We make a call to the database to get the expense set
            _expenseSet = App.Database.GetExpenseSet(expenseSetID);
            // Set the label to have true visibility
            ExpenseSetNameLabel.IsVisible = true;
            // Set the label to be the state trip name
            ExpenseSetNameLabel.Text = "Trip Name: ";
            ExpenseSetNameData.Text = _expenseSet.ExpenseSetName;
            ExpenseSetNameData.IsVisible = true;
            
            // Set the min and max date within the range of the expense set
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

            _loginID = editExpense.LoginID;
            
            Title = "Edit Expense";

            Save.Text = "Update";
            //Next.Text = "";
            
            // Checks to see if an expense set name is associated with the expense, if true then assign value to label
            if (editExpense.ExpenseSetName != null)
            {
                ExpenseSetNameLabel.Text = "Trip Name: ";
                ExpenseSetNameLabel.IsVisible = true;
                ExpenseSetNameData.Text = editExpense.ExpenseSetName;
                ExpenseSetNameData.IsVisible = true;


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
            _loginID = ExpenseReceiptCapture.LoginID;

            _expense = ExpenseReceiptCapture;

            // If expense set is valid, we still need to add expense to this set
            if(_expense.ExpenseSetID != 0)
            {
                Title = "Edit Expense";
                Save.Text = "Update";

                _expenseSet = App.Database.GetExpenseSet(_expense.ExpenseSetID);

                ExpenseSetNameLabel.Text = "Trip Name: ";
                ExpenseSetNameLabel.IsVisible = true;
                ExpenseSetNameData.Text = _expenseSet.ExpenseSetName;
                ExpenseSetNameData.IsVisible = true;


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
                    
                viewModel = new AddExpenseViewModel(_expense);
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
                await Navigation.PushAsync(new AddReceiptImage(_expense));
                //await Navigation.PopAsync();
            }
            else if(_expenseSetID > 0)
            {
                await Navigation.PushAsync(new AddReceiptImage(_loginID, _expenseSetID));
                //await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PushAsync(new AddReceiptImage(_loginID));
                //await Navigation.PopAsync();
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
            //expenseSetListView.SelectedIndex    = -1;
            locationFromEntry.Text              = string.Empty;
            locationToEntry.Text                = string.Empty;
            expenseDetailsEntry.Text            = string.Empty;
            expenseAmountCurEntry.Text          = "0";
            exchangeRateEntry.Text              = "1";
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
            customerListView.Items.Clear();
            opportunityListView.Items.Clear();
            contactListView.Items.Clear();

            // Get all list view data on appearing so user can quickly choose expense options. 
            customerListView.ItemsSource        = App.Database.GetCustomers();
            expenseTypeListView.ItemsSource     = App.Database.GetExpenseTypes();
            vendorListView.ItemsSource          = App.Database.GetVendor();
            expenseMethodListView.ItemsSource   = App.Database.GetExpenseMethods();
            currencyListView.ItemsSource        = App.Database.GetCurrency();

            //expenseSetListView.ItemsSource      = App.Database.GetExpenseSets(_loginID);

            // We want to set exchange rate to 1 default in case the user uses Sterling 
            if(_expense == null)
            {
                exchangeRateEntry.Text = "1.00";
            }
            

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
                expenseAmountCurEntry.Text          = _expense.ExpenseAmountCur.ToString();
                exchangeRateEntry.Text              = _expense.ExchangeRate.ToString();
                ReceiptImageUri.Text                = _expense.ReceiptImageUri;
                isRechargeableSwitch.IsToggled      = _expense.IsRechargeable;

                // Find the expense using expenseSetID from selected expense and extract expense set name to fill label
                if(_expense.ExpenseSetID > 0)
                {
                    ExpenseSet expenseSet         = App.Database.GetExpenseSet(_expense.ExpenseSetID);
                    ExpenseSetNameData.Text       = expenseSet.ExpenseSetName;
                    ExpenseSetNameData.IsVisible  = true;
                    ExpenseSetNameLabel.IsVisible = true;

                    //expenseSetListView.IsVisible  = false;
                }
                else
                {
                    ExpenseSetNameLabel.IsVisible   = true;
                    ExpenseSetNameData.IsVisible    = false;

                    //expenseSetListView.IsVisible    = true;
                }
                                 
                
            }

        }

        void onCustomerSelected(object sender, EventArgs e)
        {
            
            if(customerListView.SelectedIndex != -1)
            {
                Customers selectedCustomer      = customerListView.SelectedItem as Customers;
                int customerID                  = selectedCustomer.CustomerID;
                // Load the customer opportunities and refresh
                opportunityListView.Items.Clear();
                opportunityListView.ItemsSource = App.Database.GetDependencyOpportunity(customerID);

                // load customer contacts and refresh
                contactListView.Items.Clear();
                contactListView.ItemsSource     = App.Database.GetDependencyContact(customerID);
            }

            else
            {
                opportunityListView.ItemsSource     = App.Database.GetOpportunities();
                contactListView.ItemsSource         = App.Database.GetFullNameContact();
            }

        }



    }
}
