using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using OSFOLCrossPlatform.Model;
using SQLite;


namespace OSFOLCrossPlatform.Data
{
    public class ExpenseDatabase
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
            // create the tables
            // database.CreateTable<Expense>();mar
        }


        public IEnumerable<Customers> GetCustomers()
        {
            lock (locker)
            {
                //return (from i in database.Table<Customer>() select i).ToList();
                return database.Query<Customers>("SELECT * FROM [Customers] WHERE IsRetired = 0 ORDER BY Customer ASC");
            }
        }

        public IEnumerable<ExpenseModel> GetLogin()
        {
            lock (locker)
            {
                //return (from i in database.Table<Login>() select i).ToList();
                return database.Query<ExpenseModel>("SELECT * FROM [Login] WHERE IsRetired = 0 ORDER BY Name ASC");
            }
        }

        public IEnumerable<ExpenseModel> GetExpenseItems()
        {
            lock (locker)
            {
                return database.Query<ExpenseModel>("SELECT * FROM [Expense]");
            }
        }

        public Customers GetCustomer(int id)
        {
            lock (locker)
            {
                return database.Table<Customers>().FirstOrDefault(x => x.CustomerID == id);
            }
        }

        public int SaveItem(ExpenseModel item)
        {
            lock (locker)
            {
                if (item.ExpenseID != 0)
                {
                    database.Update(item);
                    return item.ExpenseID;
                }
                else {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<ExpenseModel>(id);
            }
        }
    }
}

