using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.Infrastructure
{
    public interface ExpenseService
    {
        Task<Expense> GetExpense(int expenseID);
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> SaveExpense(Expense expense);
        Task<int> DeleteExpense(int expenseID);
    }
}
