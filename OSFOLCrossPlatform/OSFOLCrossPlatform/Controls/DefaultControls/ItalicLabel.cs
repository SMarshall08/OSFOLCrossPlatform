using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Controls.DefaultControls
{
    internal class ItalicLabel : DefaultLabel 
    {
        public ItalicLabel()
        {
            HorizontalOptions = LayoutOptions.Center;
            FontAttributes = FontAttributes.Italic;
        }
    }
}
