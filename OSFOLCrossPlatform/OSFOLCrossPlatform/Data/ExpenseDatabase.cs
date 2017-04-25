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
                return database.Query<Customers>("SELECT * FROM [Customers] WHERE IsRetired = 0 ORDER BY Customer ASC");
            }
        }

        public int GetMaxLoginID()
        {
            lock (locker)
            {
                return database.ExecuteScalar<int>("SELECT MAX(LoginID) As LoginID FROM [Login]");
            }
        }

        public int GetMaxContactID()
        {
            lock (locker)
            {
                return database.ExecuteScalar<int>("SELECT MAX(ContactID) As ContactID FROM [Contact]");
            }
        }

        public int GetMaxSalesOpportunityID()
        {
            lock (locker)
            {
                return database.ExecuteScalar<int>("SELECT MAX(SalesOpportunityID) As SalesOpportunityID FROM [SalesOpportunity]");
            }
        }

        public int GetMaxVendorID()
        {
            lock (locker)
            {
                return database.ExecuteScalar<int>("SELECT MAX(VendorID) As VendorID FROM [rfVendor]");
            }
        }

        public IEnumerable<Login> GetUserNames()
        {
            lock (locker)
            {
                //return (from i in database.Table<Customer>() select i).ToList();
                return database.Query<Login>("SELECT UserName FROM [Login] WHERE IsRetired = 0 ORDER BY UserName ASC");
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

        public IEnumerable<ContactFullName> GetFullNameContact()
        {
            lock (locker)
            {
                //return (from i in database.Table<Contact>() select i).ToList();
                return database.Query<ContactFullName>("SELECT * FROM [ContactFullName] ORDER BY FullName ASC");
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


        public IEnumerable<ExpenseSummary> GetExpenseSummary(int expenseID)
        {
            lock (locker)
            {
                return database.Table<ExpenseSummary>().Where(x => x.ExpenseID == expenseID);
            }
        }


        public IEnumerable<SalesOpportunity> GetDependencyOpportunity(int customerID)
        {
            lock (locker)
            {
                return database.Table<SalesOpportunity>().Where(x => x.CustomerID == customerID);
            }
        }

        public IEnumerable<ContactFullName> GetDependencyContact(int customerID)
        {
            lock (locker)
            {
                return database.Table<ContactFullName>().Where(x => x.CustomerID == customerID);
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
                return database.Table<Login>().
                    FirstOrDefault(x => x.UserName == username);
            }
        }

        // Get Logins that equal to username param passed in
        public Login GetLoginName(int loginID)
        {
            lock (locker)
            {
                return database.Table<Login>().
                    FirstOrDefault(x => x.LoginID == loginID);
            }
        }

        // Get 3 months back from now
        public IEnumerable<ExpenseMonth> GetMonths(int threeMonthsBack, int nowMonth)
        {
            lock (locker)
            {
                return database.Table<ExpenseMonth>().Where(x => x.MonthID >= threeMonthsBack && x.MonthID <= nowMonth).ToList();
            }
        }


        public Expense GetExpense(Expense expense)
        {
            lock (locker)
            {
                return database.Table<Expense>().
                    FirstOrDefault(x => x.ExpenseID == expense.ExpenseID);
            }
        }

        public Expense GetEditExpense (int expenseID)
        {
            lock (locker)
            {
                return database.Table<Expense>().
                    FirstOrDefault(x => x.ExpenseID == expenseID);
            }
        }

        public ExpenseSet GetExpenseSet(int expenseSetID)
        {
            lock (locker)
            {
                return database.Table<ExpenseSet>().
                    FirstOrDefault(x => x.ExpenseSetID == expenseSetID);
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


        public IEnumerable<ExpenseSet> GetExpenseSets(int loginID)
        {
            lock (locker)
            {
                return (from i in database.Table<ExpenseSet>()
                        select i).ToList().Where(x => x.LoginID == loginID);
            }
        }

        public IEnumerable<ExpenseSet> GetExpenseSetData(int loginID)
        {
            lock (locker)
            {
                return (from i in database.Table<ExpenseSet>()
                        select i).ToList().Where(x => x.LoginID == loginID);
            }
        }


        public IEnumerable<ExpenseSummary> GetAllExpenseSummaryData_OldToNew(int loginID)
        {
            lock (locker)
            {
                return (from i in database.Table<ExpenseSummary>()
                        select i).ToList().Where(x => x.ExpenseID > 0 && x.LoginID == loginID);
            }
        }

        public IEnumerable<Expense> GetAllExpenseData_OldToNew(int loginID, int monthID)
        {
            lock (locker)
            {
                return (from i in database.Table<Expense>()
                        select i).ToList().Where(x => x.ExpenseID > 0 && x.LoginID == loginID && x.MonthReportIdentifier == monthID);
            }
        }

        public IEnumerable<Expense> GetAllExpenseSetData_OldToNew(int expenseSetID)
        {
            lock (locker)
            {
                return (from i in database.Table<Expense>()
                        select i).ToList().Where(x => x.ExpenseSetID == expenseSetID);
            }
        }

        public int SaveCustomer(Customers customer)
        {
            lock (locker)
            {
                database.Insert(customer);
                return customer.CustomerID;
            }
        }
        public int SaveContact(Contact contact)
        {
            lock (locker)
            {
                database.Insert(contact);
                return contact.ContactID;
            }
        }

        public int SaveSalesOpportunity(SalesOpportunity opportunity)
        {
            lock (locker)
            {
                database.Insert(opportunity);
                return opportunity.SalesOpportunityID;
            }
        }

        public int SaveVendor(rfVendor vendor)
        {
            lock (locker)
            {
                database.Insert(vendor);
                return vendor.VendorID;
            }
        }

        public int SignUp(Login login)
        {
            lock (locker)
            {
                database.Insert(login);
                return login.LoginID;
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

        public int DeleteItem(ExpenseSet deleteExpenseSet)
        {
            lock (locker)
            {
                return database.Delete<ExpenseSet>(deleteExpenseSet.ExpenseSetID);
            }
        }


        public void Dispose()
        {
            database.Dispose();
        }
    }
}

