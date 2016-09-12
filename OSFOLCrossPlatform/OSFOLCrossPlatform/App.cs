using Xamarin.Forms;
using System;
using System.Diagnostics;
using OSFOLCrossPlatform.Data;

namespace OSFOLCrossPlatform
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        static ExpenseDatabase database;

        public static ExpenseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExpenseDatabase();
                }
                return database;
            }
        }

        public int ResumeAtExpenseId { get; set; }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }    
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");

            // always re-set when the app starts
            // users expect this (usually)
            //			Properties ["ResumeAtTodoId"] = "";
            if (Properties.ContainsKey("ResumeAtExpenseId"))
            {
                var rati = Properties["ResumeAtExpenseId"].ToString();
                Debug.WriteLine("   rati=" + rati);
                if (!String.IsNullOrEmpty(rati))
                {
                    Debug.WriteLine("   rati = " + rati);
                    ResumeAtExpenseId = int.Parse(rati);

                    if (ResumeAtExpenseId > 0)
                    {
                        var addExpensePage = new AddExpenseCS();
                        addExpensePage.BindingContext = Database.GetCustomer(ResumeAtExpenseId);

                        MainPage.Navigation.PushAsync(
                            addExpensePage,
                            false); // no animation
                    }
                }
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep saving ResumeAtExpenseId = " + ResumeAtExpenseId);
            // the app should keep updating this value, to
            // keep the "state" in case of a sleep/resume
            Properties["ResumeAtExpenseId"] = ResumeAtExpenseId;
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}

