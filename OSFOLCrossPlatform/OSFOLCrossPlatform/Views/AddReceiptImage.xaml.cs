using OSFOLCrossPlatform.Model;
using System;
using Xamarin.Forms;
using OSFOLCrossPlatform.ViewModels;
using OSFOLCrossPlatform.Pages;
using Plugin.Media;

namespace OSFOLCrossPlatform.Views
{
    public partial class AddReceiptImage : ContentPage
    {
        public int _loginID;
        int _expenseSetID;
        Expense _expense;
        string _receiptImageUri;

        public AddReceiptImage(int loginID)
        {
            InitializeComponent();

            _loginID = loginID;
        }
        public AddReceiptImage(Expense expense)
        {
            InitializeComponent();

            _expense = expense;
            
        }

        public AddReceiptImage(int loginID, int expenseSetID)
        {
            InitializeComponent();

            _loginID      = loginID;
            _expenseSetID = expenseSetID;
        }

        public AddReceiptImage()
        {

        }

        /// <summary>
        /// Method to allow the photo to be accesses and take a photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void TakePictureButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable
                            || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            // Choose to save the photo to camera album instead of pre-defining a location
            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });

            if (file == null)
                return;

            ReceiptImageUri.Text = file.AlbumPath;
            _receiptImageUri = file.AlbumPath;

            ReceiptImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        /// <summary>
        /// Method to select a pre taken photo from device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SelectPictureButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ooops", "Select Photo is Not Supporter", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;


            ReceiptImageUri.Text = file.Path;
            _receiptImageUri = file.Path;

            ReceiptImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

        }

        // On button click logout
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }


        // On button click go back to main page
        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_loginID));
        }

        // On button click go to expense report page to view most recent expense added
        async void NextButton_OnClicked(object sender, EventArgs e)
        {
            if(_expense != null)
            {
                _expense.ReceiptImageUri = _receiptImageUri;
                Navigation.InsertPageBefore(new AddExpense(_expense), this);
                await Navigation.PopAsync();
            }
            else if (_expenseSetID > 0)
            {
                Navigation.InsertPageBefore(new AddExpense(_loginID,_expenseSetID,_receiptImageUri), this);
                await Navigation.PopAsync();
            }
            else
            {
                string receiptImageUri = Convert.ToString(_receiptImageUri);
                Navigation.InsertPageBefore(new AddExpense(_loginID, receiptImageUri), this);
                await Navigation.PopAsync();
            }
                
        }
    }
}
