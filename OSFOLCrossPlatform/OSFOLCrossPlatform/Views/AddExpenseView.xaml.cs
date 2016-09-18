using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using System.Diagnostics;
using OSFOLCrossPlatform.ViewModels;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            InitializeComponent();
            BindingContext = new AddExpenseViewModel();
        }

        public AddExpense(int loginID)
        {
            InitializeComponent();
            BindingContext = new AddExpenseViewModel(loginID);
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            customerListView.ItemsSource = App.Database.GetCustomers();
            opportunityListView.ItemsSource = App.Database.GetOpportunities();
            
        }

        void customerListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var customer = (Customers)e.SelectedItem;

            //((App)App.Current).ResumeAtExpenseId = customer.CustomerID;
            Debug.WriteLine("setting customer ID = " + customer.CustomerID);
        }

        void opportunityListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var opportunity = (SalesOpportunity)e.SelectedItem;

            //((App)App.Current).ResumeAtExpenseId = customer.CustomerID;
            Debug.WriteLine("setting sales opportunity ID = " + opportunity.SalesOpportunityID);
        }
    }
}
