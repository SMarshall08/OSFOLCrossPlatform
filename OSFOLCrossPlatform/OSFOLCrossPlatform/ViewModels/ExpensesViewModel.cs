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
        IEnumerable<Expense> _allExpensesData;
        Login _loginID;


        public ExpensesViewModel(int loginID)
        {
            RefreshExpensesDataAsync(loginID);

            MessagingCenter.Subscribe<object>(this, "RefreshData", (sender) =>
            {
                RefreshExpensesDataAsync(loginID);
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

        public IEnumerable<Expense> AllExpensesData
        {
            get { return _allExpensesData; }
            set
            {
                SetProperty<IEnumerable<Expense>>(ref _allExpensesData, value);
            }
        }

        public async Task RefreshExpensesDataAsync(int loginID)
        {
            await Task.Run(() =>
            {
                //int id = LoginID.LoginID;
                RefreshExpensesData(loginID);
            });
        }

        public void RefreshExpensesData(int loginID)
        {
            AllExpensesData = App.Database.GetAllExpensesData_OldToNew(loginID);
        }

        public void FilterExpenses(string filter, int loginID)
        {
            if (string.IsNullOrWhiteSpace(filter))
                RefreshExpensesDataAsync(loginID);
            else {
                AllExpensesData = AllExpensesData.Where(x =>
                    x.CustomerID.ToString().ToLower().Contains(filter.ToLower()) ||
                     x.SaleOpportunityID.ToString().ToLower().Contains(filter.ToLower()) 
                 );
            }
        }
    }
}
