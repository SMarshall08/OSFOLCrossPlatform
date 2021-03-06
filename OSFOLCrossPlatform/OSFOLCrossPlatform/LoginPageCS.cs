﻿using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.Infrastructure;

namespace OSFOLCrossPlatform
{
    public class LoginPageCS : ContentPage
    {
        Entry usernameEntry, passwordEntry;
        Label messageLabel;

        public LoginPageCS()
        {
            messageLabel = new Label();
            usernameEntry = new Entry
            {
                Placeholder = "username"
            };
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            var loginButton = new Button
            {
                Text = "Login"
            };
            loginButton.Clicked += OnLoginButtonClicked;

            Title = "Login";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Username" },
                    usernameEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    loginButton,
                    messageLabel
                }
            };
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Login
            {
                UserName = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPageCS(), this);
                await Navigation.PopAsync();
            }
            else {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(Login user)
        {
            return user.UserName == user.UserName && user.Password == user.Password;
        }
    }
}
