using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Helper;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpenseViewModel : ObservableObject
    {
        private ExpenseService expenseService;
        private Expense currrentExpense;

        public ExpenseViewModel()
        {
            expenseService = ServiceContainer.Resolve<ExpenseService>();
        }

        public ExpenseViewModel(ExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        public async Task InitialiseExpense(int expenseID)
        {
            if (expenseID >= 0)
                currrentExpense = await expenseService.GetExpense(expenseID);
            else
                currrentExpense = null;
            InitialiseExpense();
        }

        public void InitialiseExpense(Expense expense)
        {
            currrentExpense = expense;
            InitialiseExpense();
        }

        private void InitialiseExpense()
        {
            if(currrentExpense == null)
            {
                ModifiedDT = DateTime.Now;

            }
        }
        private DateTime modifiedDT = DateTime.Now;
        public DateTime ModifiedDT
        {
            get { return modifiedDT; }
            set { modifiedDT = value;  }
        }
    }
}
