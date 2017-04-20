using System;
using SQLite;

namespace OSFOLCrossPlatform
{
    /// <summary>
    /// Class representing the logged on user
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        /// <param name="id">The identifier</param>
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
