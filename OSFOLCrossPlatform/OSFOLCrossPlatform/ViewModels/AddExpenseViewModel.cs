using System;
using System.Collections.Generic;
using OSFOLCrossPlatform.View;
using OSFOLCrossPlatform.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddExpenseViewModel : INotifyPropertyChanged
    {

        IList<Customers> _customer;
        IList<Opportunity> _opportunity;
        ExpenseModel _expense;

        public ExpenseModel ExpenseModel
        {
            get { return _expense; }
            set
            {
                _expense = value;
                RaisePropertyChanged();
            }
        }
        
        public IList<Customers> Customers
        {
            get { return _customer; }
            set {
                _customer = value;
                RaisePropertyChanged();
            }
        }

        public IList<Opportunity> Opportunity
        {
            get { return  _opportunity; }
            set
            {
                _opportunity = value;
                RaisePropertyChanged();
            }
        }



        public AddExpenseViewModel()
        {
            ExpenseModel = new ExpenseModel();
            // expense.Customer = "Please choose customer";
            ExpenseModel.Opportunity = "Sales Opportunity";
            ExpenseModel.ExpenseID = 100;
            ExpenseModel.ModifiedDT = DateTime.Now;

            

            this.Opportunity = new List<Opportunity>();
            this.Opportunity.Add(new Opportunity { ID = 1, SalesOpportunity = "Lighthouse Office" });
            this.Opportunity.Add(new Opportunity { ID = 2, SalesOpportunity = "Rexam Plant" });
            this.Opportunity.Add(new Opportunity { ID = 3, SalesOpportunity = "Account Management" });
            this.Opportunity.Add(new Opportunity { ID = 4, SalesOpportunity = "Change Requests" });
            
        }

        // Method auto-created from inheriting INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
