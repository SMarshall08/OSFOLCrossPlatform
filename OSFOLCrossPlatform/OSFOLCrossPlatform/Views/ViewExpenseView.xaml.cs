using CsvHelper;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.ViewModels;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.Messaging;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.FillExpenseDetails(_selectedExpenseId);

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

        public static IEnumerable<ExpenseSummary> QueryExpense( int expenseId)
        {
           return App.Database.GetExpenseSummary(expenseId);
        }

        async void CSVButton_Clicked(object sender, EventArgs e)
        {
            // initialize expense string empty
            string allExpenses = @" 
Created Date, Customer, Contact, Opportunity, Location From, Location To, Expense Type, Expense Method, Expense Details, Vendor, Currency, Exchange Rate, Expense Amount Currency, Expense Amount";
            // go through each expense
            foreach (ExpenseSummary expense in QueryExpense(_selectedExpenseId))
            {

                // compile a CSV string for this entry
                string expenseText = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                    expense.CreatedDT, expense.Customer,expense.Contact,expense.Opportunity,expense.LocationFrom,expense.LocationTo,
                    expense.rfExpenseType,expense.rfExpenseMethod,expense.ExpenseDetails,expense.Vendor,expense.rfCurrency, expense.ExchangeRate,
                    expense.ExpenseAmountCur, expense.ExpenseAmount);
                // append it to the list of all expenses with a carriage return/linefeed (new line)
                allExpenses = string.Format("{0}\r\n{1}", allExpenses, expenseText);
            }
            //string filename = "Expense.csv";
            //string filePath = DependencyService.Get<ISaveAndLoad>().SaveText(filename, allExpenses);

            // create an instance of an email messenger
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            
            // create email
            var email = new EmailMessageBuilder()
             .To("")
            .Subject("Expenses")
            .Body(allExpenses)
            .Build();

            // send email
            emailMessenger.SendEmail(email);
        }



        


    }
}
