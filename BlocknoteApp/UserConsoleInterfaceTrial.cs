using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknoteApp
{
    class UserConsoleInterfaceTrial
    {
        public User User { get; set; }
        public static List<User> UserList { get; set; }
        public UserConsoleInterfaceTrial()
        {
            UserConsoleInterfaceTrial.UserList = new List<User>();
        }

        #region Add Contact
        private void AddContact()
        {
            while (true)
            {

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter surname");
                string surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter email: (if you want to add more than one email address, please enter emails seperated by commas)");
                string email = Console.ReadLine();
                List<string> emailList = email.Trim().Split(',').ToList();
                Console.Clear();
                Console.WriteLine("Enter phone number: (if you want to add more than one phone numbers, please enter emails seperated by commas)");
                string phone = Console.ReadLine();
                List<string> phoneList = phone.Trim().Split(',').ToList();
                Console.Clear();
                User.Blocknote.CreateContact(name, surname, emailList, phoneList);
                //User.Blocknote.ShowBlocknote();
                ShowContact();
                Console.WriteLine("Press f10 key, if you want to add another contact");
                Console.WriteLine("Press Home key if you want to go to main menu");
                if (Console.ReadKey().Key == ConsoleKey.F10)
                    continue;
                if (Console.ReadKey().Key == ConsoleKey.Home)
                {
                    Console.Clear();
                    Start();
                }
                break;
            }
        }
        #endregion
        #region Delete Contact
        private void DeleteContact()
        {
            while (true)
            {

                Console.WriteLine("Enter the name of the contact you want to remove");
                string nameToDelete = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter the surname of the contact you want to remove");
                string surnameToDelete = Console.ReadLine();
                Console.Clear();
                User.Blocknote.DeleteContact(nameToDelete, surnameToDelete);
                //User.Blocknote.ShowBlocknote();
                ShowContact();
                Console.WriteLine("Press f9 key, if you want to delete another contact");
                Console.WriteLine("Press Home key if you want to go to main menu");
                if (Console.ReadKey().Key == ConsoleKey.F9)
                    continue;
                if (Console.ReadKey().Key == ConsoleKey.Home)
                {
                    Console.Clear();
                    Start();
                }
                break;
            }
        }
        #endregion
        #region Edit Contact
        private void EditContact()
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the contact you want to edit");
                string nameToEdit = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter the surname of the contact you want to edit");
                string surnameToEdit = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter the parameter name you want to edit ? : { name, surname, emailaddress, phonenumber}");
                string paramToEdit = Console.ReadLine();
                Console.Clear();
                int index = 0;
                int operation = 0;
                string newParam = "";
                if (paramToEdit.ToLower() == "name" || paramToEdit.ToLower() == "surname")
                {
                    Console.WriteLine("Enter the new parameter");
                    newParam = Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (paramToEdit.ToLower() == "emailaddress".ToLower())
                    {
                        while (true)
                        {
                            Console.WriteLine("Please choose operation. {Add_1, Remove_2, Edit_3}");
                            if (!Int32.TryParse(Console.ReadLine(), out operation))
                            {
                                Console.WriteLine("Please enter a number.");
                                continue;
                            }
                            foreach (Contact c in User.Blocknote.ContactList)
                            {
                                if (c.Name == nameToEdit && c.Surname == surnameToEdit)
                                    Console.WriteLine(c.ToString());
                            }
                            if (operation == 1) //Operation_Add)
                            {
                                Console.WriteLine("Enter the email address you want to add.");
                                newParam = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            if (operation == 2) //Operation_Remove)
                            {
                                Console.WriteLine("Please enter the index of the email you want to Delete");
                                if (!Int32.TryParse(Console.ReadLine(), out index))
                                {
                                    Console.WriteLine("Please enter a number.");
                                    continue;
                                }
                                else
                                    break;
                            }
                            if (operation == 3) //Operation_Edit)
                            {
                                Console.WriteLine("Enter the new parameter.");
                                newParam = Console.ReadLine();
                                //Console.Clear();
                                Console.WriteLine("Please enter the index of the email you want to edit");
                                if (!Int32.TryParse(Console.ReadLine(), out index))
                                {
                                    Console.WriteLine("Please enter a number.");
                                    continue;
                                }
                                else
                                    break;
                            }
                        }
                    }
                    if (paramToEdit.ToLower() == "phonenumber".ToLower())
                    {
                        while (true)
                        {
                            Console.WriteLine("Please choose operation. {Add_1, Remove_2, Edit_3}");
                            if (!Int32.TryParse(Console.ReadLine(), out operation))
                            {
                                Console.WriteLine("Please enter a number.");
                                continue;
                            }
                            foreach (Contact c in User.Blocknote.ContactList)
                            {
                                if (c.Name == nameToEdit && c.Surname == surnameToEdit)
                                    Console.WriteLine(c.ToString());
                            }
                            if (operation == 1) //Operation_Add)
                            {
                                Console.WriteLine("Enter the phone number you want to add.");
                                newParam = Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            if (operation == 2) //Operation_Remove)
                            {
                                Console.WriteLine("Please enter the index of the phone number you want to Delete");
                                if (!Int32.TryParse(Console.ReadLine(), out index))
                                {
                                    Console.WriteLine("Please enter a number.");
                                    continue;
                                }
                                else
                                    break;
                            }
                            if (operation == 3) //Operation_Edit)
                            {
                                Console.WriteLine("Enter the new parameter.");
                                newParam = Console.ReadLine();
                                //Console.Clear();
                                Console.WriteLine("Please enter the index of the phone number you want to edit");
                                if (!Int32.TryParse(Console.ReadLine(), out index))
                                {
                                    Console.WriteLine("Please enter a number.");
                                    continue;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
                User.Blocknote.EditContact(nameToEdit, surnameToEdit, paramToEdit, newParam, operation, index);
                Console.Clear();
                ShowContact();
                Console.WriteLine("Press f8 key, if you want to edit another contact");
                Console.WriteLine("Press Home key if you want to go to main menu");
                if (Console.ReadKey().Key == ConsoleKey.F8)
                    continue;
                if (Console.ReadKey().Key == ConsoleKey.Home)
                {
                    Console.Clear();
                    Start();
                }
                break;
            }
        }
        #endregion
        #region Show Contacts
        private void ShowContact()
        {
            foreach (Contact c in User.Blocknote.ContactList)
            {
                if (c != null)
                    Console.WriteLine(c.ToString());
            }
        }
        #endregion

        private void ShowBlocknote()
        {
            while (true)
            {
                foreach (Contact c in User.Blocknote.ContactList)
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("Press Home key if you want to go to main menu");
                if (Console.ReadKey().Key == ConsoleKey.Home)
                {
                    Console.Clear();
                    Start();
                }
                break;
            }
        }
        public void CreateUser()
        {
            User = new User();
            User.Blocknote = new Blocknote();
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.Clear();
            User.Name = name;
            Console.WriteLine("Please enter your surname:");
            string surname = Console.ReadLine();
            Console.Clear();
            User.Surname = surname;
            Console.WriteLine("Please set your username:");
            string username = Console.ReadLine();
            Console.Clear();
            User.UserName = username;
            Console.WriteLine("Please set your password: (6 or more digits)");
            string password = Console.ReadLine();
            Console.Clear();
            User.Password = password;

            Console.WriteLine("Congratulations You've registered successfully");

            UserList.Add(this.User);

        }

        public void LogIn()
        {
            Console.WriteLine("Please enter your username...");
            string username = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your password...");
            string password = Console.ReadLine();
            Console.Clear();

            foreach (User u in UserList)
            {
                if (u.UserName == username && u.Password == password)
                {
                    Console.WriteLine("You logged in successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid username or password...");
                    LogIn();
                }
            }
            Start();
        }

        private void Start()
        {
            Console.WriteLine("Welcome to your Blocknote");
            Console.WriteLine("Please choose operations");
            Console.WriteLine(" Add Contact - 1\n Delete contact - 2\n Edit Contact - 3 \n Show Contact list - 4");
            string operations = Console.ReadLine();
            switch (operations)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    DeleteContact();
                    break;
                case "3":
                    EditContact();
                    break;
                case "4":
                    Console.Clear();
                    ShowBlocknote();
                    break;
                default:
                    Console.WriteLine("Please enter valid operation");
                    Console.ReadLine();
                    Console.Clear();
                    Start();
                    break;
            }
        }
    }
}

