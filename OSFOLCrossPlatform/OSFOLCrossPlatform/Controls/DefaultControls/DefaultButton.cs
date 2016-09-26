using OSFOLCrossPlatform.Styles;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Controls.DefaultControls
{
    public class DefaultButton : Button
    {
        public DefaultButton()
        {
            BackgroundColor = StyleManager.AccentColor;
            TextColor = StyleManager.MainColor;
            HorizontalOptions = LayoutOptions.Fill;
            HeightRequest = 35;
            FontAttributes = FontAttributes.Bold;
        }
    }
}
