using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Controls.DefaultControls
{
    public class DefaultLabel : Label
    {
        public DefaultLabel()
        {
            VerticalOptions = LayoutOptions.Center;
            TextColor = Color.White;
            FontSize = Device.GetNamedSize(NamedSize.Medium, this);
        }

        public NamedSize CustomFontSize
        {
            set { FontSize = Device.GetNamedSize(value, this); }
        }
    }
}
