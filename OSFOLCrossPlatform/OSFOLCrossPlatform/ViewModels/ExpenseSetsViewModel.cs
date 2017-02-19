using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class ExpenseSetsViewModel : ObservableObject
    {
        IEnumerable<ExpenseSet> _allExpenseSetsData;
        Login _loginID;


        public ExpenseSetsViewModel(int loginID)
        {
            RefreshExpenseSetsDataAsync(loginID);

            MessagingCenter.Subscribe<object>(this, "RefreshData", async (sender) =>
            {
                await RefreshExpenseSetsDataAsync(loginID);
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

        public IEnumerable<ExpenseSet> AllExpenseSetsData
        {
            get { return _allExpenseSetsData; }
            set
            {
                SetProperty(ref _allExpenseSetsData, value);
            }
        }

        public async Task RefreshExpenseSetsDataAsync(int loginID)
        {
            await Task.Run(() =>
            {
                RefreshExpenseSetsData(loginID);
            });
        }

        public void RefreshExpenseSetsData(int loginID)
        {
            AllExpenseSetsData = App.Database.GetExpenseSets(loginID);
        }

        public async void FilterExpenseSets(string filter, int loginID)
        {
            if (string.IsNullOrWhiteSpace(filter))
                await RefreshExpenseSetsDataAsync(loginID);
            else {
                AllExpenseSetsData = AllExpenseSetsData.Where(x =>
                    x.ExpenseSetName.ToString().ToLower().Contains(filter.ToLower())
                 );
            }
        }
    }
}
