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
    public class IndividualExpenseSetViewModel : ObservableObject
    {
        IEnumerable<Expense> _allExpenseSetData;
        Login _loginID;


        public IndividualExpenseSetViewModel(int loginID, int expenseSetID)
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
                SetProperty<IEnumerable<Expense>>(ref _allExpenseSetData, value);
            }
        }

        public async Task RefreshExpenseSetDataAsync(int expenseSetID)
        {
            await Task.Run(() =>
            {
                RefreshExpenseSetData(expenseSetID);
            });
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
        public async void FilterExpenses(string filter,int expenseSetID)
        {
            if (string.IsNullOrWhiteSpace(filter))
                await RefreshExpenseSetDataAsync(expenseSetID);
            else {
                AllExpenseSetData = AllExpenseSetData.Where(x =>
                     x.ExpenseDetails.ToString().ToLower().Contains(filter.ToLower())
                 );
            }
        }
    }
}
