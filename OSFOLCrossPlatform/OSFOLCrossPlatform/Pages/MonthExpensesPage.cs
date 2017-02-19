using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Views;
using System;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Pages
{
    public class MonthExpensesPage : ContentPage
    {
        int _loginID;
        int _monthID;

        ListView _monthListView;
        MonthExpenseViewModel _monthexpensesViewModel;
        ToolbarItem _addButtonToolBar;
        ToolbarItem _logoutButtonToolBar;
        ToolbarItem _homeButtonToolBar;
        private bool _areEventHandlersSubscribed;

        public MonthExpensesPage(int loginID)
        {
            _loginID = loginID;
            _monthexpensesViewModel = new MonthExpenseViewModel(_loginID);
            BindingContext = _monthexpensesViewModel;

            #region Create the ListView
            _monthListView = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(MonthExpenseViewCell)),
                RowHeight = 50
            };

            _monthListView.ItemSelected += (sender, e) =>
            {
                var month = e.SelectedItem as ExpenseMonth;
                _monthID = month.MonthID;
                Navigation.PushAsync(new ExpensesPage(loginID,_monthID));
            };

            _monthListView.SetBinding(ListView.ItemsSourceProperty, "AllMonthData");
            #endregion

            Title = $"Month Expenses";

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

            #region Create Stack
            var listStack = new StackLayout
            {
                Padding = 0,
                Spacing = 0,
                Children = {
                    _monthListView
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
            Navigation.PushModalAsync(new NavigationPage(new AddExpense(_loginID)));
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
