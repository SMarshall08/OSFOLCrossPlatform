using OSFOLCrossPlatform.ViewModels;
using System;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddContactView : ContentPage
    {
        int _loginID;
        AddContactViewModel viewModel;


        public AddContactView(int loginID)
        {
            InitializeComponent();
            _loginID = loginID;

            viewModel = new AddContactViewModel();
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
            Navigation.InsertPageBefore(new MainPage(_loginID), this);
            await Navigation.PopAsync();
        }

        // On button click go to expense report page to view most recent expense added
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AdminView(_loginID), this);
            await Navigation.PopAsync();
        }

        // On button click, clear all values to add new expense
        public void OnNextButtonClicked(Object sender, EventArgs e)
        {
            customerListView.SelectedIndex = -1;
            FirstNameEntry.Text = "";
            LastNameEntry.Text = "";
        }

        // Get all data from database on page appearing
        protected override void OnAppearing()
        {
            customerListView.ItemsSource = App.Database.GetCustomers();
        }
    }
}
