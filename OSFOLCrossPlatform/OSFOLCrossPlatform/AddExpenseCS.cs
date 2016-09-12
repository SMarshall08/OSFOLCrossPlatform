using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.View;
using System.Diagnostics;

namespace OSFOLCrossPlatform
{
    class AddExpenseCS : ContentPage
    {
        public AddExpenseCS()
        {
            ListView customerListView;

            var LogoutItem = new ToolbarItem
            {
                Text = "Logout"
            };
            LogoutItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(LogoutItem);

            var HomeItem = new ToolbarItem
            {
                Text = "Home"
            };
            HomeItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(HomeItem);

            // Creates a label to estbalish the title
            Label Title = new Label
            {
                Text = "Add Expense",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Creates a Date Picker
            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button btnAdd = new Button
            {
                Text = "Add",
                TextColor = Color.Black
            };

            Label date = new Label
            {
                Text = "",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };
            
            customerListView = new ListView();
            customerListView.ItemTemplate = new DataTemplate
                    (typeof(Customers));
            customerListView.ItemSelected += (sender, e) =>
            {
                
                //Label customerLabel = new Label
                //{
                //    Text = "Please Select a Customer"
                //};
                var customer = (Customers)e.SelectedItem;

            };



            btnAdd.Clicked += delegate(object sender, EventArgs e)
            {
                int d = datePicker.Date.Day;
                int mon = datePicker.Date.Month;
                int year = datePicker.Date.Year;

                date.Text = d + "/" + mon + "/" + year;
             
            };

            // Creates the content that will sit inside the add Expenses page
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                    {
                        Title,
                        datePicker,
                        btnAdd,
                        date,
                        customerListView
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

        // On button click logout
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}
