using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using System.Threading.Tasks;

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
                Navigation.PushAsync(new ViewExpenseCS(_expenseID));
            };

            _listView.SetBinding(ListView.ItemsSourceProperty, "AllExpenseSetData");
            #endregion

            _expenseSet = App.Database.GetExpenseSet(_expenseSetID);
            _expenseSetName = _expenseSet.ExpenseSetName;

            Title =  _expenseSetName + $" Expenses";

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
            await Navigation.PopAsync();
        }
    }
}
