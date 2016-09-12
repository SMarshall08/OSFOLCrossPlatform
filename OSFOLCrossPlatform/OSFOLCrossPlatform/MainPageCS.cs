using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.View;

namespace OSFOLCrossPlatform
{
    class MainPageCS : ContentPage
    {
        public MainPageCS()
        {
            var toolbarItem = new ToolbarItem
            {
                Text = "Logout"
            };
            toolbarItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(toolbarItem);

            Title = "Main Page";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Main app content goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },
                    new Button
                    {
                        Text = "Add Expense",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },
                    new Button
                    {
                        Text = "View & Edit Expense",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    },
                    new Button
                    {
                        Text = "Expenses Report",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
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

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPageCS(), this);
            await Navigation.PopAsync();
        }
    }
}
