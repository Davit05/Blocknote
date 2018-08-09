using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknoteApp
{
    public class User
    {
        private string password;
        public Blocknote Blocknote { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string UserName { get;  set; }

        public string Password
        {
            get
            {
                return this.password;
            }
             set
            {
                if (value.Length < 6)
                    throw new ApplicationException("Password cannot be less than 6 digits");
                else
                    this.password = value;
            }
        }
        public User()
        {

        }

        public User(string name, string surname, string username, string password)
        {
            Blocknote = new Blocknote();
            Name = name;
            Surname = surname;
            UserName = username;
            Password = password;
        }

        public Blocknote LogIn(string username, string password)
        {
            if (UserName == username && Password == password)
                return this.Blocknote;
            else
                throw new ApplicationException("Please enter valid Username and Password!");
        }
    }
}
