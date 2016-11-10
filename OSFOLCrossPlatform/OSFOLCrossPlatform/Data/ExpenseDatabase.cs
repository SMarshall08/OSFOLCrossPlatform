using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using OSFOLCrossPlatform.Model;
using SQLite;
using System;

namespace OSFOLCrossPlatform.Data
{
    public class ExpenseDatabase : IDisposable
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the ExpenseDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public ExpenseDatabase()
        {
            database = DependencyService.Get<ISQLite> ().GetConnection ();
        }


        public IEnumerable<Customers> GetCustomers()
        {
            lock (locker)
            {
                //return (from i in database.Table<Customer>() select i).ToList();
                return database.Query<Customers>("SELECT * FROM [Customers] WHERE IsRetired = 0 ORDER BY Customer ASC");
            }
        }

        public Customers GetCustomer(int customerID)
        {
            lock (locker)
            {
                return database.Table<Customers>().FirstOrDefault(x => x.CustomerID == customerID);
            }
        }

        public SalesOpportunity GetOpportunity(int salesOpportunityID)
        {
            lock (locker)
            {
                return database.Table<SalesOpportunity>().FirstOrDefault(x => x.SalesOpportunityID == salesOpportunityID);
            }
        }

        public IEnumerable<ExpenseMethod> GetExpenseMethods()
        {
            lock (locker)
            {
                //return (from i in database.Table<ExpenseMethod>() select i).ToList();
                return database.Query<ExpenseMethod>("SELECT * FROM [ExpenseMethod] ORDER BY rfExpenseMethod ASC");
            }
        }

        public IEnumerable<SalesOpportunity> GetOpportunities()
        {
            lock (locker)
            {
                //return (from i in database.Table<SalesOpportunity>() select i).ToList();
                return database.Query<SalesOpportunity>("SELECT * FROM [SalesOpportunity] ORDER BY Opportunity ASC");
            }
        }

        public IEnumerable<ExpenseType> GetExpenseTypes()
        {
            lock (locker)
            {
                //return (from i in database.Table<ExpenseType>() select i).ToList();
                return database.Query<ExpenseType>("SELECT * FROM [ExpenseType] ORDER BY rfExpenseType ASC");
            }
        }

        public IEnumerable<rfVendor> GetVendor()
        {
            lock (locker)
            {
                //return (from i in database.Table<rfVendor>() select i).ToList();
                return database.Query<rfVendor>("SELECT * FROM [rfVendor] ORDER BY Vendor ASC");
            }
        }

        public IEnumerable<Contact> GetContact()
        {
            lock (locker)
            {
                //return (from i in database.Table<Contact>() select i).ToList();
                return database.Query<Contact>("SELECT * FROM [Contact] ORDER BY FirstName ASC");
            }
        }

        public IEnumerable<Currency> GetCurrency()
        {
            lock (locker)
            {
                //return (from i in database.Table<Contact>() select i).ToList();
                return database.Query<Currency>("SELECT * FROM [Currency] ORDER BY rfCurrencyID ASC");
            }
        }

        // Gets all Logins and populates into a list ordered by name 
        public List<Login> ListofLogins()
        {
            return database.Table<Login>().OrderBy(x => x.FirstName).ToList();
        }

        // Get Logins that equal to username param passed in
        public Login GetLogin(string username)
        {
            lock (locker)
            {
                return database.Table<Login>().FirstOrDefault(x => x.UserName == username);
            }
        }

        public Expense GetExpenseItems(Expense expense)
        {
            lock (locker)
            {
                return database.Table<Expense>().FirstOrDefault(x => x.ExpenseID == expense.ExpenseID && x.LoginID == expense.LoginID);
            }
        }

        public ExpenseSummary GetExpenses(int expenseID)
        {
            lock (locker)
            {
                return database.Table<ExpenseSummary>().
                    FirstOrDefault(x => x.ExpenseID == expenseID);
            }
        }

        public IEnumerable<Expense> GetAllExpensesData_OldToNew(int loginID)
        {
            lock (locker)
            {
                return (from i in database.Table<Expense>()
                        select i).ToList().Where(x => x.ExpenseID > 0 && x.LoginID == loginID);
            }
        }


        public int SaveExpense(Expense expense)
        {
            lock (locker)
            {
                if (expense.ExpenseID != 0)
                {
                    database.Update(expense);
                    return expense.ExpenseID;
                }
                else {
                    database.Insert(expense);
                    return expense.ExpenseID;
                }
            }
        }

        public int SaveExpenseSet(ExpenseSet expenseSet)
        {
            lock (locker)
            {
                if (expenseSet.ExpenseSetID != 0)
                {
                    database.Update(expenseSet);
                    return expenseSet.ExpenseSetID;
                }
                else {
                    database.Insert(expenseSet);
                    return expenseSet.ExpenseSetID;
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Expense>(id);
            }
        }


        public void Dispose()
        {
            database.Dispose();
        }
    }
}

