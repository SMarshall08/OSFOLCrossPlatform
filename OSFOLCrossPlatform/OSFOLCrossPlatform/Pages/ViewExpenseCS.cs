﻿using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.Pages
{
    public partial class ViewExpenseCS : ContentPage
    {
        int _selectedExpenseId;
        ExpenseInnerView viewModel;

        public ViewExpenseCS(int aSelectedExpenseId)
        {
            
            _selectedExpenseId = aSelectedExpenseId;

            // Create new instance of ExpenseViewModel
            viewModel = new ExpenseInnerView();

            // Bind the viewModel to this instance
            BindingContext = viewModel;

            // Create the title
            var expenseLabel = new Button
            {
                Text            = "Edit Expense",
                FontAttributes  = FontAttributes.Bold
            };
            expenseLabel.Clicked += ExpenseLabel_Clicked;
            

            var expenseStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children    = {
                                expenseLabel
                              },
                HorizontalOptions   = LayoutOptions.CenterAndExpand,
                VerticalOptions     = LayoutOptions.StartAndExpand
            };

            #region Create Expense Labels

            var expenseSetNameLabel = new Label
            {
                Text = "Expense Set Name:"
            };
            
            var expenseDateLabel = new Label
            {
                Text = "Date:"
            };
            var expenseCustomerLabel = new Label
            {
                Text = "Customer:"
            };
            var expenseCustomerContactLabel = new Label
            {
                Text = "Customer Contact:"
            };
            var expenseSalesOppLabel = new Label
            {
                Text = "Sales Opportunity:"
            };
            var expenseTypeLabel = new Label
            {
                Text = "Expense Type:"
            };
            var expenseLocationFromLabel = new Label
            {
                Text = "Location From:"
            };
            var expenseLocationToLabel = new Label
            {
                Text = "Location To:"
            };
            var expenseDetailsLabel = new Label
            {
                Text = "Details:"
            };
            var expenseVendorLabel = new Label
            {
                Text = "Vendor:"
            };
            var expenseExpenseMethodLabel = new Label
            {
                Text = "Expense Method:"
            };
            var expenseCurrencyLabel = new Label
            {
                Text = "Currency:"
            };
            var expenseExchangeRateLabel = new Label
            {
                Text = "Exchange Rate:"
            };
            var expenseAmountLabel = new Label
            {
                Text = "Amount:"
            };
            var expenseAmountCurLabel = new Label
            {
                Text = "Amount Cur:"
            };
            var expenseReceiptImageLabel = new Label
            {
                Text = "Receipt Image:"
            };
            #endregion

            #region Create Labels for the Expense Data
            var expenseSetNameData = new Label();
            expenseSetNameData.SetBinding(Label.TextProperty, "ExpenseSetName");

            var expenseDateData= new Label();
            expenseDateData.SetBinding(Label.TextProperty, "CreatedDT");

            var expenseCustomerData = new Label();
            expenseCustomerData.SetBinding(Label.TextProperty, "Customer");

            var expenseCustomerContactData = new Label();
            expenseCustomerContactData.SetBinding(Label.TextProperty, "Contact");

            var expenseSalesOppData = new Label();
            expenseSalesOppData.SetBinding(Label.TextProperty, "Opportunity");

            var expenseTypeData = new Label();
            expenseTypeData.SetBinding(Label.TextProperty, "rfExpenseType");

            var expenseLocationFromData = new Label();
            expenseLocationFromData.SetBinding(Label.TextProperty, "LocationFrom");

            var expenseLocationToData = new Label();
            expenseLocationToData.SetBinding(Label.TextProperty, "LocationTo");

            var expenseDetailsData = new Label();
            expenseDetailsData.SetBinding(Label.TextProperty, "ExpenseDetails");

            var expenseVendorData = new Label();
            expenseVendorData.SetBinding(Label.TextProperty, "Vendor");

            var expenseExpenseMethodData = new Label();
            expenseExpenseMethodData.SetBinding(Label.TextProperty, "rfExpenseMethod");

            var expenseCurrencyData = new Label();
            expenseCurrencyData.SetBinding(Label.TextProperty, "rfCurrency");

            var expenseExchangeRateData = new Label();
            expenseExchangeRateData.SetBinding(Label.TextProperty, "ExchangeRate");

            var expenseAmountData = new Label();
            expenseAmountData.SetBinding(Label.TextProperty, "ExpenseAmount");

            var expenseAmountCurData = new Label();
            expenseAmountCurData.SetBinding(Label.TextProperty, "ExpenseAmountCur");

            var expenseReceiptImageData = new Image();
            expenseReceiptImageData.SetBinding(Image.SourceProperty, "ReceiptImageUri");
            #endregion

            #region Create & Populate Grid
            var dataGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions   = LayoutOptions.Start,
                RowDefinitions    = {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            dataGrid.Children.Add(expenseSetNameLabel,          0, 0);
            dataGrid.Children.Add(expenseDateLabel,             0, 1);
            dataGrid.Children.Add(expenseCustomerLabel,         0, 2);
            dataGrid.Children.Add(expenseCustomerContactLabel,  0, 3);
            dataGrid.Children.Add(expenseSalesOppLabel,         0, 4);
            dataGrid.Children.Add(expenseTypeLabel,             0, 5);
            dataGrid.Children.Add(expenseLocationFromLabel,     0, 6);
            dataGrid.Children.Add(expenseLocationToLabel,       0, 7);
            dataGrid.Children.Add(expenseDetailsLabel,          0, 8);
            dataGrid.Children.Add(expenseVendorLabel,           0, 9);
            dataGrid.Children.Add(expenseExpenseMethodLabel,    0, 10);
            dataGrid.Children.Add(expenseCurrencyLabel,         0, 11);
            dataGrid.Children.Add(expenseExchangeRateLabel,     0, 12);
            dataGrid.Children.Add(expenseAmountLabel,           0, 13);
            dataGrid.Children.Add(expenseAmountCurLabel,        0, 14);
            dataGrid.Children.Add(expenseReceiptImageLabel,     0, 15);

            dataGrid.Children.Add(expenseSetNameData,           1, 0);  
            dataGrid.Children.Add(expenseDateData,              1, 1);
            dataGrid.Children.Add(expenseCustomerData,          1, 2);
            dataGrid.Children.Add(expenseCustomerContactData,   1, 3);
            dataGrid.Children.Add(expenseSalesOppData,          1, 4);
            dataGrid.Children.Add(expenseTypeData,              1, 5);
            dataGrid.Children.Add(expenseLocationFromData,      1, 6);
            dataGrid.Children.Add(expenseLocationToData,        1, 7);
            dataGrid.Children.Add(expenseDetailsData,           1, 8);
            dataGrid.Children.Add(expenseVendorData,            1, 9);
            dataGrid.Children.Add(expenseExpenseMethodData,     1, 10);
            dataGrid.Children.Add(expenseCurrencyData,          1, 11);
            dataGrid.Children.Add(expenseExchangeRateData,      1, 12);
            dataGrid.Children.Add(expenseAmountData,            1, 13);
            dataGrid.Children.Add(expenseAmountCurData,         1, 14);
            dataGrid.Children.Add(expenseReceiptImageData,      1, 15);
            #endregion

            var expenseScrollView = new ScrollView
            {
                Content = dataGrid
            };

            #region Toolbar
            var toolbarItem = new ToolbarItem
            {
                Text = "Logout"
            };
            toolbarItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(toolbarItem);

            var homebarItem = new ToolbarItem
            {
                Text = "Home"
            };
            homebarItem.Clicked += OnHomeButtonClicked;
            ToolbarItems.Add(homebarItem);

            Title = "View Expense";
            #endregion

            var expenseListStack = new StackLayout
            {
                Children = {
                    expenseStack,
                    expenseScrollView
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            Content = expenseListStack;
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
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.FillExpenseDetails(_selectedExpenseId);
            
        }

    }
}
