using OSFOLCrossPlatform.View;
using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using System.Diagnostics;
using OSFOLCrossPlatform.ViewModels;

namespace OSFOLCrossPlatform.View
{
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            InitializeComponent();
            this.BindingContext = new AddExpenseViewModel();
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
        }

        void customerListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var customer = (Customers)e.SelectedItem;

            ((App)App.Current).ResumeAtExpenseId = customer.CustomerID;
            Debug.WriteLine("setting ResumeAtExpenseId = " + customer.CustomerID);

        }
    }
}
