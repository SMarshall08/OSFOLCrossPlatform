using OSFOLCrossPlatform.Model;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform.Views
{
    public class ExpensesViewCell : ViewCell
    {
        public ExpensesViewCell()
        {
            #region Create Image
            //var lighthouseImage = new Image
            //{
            //    Source  = "lighthouseicon",
            //    Scale   = 0.5

            //};

            var lighthouseImage = new Image
            {
                Scale = 0.75
            };
            lighthouseImage.SetBinding(Image.SourceProperty, "ReceiptImageUri");
            #endregion

            #region Create Expense Stack
            var expenseLabel = new Label
            {
                Text = "Expense",
                FontAttributes = FontAttributes.Bold
            };
            var expense = new Label();
            expense.SetBinding(Label.TextProperty, "ExpenseDetails");

            var expenseStack = new StackLayout
            {
                Children = {
                    expenseLabel,
                    expense
                }
            };
            #endregion

            #region Create Date Stack
            var dateLabel = new Label
            {
                Text = "Date",
                FontAttributes = FontAttributes.Bold
            };
            var date = new Label();
            date.SetBinding(Label.TextProperty, "CreatedDT");

            var dateStack = new StackLayout
            {
                Children = {
                    dateLabel,
                    date
                }
            };
            #endregion

            #region Create Amount Stack
            var amountLabel = new Label
            {
                Text = "Amount (£)",
                FontAttributes = FontAttributes.Bold
            };
            var amount = new Label();
            amount.SetBinding(Label.TextProperty, "ExpenseAmount");

            var amountStack = new StackLayout
            {
                Children = {
                    amountLabel,
                    amount
                }
            };
            #endregion

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
                Expense thisModel = ((Expense)menuItem.BindingContext);
                App.Database.DeleteItem(thisModel.ExpenseID);

                //Wait for the iOS animation to finish
                if (Device.OS == TargetPlatform.iOS)
                    await Task.Delay(300);

                MessagingCenter.Send<object>(this, "RefreshData");
            };
            ContextActions.Add(deleteAction);
            #endregion

            StackLayout cellStack;
            #region Create Cell Horizontal StackLayout for Phone
            if (Device.Idiom == TargetIdiom.Phone)
            {
                //customer.LineBreakMode = LineBreakMode.NoWrap;
                cellStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = 10,
                    Spacing = 40,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        lighthouseImage,
                        expenseStack,
                        dateStack,
                        amountStack

                    }
                };
            }
            #endregion

            #region Create Cell Horizontal StackLayout for Tablet or Desktop
            else
            {
                cellStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = 10,
                    Spacing = 40,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        lighthouseImage,
                        expenseStack,
                        dateStack,
                        amountStack

                    }
                };
            }
            #endregion

            View = cellStack;
        }
    }
}
