using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Pages;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddExpenseSet : ContentPage
    {
        public int _loginID;

        AddExpenseSetViewModel viewModel;

        public AddExpenseSet(int loginID)
        {
            InitializeComponent();

            _loginID = loginID;

            viewModel = new AddExpenseSetViewModel(_loginID);
            BindingContext = viewModel;
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(_loginID),this);
            await Navigation.PopAsync();
        }

        // On button click go back to expense set
        async void AddExpenseSetButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseSetsPage(_loginID));
        }

        // On button click go to expense report page to view most recent expense added
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //Navigation.InsertPageBefore(new ExpenseSetsPage(_loginID), this);
            //await Navigation.PushAsync(new ExpenseSetsPage(_loginID));
            await Navigation.PushModalAsync(new ExpenseSetsPage(_loginID));
            //await Navigation.PopAsync();

            ExpenseSetEntry.Text        = string.Empty;
            ExpenseSetFromDTPicker.Date = DateTime.Now;
            ExpenseSetToDTPicker.Date   = DateTime.Now;
        }

        // Get all data from database on page appearing
        protected override void OnAppearing()
        {
            ExpenseSetEntry.Text = "";

            ExpenseSetFromDTPicker.Date = DateTime.Now;
            ExpenseSetToDTPicker.Date   = DateTime.Now;

            int minusOneMonthFromNow = DateTime.Now.Month - 1;
            int firstDayOfMonth = 1;
            int year = DateTime.Now.Year;
            string minDate = "0" + firstDayOfMonth + "/0" + minusOneMonthFromNow + "/" + year;
            ExpenseSetFromDTPicker.MinimumDate = Convert.ToDateTime(minDate);
            ExpenseSetToDTPicker.MinimumDate = DateTime.Now;
        }
    }
}
