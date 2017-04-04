using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.Pages;

namespace OSFOLCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        Login _login;
        public int _loginid;

        public MainPage()
        {
            InitializeComponent();

            _login = App.Database.GetLoginName(_loginid);
            string firstName = _login.FirstName;
            string lastName = _login.LastName;

            Title = firstName + " " + lastName + " Expense Tracker";
        }

        public MainPage(int loginID)
        {
            _loginid = loginID;
            InitializeComponent();

            _login = App.Database.GetLoginName(_loginid);
            string firstName = _login.FirstName;
            string lastName = _login.LastName;

            Title = firstName + " " + lastName + " Expense Tracker";
        }
        
        // On Button click navigate to Add Expense page
        async void OnAddExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddExpense(_loginid), this);
            await Navigation.PopAsync();
        }

        // On button click, user will navigate to monthly report view 
        async void MonthExpenseReport_OnClicked (object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MonthExpensesPage(_loginid), this);
            await Navigation.PopAsync();
        }

        // On button click, user will navigate to Expense Set report view 
        async void ExpenseSetReport_OnClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ExpenseSetsPage(_loginid));
            await Navigation.PushAsync(new ExpenseSetsPage(_loginid));
            //await Navigation.PushAsync();
        }

        // On button click, user will navigate to Expense Set report view 
        async void AddExpenseSetButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddExpenseSet(_loginid), this);
            await Navigation.PopAsync();
        }

        // On button click navigate to Receipt Capture page, where user can take photo and attach to expense
        async void ReceiptImageButton_OnClicked (object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddReceiptImage(_loginid), this);
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
