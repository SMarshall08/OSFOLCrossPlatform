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

        public SignUpView()
        {
            InitializeComponent();

            viewModel = new SignUpViewModel();
            BindingContext = viewModel;

        }
        async void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
            
    }
}
