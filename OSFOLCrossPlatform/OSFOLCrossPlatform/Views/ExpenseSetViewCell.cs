using OSFOLCrossPlatform.Model;
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

            #region Create MenuItem
            var deleteAction = new MenuItem
            {
                Text = "Delete",
                IsDestructive = true
            };
            deleteAction.SetBinding(MenuItem.CommandProperty, "DeleteActionSelected");

            deleteAction.Clicked += async (sender, e) =>
            {
                var menuItem = (MenuItem)sender;
                ExpenseSet thisModel = ((ExpenseSet)menuItem.BindingContext);
                App.Database.DeleteItem(thisModel);

                //Wait for the iOS animation to finish
                if (Device.OS == TargetPlatform.iOS)
                    await Task.Delay(300);

                MessagingCenter.Send<object>(this, "RefreshData");
            };
            ContextActions.Add(deleteAction);
            #endregion


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
