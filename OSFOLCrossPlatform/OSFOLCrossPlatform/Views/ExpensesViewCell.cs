using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public class ExpensesViewCell : ViewCell
    {
        public ExpensesViewCell()
        {
            #region Create Image
            var lighthouseImage = new Image
            {
                Source = "lighthouseicon"
            };
            #endregion

            #region Create Expense Stack
            //var expenseLabel = new Label
            //{
            //    Text = "Expense",
            //    FontAttributes = FontAttributes.Bold
            //};
            //var expense = new Label();
            //expense.SetBinding(Label.TextProperty, "Expense");

            //var texpenseStack = new StackLayout
            //{
            //    Children = {
            //        expenseLabel,
            //        expense
            //    }
            //};
            #endregion

            #region Create Customer Stack
            var customerLabel = new Label
            {
                Text = "Customers",
                FontAttributes = FontAttributes.Bold
            };
            var customer = new Label();
            customer.SetBinding(Label.TextProperty, "Customers");

            var customerStack = new StackLayout
            {
                Children = {
                    customerLabel,
                    customer
                }
            };
            #endregion

            #region Create Opportunity Stack
            var opportunityLabel = new Label
            {
                Text = "Opportunity",
                FontAttributes = FontAttributes.Bold
            };
            var opportunity = new Label();
            opportunity.SetBinding(Label.TextProperty, "Opportunity");

            var opportunityStack = new StackLayout
            {
                Children = {
                    opportunityLabel,
                    opportunity
                }
            };
            #endregion

            StackLayout cellStack;
            #region Create Cell Horizontal StackLayout for Phone
            if (Device.Idiom == TargetIdiom.Phone)
            {
                customer.LineBreakMode = LineBreakMode.NoWrap;
                cellStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = 10,
                    Spacing = 20,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        lighthouseImage,
                        customerStack
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
                    Spacing = 20,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        lighthouseImage,
                        customerStack,
                        opportunityStack
                    }
                };
            }
            #endregion

            View = cellStack;
        }
    }
}
