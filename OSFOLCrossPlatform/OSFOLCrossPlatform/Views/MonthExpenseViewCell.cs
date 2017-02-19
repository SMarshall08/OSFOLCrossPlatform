using OSFOLCrossPlatform.Model;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform.Views
{
    public class MonthExpenseViewCell : ViewCell
    {
        public MonthExpenseViewCell()
        {
            #region Create Image
            var lighthouseImage = new Image
            {
                Source = "lighthouseicon",
                Scale = 0.8

            };
            #endregion

            #region Create Month Stack
            var month = new Label
            {
                FontSize = 16
            };
            month.SetBinding(Label.TextProperty, "Month");

            var monthStack = new StackLayout
            {
                Children = {
                    month
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
                        monthStack
                    }
                };


            #endregion

            View = cellStack;
        }



    }
}
