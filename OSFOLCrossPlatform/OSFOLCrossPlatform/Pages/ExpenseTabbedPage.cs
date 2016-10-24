using Xamarin.Forms;
using OSFOLCrossPlatform.Views;

namespace OSFOLCrossPlatform.Pages
{
    public class ExpenseTabbedPage : TabbedPage
    {
        public ExpenseTabbedPage(int loginID)
        {
            Title = "Add Expense";

            this.Children.Add(new AddExpense(loginID));
            this.Children.Add(new AddTypeExpenseView(loginID));
            this.Children.Add(new AddCostingExpenseView(loginID));
        }
    }
}
