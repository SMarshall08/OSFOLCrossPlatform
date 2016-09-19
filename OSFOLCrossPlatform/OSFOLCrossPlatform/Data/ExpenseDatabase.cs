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

        public IEnumerable<SalesOpportunity> GetOpportunities()
        {
            lock (locker)
            {
                //return (from i in database.Table<Customer>() select i).ToList();
                return database.Query<SalesOpportunity>("SELECT * FROM [SalesOpportunity] ORDER BY Opportunity ASC");
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

        //public Expense GetExpenseItems(int loginID)
        //{
        //    lock (locker)
        //    {
        //        return database.Table<Expense>().FirstOrDefault(x => x.LoginID == loginID);
        //    }
        //}

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

