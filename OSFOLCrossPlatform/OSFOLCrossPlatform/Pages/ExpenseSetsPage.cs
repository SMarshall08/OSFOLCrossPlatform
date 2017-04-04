using System;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Views;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Pages
{
    public class ExpenseSetsPage : ContentPage
    {
        int _loginID;
        int _expenseSetID;

        ListView _expenseSetListView;
        ExpenseSetsViewModel _expenseSetViewModel;
        ToolbarItem _addButtonToolBar;
        ToolbarItem _logoutButtonToolBar;
        ToolbarItem _homeButtonToolBar;
        private bool _areEventHandlersSubscribed;

        public ExpenseSetsPage(int loginID)
        {
            // Login Id that was carried over from the Add expense Set Page
            _loginID = loginID;

            _expenseSetViewModel = new ExpenseSetsViewModel(_loginID);
            BindingContext = _expenseSetViewModel;

            #region Create the ListView
            _expenseSetListView = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(ExpenseSetViewCell)),
                RowHeight = 50
            };

            // Pull down to refresh
            _expenseSetListView.IsPullToRefreshEnabled = true;
            _expenseSetListView.Refreshing += (async (sender, e) =>
            {
                await _expenseSetViewModel.RefreshExpenseSetsDataAsync(_loginID);
                _expenseSetListView.EndRefresh();
            });

            // Once a trip is selected the user is navigated to the trip expense report page
            _expenseSetListView.ItemSelected += (sender, e) =>
            {
                var expenseSet = e.SelectedItem as ExpenseSet;
                _expenseSetID = expenseSet.ExpenseSetID;

                Navigation.PushAsync(new IndividualExpenseSetPage(loginID, _expenseSetID));
            };

            // Bind the source items from All Expense Set Data with the list view
            _expenseSetListView.SetBinding(ListView.ItemsSourceProperty, "AllExpenseSetsData");
            #endregion

            // Set the title of the page
            Title = $"My Trips";

            #region Initialize the Toolbar Add Button
            _addButtonToolBar = new ToolbarItem();
            _logoutButtonToolBar = new ToolbarItem();
            _homeButtonToolBar = new ToolbarItem();

            _homeButtonToolBar.Text = "Home";
            _addButtonToolBar.Icon = "Add";
            _logoutButtonToolBar.Text = "Logout";

            ToolbarItems.Add(_homeButtonToolBar);
            ToolbarItems.Add(_addButtonToolBar);
            ToolbarItems.Add(_logoutButtonToolBar);
            #endregion

            #region Create Searchbar
            var searchBar = new SearchBar();
            searchBar.TextChanged += (sender, e) => _expenseSetViewModel.FilterExpenseSets(searchBar.Text, _loginID);
            #endregion

            #region Create Stack
            var listStack = new StackLayout
            {
                Padding = 0,
                Spacing = 0,
                Children = {
                    _expenseSetListView
                }
            };
            #endregion

            SubscribeEventHandlers();

            Content = listStack;

        }

        void SubscribeEventHandlers()
        {
            if (_areEventHandlersSubscribed)
                return;

            _homeButtonToolBar.Clicked += OnHomeButtonClicked;
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
            Navigation.PushModalAsync(new NavigationPage(new AddExpenseSet(_loginID)));
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
