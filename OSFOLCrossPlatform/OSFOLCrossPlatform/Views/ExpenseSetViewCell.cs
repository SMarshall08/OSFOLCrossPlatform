using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public class ExpenseSetViewCell : ViewCell
    {
        public ExpenseSetViewCell()
        {
            #region Create Image
            var lighthouseImage = new Image
            {
                Source = "lighthouseicon",
                Scale = 0.8

            };
            #endregion

            #region Create Expense Set Stack
            var expenseSet = new Label
            {
                FontSize = 16
            };
            expenseSet.SetBinding(Label.TextProperty, "ExpenseSetName");

            var expenseSetStack = new StackLayout
            {
                Children = {
                    expenseSet
                }
            };


            #endregion

            StackLayout cellStack;
            #region Create Cell Horizontal StackLayout
            cellStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                Padding = 10,
                Spacing = 20,
                Orientation = StackOrientation.Horizontal,
                Children = {
                        lighthouseImage,
                        expenseSetStack
                    }
            };


            #endregion

            View = cellStack;
        }
    }
}
