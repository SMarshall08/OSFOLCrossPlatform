using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.ViewModels;
using System;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class ViewExpenseView : ContentPage
    {
        int _selectedExpenseId;
        int _loginID;
        Expense _expense;
        ExpenseInnerView viewModel;

        public ViewExpenseView(int selectedExpenseID)
        {
            _selectedExpenseId = selectedExpenseID;

            _expense = App.Database.GetEditExpense(_selectedExpenseId);
            _loginID = _expense.LoginID;

            // Create new instance of ExpenseViewModel
            viewModel = new ExpenseInnerView();

            // Bind the viewModel to this instance
            BindingContext = viewModel;

            InitializeComponent();
        }
        async void ExpenseLabel_Clicked(object sender, EventArgs e)
        {
            ExpenseSummary expense = App.Database.GetExpenses(_selectedExpenseId);
            Navigation.InsertPageBefore(new AddExpense(expense), this);
            await Navigation.PopAsync();
        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        // On button click logout
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(_loginID), this);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.FillExpenseDetails(_selectedExpenseId);

        }
    }
}
