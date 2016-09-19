﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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
            var lighthouseImage = new Image
            {
                Source = "lighthouseicon"
            };
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

            #region Create Customer Stack
            var customerLabel = new Label
            {
                Text = "CustomerID",
                FontAttributes = FontAttributes.Bold
            };
            var customer = new Label();
            customer.SetBinding(Label.TextProperty, "CustomersID");

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
                Text = "SaleOpportunityID",
                FontAttributes = FontAttributes.Bold
            };
            var opportunity = new Label();
            opportunity.SetBinding(Label.TextProperty, "SaleOpportunityID");

            var opportunityStack = new StackLayout
            {
                Children = {
                    opportunityLabel,
                    opportunity
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
                customer.LineBreakMode = LineBreakMode.NoWrap;
                cellStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = 10,
                    Spacing = 20,
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        lighthouseImage,
                        expenseStack
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
                        expenseStack,
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
