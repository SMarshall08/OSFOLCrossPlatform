using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.View;

namespace OSFOLCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        // On Button click navigate to Add Expense page
        async void OnAddExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddExpense(), this);
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
            Navigation.InsertPageBefore(new Report(), this);
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
