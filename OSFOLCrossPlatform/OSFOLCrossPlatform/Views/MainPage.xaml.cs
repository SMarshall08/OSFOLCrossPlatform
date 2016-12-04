using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.Pages;

namespace OSFOLCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public int _loginid;
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(int loginID)
        {
            _loginid = loginID;
            InitializeComponent();
        }
        
        // On Button click navigate to Add Expense page
        async void OnAddExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new ExpenseTabbedPage(_loginid), this);
            await Navigation.PopAsync();
        }

        // On Button click navigate to Add Quick Expense page
        async void OnAddQuickExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddQuickExpense(), this);
            await Navigation.PopAsync();
        }

        // On Button click navigate to view report page
        async void OnReportButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new ExpensesPage(_loginid), this);
            await Navigation.PopAsync();
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
