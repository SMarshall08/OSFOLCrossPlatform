using Xamarin.Forms;

namespace OSFOLCrossPlatform.Views
{
    public class ExpenseTabbedPage : TabbedPage
    {
        public ExpenseTabbedPage(int loginID)
        {
            this.Children.Add(new AddExpense(loginID));
            this.Children.Add(new AddTypeExpenseView(loginID));
            this.Children.Add(new AddCostingExpenseView(loginID));
        }
    }
}
