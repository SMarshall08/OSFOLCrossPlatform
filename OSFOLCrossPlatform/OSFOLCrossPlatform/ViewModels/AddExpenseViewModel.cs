using System;
using System.Collections.Generic;
using OSFOLCrossPlatform.Infrastructure;
using OSFOLCrossPlatform.Model;

namespace OSFOLCrossPlatform.ViewModels
{
    public class AddExpenseViewModel : ObservableObject
    {
        IList<Customers> _customer;
        IList<Opportunity> _opportunity;
        Expense _expense;
        
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

        public Expense Expense
        {
            get { return _expense; }
            set
            {
                _expense = value;
                RaisePropertyChanged();
            }
        }

        public AddExpenseViewModel()
        {
            var expense = new Expense();
            // expense.Customer = "Please choose customer";
            expense.Opportunity = "Sales Opportunity";
            expense.ExpenseID = 100;
            expense.ModifiedDT = DateTime.Now;

            this.Expense = expense;

            //this.Customer = Customers;

            //this.Customers = new List<Customers>();
            //this.Customers.Add(new Customer { ID = 1, Name = "Rexam" });
            //this.Customers.Add(new Customer { ID = 2, Name = "Linpac" });
            //this.Customers.Add(new Customer { ID = 3, Name = "Crown" });
            //this.Customers.Add(new Customer { ID = 4, Name = "Benteler" });

            this.Opportunity = new List<Opportunity>();
            this.Opportunity.Add(new Opportunity { ID = 1, SalesOpportunity = "Lighthouse Office" });
            this.Opportunity.Add(new Opportunity { ID = 2, SalesOpportunity = "Rexam Plant" });
            this.Opportunity.Add(new Opportunity { ID = 3, SalesOpportunity = "Account Management" });
            this.Opportunity.Add(new Opportunity { ID = 4, SalesOpportunity = "Change Requests" });
            
        }
        
    }
}
