using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;

namespace OSFOLCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public int loginid;
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(int loginID)
        {
            loginid = loginID;
            InitializeComponent();
        }
        
        // On Button click navigate to Add Expense page
        async void OnAddExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddExpense(loginid), this);
            await Navigation.PopAsync();
        }

        // On Button click navigate to Add Quick Expense page
        async void OnAddQuickExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddQuickExpense(), this);
            await Navigation.PopAsync();
        }

        // On Button click navigate to View/Edit expenses page
        async void OnEditExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new EditExpense(), this);
            await Navigation.PopAsync();
        }

        // On Button click navigate to view report page
        async void OnReportButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new ExpensesPage(loginid), this);
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
