using OSFOLCrossPlatform.Styles;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Controls.DefaultControls
{
    public class DefaultEntry : Entry
    {
        public DefaultEntry()
        {
            BackgroundColor = StyleManager.DarkAccentColor;
            TextColor = StyleManager.AccentColor;
            HorizontalOptions = LayoutOptions.Fill;
            HeightRequest = 40;
        }
    }
}
