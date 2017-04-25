using OSFOLCrossPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public partial class SignUpView : ContentPage
    {
        SignUpViewModel viewModel;
        string _securityPin;

        public SignUpView()
        {
            InitializeComponent();

            _securityPin = securityPinEntry.Text;

            // Bind view model with the contents page passing through the security pin
            viewModel = new SignUpViewModel();
            BindingContext = viewModel;

        }
        /// <summary>
        /// Upon sign up, system checks if security pin is correct and navigates back to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SignUpSaveButton_OnClicked(object sender, EventArgs e)
        {
            
            var isValid = AreCredentialsCorrect(_securityPin);

            // If true continue
            if (isValid)
            {
                await Navigation.PushAsync(new LoginPage());
            }
            else {
                messageLabel.Text = "Security Pin Incorrect";
                securityPinEntry.Text = string.Empty;
            }
            
        }
        
        /// <summary>
        /// Checks to see if the security pin entered is correct to what has be
        /// </summary>
        /// <param name="securityPin"></param>
        /// <returns></returns>
        bool AreCredentialsCorrect(string securityPin)
        {
            if (securityPinEntry.Text == DateTime.Now.Year.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
