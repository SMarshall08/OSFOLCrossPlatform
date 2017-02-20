using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Data;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform.Pages
{
    public class ExpensesPage : ContentPage
    {
        int _loginID;
        int _expenseID;
        int _monthID;

        ListView _listView;
        ExpensesViewModel _expensesViewModel;
        ToolbarItem _addButtonToolBar;
        ToolbarItem _logoutButtonToolBar;
        ToolbarItem _homeButtonToolBar;
        ToolbarItem _deleteButtonToolBar;
        bool _areEventHandlersSubscribed;

        public ExpensesPage(int loginID, int monthID)
        {
            _loginID = loginID;
            _monthID = monthID;

            _expensesViewModel = new ExpensesViewModel(_loginID, _monthID);
            BindingContext = _expensesViewModel;

            #region Create the ListView
            _listView = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(ExpensesViewCell)),
                RowHeight = 75
            };

            _listView.IsPullToRefreshEnabled = true;
            _listView.Refreshing += (async (sender, e) =>
            {
                await _expensesViewModel.RefreshExpensesDataAsync(_loginID,_monthID);
                _listView.EndRefresh();
            });

            _listView.ItemSelected += (sender, e) =>
            {
                var expense = e.SelectedItem as Expense;
                _expenseID = expense.ExpenseID;
                Navigation.PushAsync(new ViewExpenseCS(_expenseID));
            };

            _listView.SetBinding(ListView.ItemsSourceProperty, "AllExpensesData");
            #endregion

            Title = $"Expenses";

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
            searchBar.TextChanged += (sender, e) => _expensesViewModel.FilterExpenses(searchBar.Text,_loginID,_monthID);
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
            Navigation.PushModalAsync(new NavigationPage(new AddExpense(_loginID)));
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            await Navigation.PushAsync(new LoginPage());
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }

    }
}
