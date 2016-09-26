using OSFOLCrossPlatform.Styles;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Pages.Base
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            Title = "OSFOL Expense app";
            BackgroundColor = StyleManager.MainColor;
            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
