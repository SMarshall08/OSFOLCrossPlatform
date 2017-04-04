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
                RefreshMonthDataAsync();

                MessagingCenter.Subscribe<object>(this, "RefreshData", async (sender) =>
                {
                    await RefreshMonthDataAsync();
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

            public async Task RefreshMonthDataAsync()
            {
                await Task.Run(() =>
                {
                    RefreshMonthData();
                });
            }

            public void RefreshMonthData()
            {
                DateTime Now = DateTime.Now;
                int month = Now.Month;
                int threeMonthsBack;

                if(month == 1)
                {
                    threeMonthsBack = 11;
                }
                else if(month == 2)
                {
                    threeMonthsBack = 12;
                }
                else
                {
                    threeMonthsBack = month - 2;
                }
                
                    AllMonthData = App.Database.GetMonths(threeMonthsBack, month);
                }
        }
}
