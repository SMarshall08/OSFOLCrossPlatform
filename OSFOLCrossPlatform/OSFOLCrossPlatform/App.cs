using Xamarin.Forms;
using System;
using System.Diagnostics;
using OSFOLCrossPlatform.Data;
using OSFOLCrossPlatform.Views;

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

        //public int ResumeAtExpenseId { get; set; }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());// NEED TO CHaGE to Loginpage
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }    
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}

