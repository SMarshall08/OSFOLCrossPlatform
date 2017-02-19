using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class MonthExpenseViewModel : ObservableObject
    {
            IEnumerable<ExpenseMonth> _allMonthData;
            Login _loginID;


            public MonthExpenseViewModel(int loginID)
            {
                RefreshExpensesDataAsync();

                MessagingCenter.Subscribe<object>(this, "RefreshData", async (sender) =>
                {
                    await RefreshExpensesDataAsync();
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

            public IEnumerable<ExpenseMonth> AllMonthData
            {
                get { return _allMonthData; }
                set
                {
                SetProperty(ref _allMonthData, value);
                }
            }

            public async Task RefreshExpensesDataAsync()
            {
                await Task.Run(() =>
                {
                    RefreshMonthData();
                });
            }

            public void RefreshMonthData()
            {
                AllMonthData = App.Database.GetMonths();
            }
        }
}
