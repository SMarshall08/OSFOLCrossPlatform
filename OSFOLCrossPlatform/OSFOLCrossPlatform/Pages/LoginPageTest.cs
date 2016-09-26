using OSFOLCrossPlatform.Controls.DefaultControls;
using OSFOLCrossPlatform.Pages.Base;
using OSFOLCrossPlatform.Styles;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Pages
{
    internal class LoginPageTest : BaseContentPage
    {
        private enum Mode { Login, Signup }
        private Mode currentMode;
        private DefaultButton submitButton;
        private DefaultEntry emailTextBox;
        private DefaultEntry passwordTextBox;

        public LoginPageTest()
        {
            // Status bar for iOS.
            var statusBar = new BoxView();
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android) 
            {
                statusBar.BackgroundColor = StyleManager.DarkAccentColor;
                statusBar.HeightRequest = 20;
            }

            // Application title & subtitle.
            var titleString = new FormattedString();
            titleString.Spans.Add(new Span { ForegroundColor = StyleManager.AccentColor, FontAttributes = FontAttributes.Italic, FontSize = 40, Text = "OSFOL Expense" });
            titleString.Spans.Add(new Span { ForegroundColor = StyleManager.DarkAccentColor, FontAttributes = FontAttributes.Italic, FontSize = 32, Text = "app" });

            var title = new DefaultLabel { FormattedText = titleString, HorizontalOptions = LayoutOptions.Center };

            var subtitle = new ItalicLabel { Text = "Simply Better Manufacturing Performance", TextColor = StyleManager.AccentColor };

            var titleLayout = new StackLayout
            {
                Children = { title, subtitle },
                Spacing = 2,
                Padding = new Thickness(0, 30)
            };
        }
    }
}
