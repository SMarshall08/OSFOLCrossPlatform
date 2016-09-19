using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public class AddExpenseViewCell : ViewCell
    {
        ListView customerListView;

        public AddExpenseViewCell()
        {

            #region Create DatePicker
            // Creates a Date Picker
            DatePicker datePicker = new DatePicker
            {
                Format = "dd-mm-yyyy",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            #endregion
        }
    }
}
