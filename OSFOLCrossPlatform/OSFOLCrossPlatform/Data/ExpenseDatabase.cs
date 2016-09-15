﻿using System.Collections.Generic;
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

        public IEnumerable<ExpenseModel> GetExpenseItems()
        {
            lock (locker)
            {
                return database.Query<ExpenseModel>("SELECT * FROM [Expense]");
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

        public void Dispose()
        {
            database.Dispose();
        }
    }
}

