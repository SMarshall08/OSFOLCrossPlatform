using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Views;

namespace OSFOLCrossPlatform.Pages
{
    class EditExpenseCS : ContentPage
    {
        public EditExpenseCS()
        {
            var toolbarItem = new ToolbarItem
            {
                Text = "Logout"
            };
            toolbarItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(toolbarItem);

            Title = "Edit Expense";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Edit Expense app content goes here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                        }
                }
            };
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
