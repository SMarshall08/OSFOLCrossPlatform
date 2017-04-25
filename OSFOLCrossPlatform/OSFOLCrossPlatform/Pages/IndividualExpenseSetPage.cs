using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Messaging;

namespace OSFOLCrossPlatform.Pages
{
    public class IndividualExpenseSetPage : ContentPage
    {
        int _loginID;
        int _expenseSetID;
        int _expenseID;
        string _expenseSetName;

        ExpenseSet _expenseSet;

        ListView _listView;
        ExpensesViewModel _expenseSetViewModel;
        ToolbarItem _addButtonToolBar;
        ToolbarItem _logoutButtonToolBar;
        ToolbarItem _homeButtonToolBar;
        ToolbarItem _deleteButtonToolBar;
        ToolbarItem _sendTripCSV;
        bool _areEventHandlersSubscribed;

        public IndividualExpenseSetPage(int loginID, int expenseSetID)
        {
            _loginID = loginID;
            _expenseSetID = expenseSetID;

            _expenseSetViewModel = new ExpensesViewModel(_expenseSetID);
            BindingContext = _expenseSetViewModel;

            #region Create the ListView
            _listView = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(ExpensesViewCell)),
                RowHeight = 75
            };

            _listView.IsPullToRefreshEnabled = true;
            _listView.Refreshing += (async (sender, e) =>
            {
                await _expenseSetViewModel.RefreshExpenseSetDataAsync(_expenseSetID);
                _listView.EndRefresh();
            });

            _listView.ItemSelected += (sender, e) =>
            {
                var expense = e.SelectedItem as Expense;
                _expenseID = expense.ExpenseID;
                Navigation.PushAsync(new ViewExpenseView(_expenseID));
            };

            _listView.SetBinding(ListView.ItemsSourceProperty, "AllExpenseSetData");
            #endregion

            _expenseSet = App.Database.GetExpenseSet(_expenseSetID);
            _expenseSetName = _expenseSet.ExpenseSetName;

            Title =  _expenseSetName + $" Expenses";

            #region Initialize the Toolbar Add Button
            _addButtonToolBar       = new ToolbarItem();
            _logoutButtonToolBar    = new ToolbarItem();
            _homeButtonToolBar      = new ToolbarItem();
            _sendTripCSV            = new ToolbarItem();

            _homeButtonToolBar.Text     = "Home";
            _sendTripCSV.Text           = "Email Trip";
            _addButtonToolBar.Icon      = "Add";
            _logoutButtonToolBar.Text   = "Logout";

            ToolbarItems.Add(_homeButtonToolBar);
            ToolbarItems.Add(_sendTripCSV);
            ToolbarItems.Add(_addButtonToolBar);
            ToolbarItems.Add(_logoutButtonToolBar);
            #endregion

            #region Create Searchbar
            var searchBar = new SearchBar();
            searchBar.TextChanged += (sender, e) => _expenseSetViewModel.FilterExpenseSets(searchBar.Text, _expenseSetID);
            #endregion
                        

            #region Create Stack
            var listSearchStack = new StackLayout
            {
                Padding = 0,
                Spacing = 0,
                Children = {
                    searchBar,
                    _listView
                }
            };
            #endregion

            SubscribeEventHandlers();

            Content = listSearchStack;

        }

        void SubscribeEventHandlers()
        {
            if (_areEventHandlersSubscribed)
                return;

            _homeButtonToolBar.Clicked += OnHomeButtonClicked;
            _sendTripCSV.Clicked += OnSendEmailButtonClicked;
            _addButtonToolBar.Clicked += HandleAddButtonClicked;
            _logoutButtonToolBar.Clicked += OnLogoutButtonClicked;

            _areEventHandlersSubscribed = true;

        }

        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(_loginID), this);
            await Navigation.PopAsync();
        }

        void HandleAddButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddExpense(_loginID,_expenseSetID)));
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }

        public  IEnumerable<ExpenseSummary> QueryExpenseSets()
        {

            string expenseSetName = App.Database.GetExpenseSetName(_expenseSetID);

            return App.Database.GetExpenseSetSummary(expenseSetName);
        }

        async void OnSendEmailButtonClicked(object sender, EventArgs e)
        {
            // initialize expense string empty
            string allExpenses = @" 
Created Date, Customer, Contact, Opportunity, Location From, Location To, Expense Type, Expense Method, Expense Details, Vendor, Currency, Exchange Rate, Expense Amount Currency, Expense Amount";
            // go through each expense
            foreach (ExpenseSummary expense in QueryExpenseSets())
            {

                // compile a CSV string for this entry
                string expenseSetText = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                    expense.CreatedDT, expense.Customer, expense.Contact, expense.Opportunity, expense.LocationFrom, expense.LocationTo,
                    expense.rfExpenseType, expense.rfExpenseMethod, expense.ExpenseDetails, expense.Vendor, expense.rfCurrency, expense.ExchangeRate,
                    expense.ExpenseAmountCur, expense.ExpenseAmount);
                // append it to the list of all expenses with a carriage return/linefeed (new line)
                allExpenses = string.Format("{0}\r\n{1}", allExpenses, expenseSetText);
            }
            //string filename = "Expense.csv";
            //string filePath = DependencyService.Get<ISaveAndLoad>().SaveText(filename, allExpenses);

            // create an instance of an email messenger
            var emailMessenger = CrossMessaging.Current.EmailMessenger;

            // create email
            var email = new EmailMessageBuilder()
             .To("")
            .Subject("Expenses")
            .Body(allExpenses)
            .Build();

            // send email
            emailMessenger.SendEmail(email);
        }

        // Get all data from database on page appearing
        protected override async void OnAppearing()
        {
            await _expenseSetViewModel.RefreshExpenseSetDataAsync(_expenseSetID);
        }
    }
}
