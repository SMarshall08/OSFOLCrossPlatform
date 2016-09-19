using System;
using SQLite;

namespace OSFOLCrossPlatform
{
    public class Login
    {

        public Login(int id)
        {
            LoginID = id;
        }

        public Login() { }

        [PrimaryKey, Unique]
        public int    LoginID   { get; set; }
        public string UserName  { get; set; }
        public string Password  { get; set; }
        public bool   IsRetired { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }

    }
}
