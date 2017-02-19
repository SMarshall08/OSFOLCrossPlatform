using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using OSFOLCrossPlatform.Model;
using OSFOLCrossPlatform.Infrastructure;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpensesViewModel : ObservableObject
    {
        IEnumerable<ExpenseSummary> _allExpenseSummaryData;
        IEnumerable<Expense> _allExpenseData;
        IEnumerable<Expense> _allExpenseSetData;
        Login _loginID;


        public ExpensesViewModel(int loginID, int monthID)
        {
            RefreshExpensesDataAsync(loginID, monthID);

            MessagingCenter.Subscribe<object>(this, "RefreshData", async (sender) =>
            {
                await RefreshExpensesDataAsync(loginID, monthID);
            });
        }

        public ExpensesViewModel(int expenseSetID)
        {
            RefreshExpenseSetDataAsync(expenseSetID);

            MessagingCenter.Subscribe<object>(this, "RefreshData", async (sender) =>
            {
                await RefreshExpenseSetDataAsync(expenseSetID);
            });
        }

        public Login LoginID
        {
            get { return _loginID; }
            set
            {
                _loginID = value;
            }
        }

        public IEnumerable<Expense> AllExpenseSetData
        {
            get { return _allExpenseSetData; }
            set
            {
                SetProperty(ref _allExpenseSetData, value);
            }
        }

        public IEnumerable<Expense> AllExpensesData
        {
            get { return _allExpenseData; }
            set
            {
                SetProperty(ref _allExpenseData, value);
            }
        }

        public IEnumerable<ExpenseSummary> AllExpenseSummaryData
        {
            get { return _allExpenseSummaryData; }
            set
            {
                SetProperty(ref _allExpenseSummaryData, value);
            }
        }

        public async Task RefreshExpensesDataAsync(int loginID, int monthID)
        {
            await Task.Run(() =>
            {
                RefreshExpensesData(loginID, monthID);
            });
        }

        public async Task RefreshExpenseSetDataAsync(int expenseSetID)
        {
            await Task.Run(() =>
            {
                RefreshExpenseSetData(expenseSetID);
            });
        }

        public void RefreshExpensesData(int loginID, int monthID)
        {
            AllExpensesData = App.Database.GetAllExpenseData_OldToNew(loginID,monthID);
        }

        public void RefreshExpenseSetData(int expenseSetID)
        {
            AllExpenseSetData = App.Database.GetAllExpenseSetData_OldToNew(expenseSetID);
        }


        /// <summary>
        /// Filter for Filter Expenses Page
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="loginID"></param>
        /// <param name="monthID"></param>
        public async void FilterExpenses(string filter, int loginID, int monthID)
        {
            if (string.IsNullOrWhiteSpace(filter))
                await RefreshExpensesDataAsync(loginID, monthID);
            else {
                AllExpensesData = AllExpensesData.Where(x =>
                     x.ExpenseDetails.ToString().ToLower().Contains(filter.ToLower())
                 );
            }
        }

        /// <summary>
        /// Filter for Filter Expenses Page
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="loginID"></param>
        /// <param name="monthID"></param>
        public async void FilterExpenseSets(string filter, int expenseSetID)
        {
            if (string.IsNullOrWhiteSpace(filter))
                await RefreshExpenseSetDataAsync(expenseSetID);
            else {
                AllExpensesData = AllExpensesData.Where(x =>
                     x.ExpenseDetails.ToString().ToLower().Contains(filter.ToLower())
                 );
            }
        }

    }
}
