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
                Scale = 1

            };
            #endregion

            #region Create Month Stack
            var month = new Label
            {
                FontSize = 24
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
                    Spacing = 50,
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
