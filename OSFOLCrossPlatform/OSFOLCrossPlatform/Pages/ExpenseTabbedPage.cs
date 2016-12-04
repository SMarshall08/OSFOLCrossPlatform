using Xamarin.Forms;
using OSFOLCrossPlatform.Views;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.Pages
{
    public class ExpenseTabbedPage : TabbedPage
    {
        public int _loginID;
        public ExpenseTabbedPage(int loginID)
        {
            _loginID = loginID;

            Title = "Add Expense";

            this.Children.Add(new AddExpense(loginID));
            this.Children.Add(new AddTypeExpenseView(loginID));
            this.Children.Add(new AddCostingExpenseView(loginID));
        }

        //public ExpenseTabbedPage(ExpenseSummary expenseSummary)
        //{
        //    Title = "Edit Expense";

        //    this.Children.Add(new AddExpense(loginID));
        //    this.Children.Add(new AddTypeExpenseView(loginID));
        //    this.Children.Add(new AddCostingExpenseView(loginID));
        //}
    }
}
