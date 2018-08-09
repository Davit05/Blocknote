using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknoteApp
{
    public class Blocknote
    {
        public Contact Contact { get; set; }
        public List<Contact> ContactList { get; set; }

        private int Count { get; set; }
        public Blocknote()
        {

            ContactList = new List<Contact>();
        }

        private bool isEmpty()
        {
            return this.Count == 0;
        }

        public void CreateContact(string name, string surname, List<string> emailAddress, List<string> phoneNumber)
        {
            Contact = new Contact
            {
                Name = name,
                Surname = surname,
                EmailAddresses = emailAddress,
                PhoneNumbers = phoneNumber
            };

            ContactList.Add(Contact);
            Count++;

        }

        public void EditContact(string name, string surname, string paramToEdit, string newParam = "", int operation = 0, int index = 0)
        {
            if (this.isEmpty())
                throw new NotImplementedException("Your contact list is empty");

            bool b = false;
            foreach (Contact c in ContactList)
            {
                if (c != null)
                {

                    if (c.Name.ToLower() == name.ToLower() && c.Surname.ToLower() == surname.ToLower())
                    {
                        if (paramToEdit.ToLower() == "name".ToLower())
                            c.Name = newParam;
                        if (paramToEdit.ToLower() == "surname".ToLower())
                            c.Surname = newParam;
                        if (paramToEdit.ToLower() == "emailaddress".ToLower())
                        {
                            switch (operation)
                            {
                                case 1: //Add
                                    AddEmail(name, surname, newParam);
                                    break;
                                case 2: //Remove
                                    RemoveEmail(name, surname, index);
                                    break;
                                case 3: //Edit
                                    if (index > c.EmailAddresses.Count || index <= 0)
                                        throw new IndexOutOfRangeException("Please enter valid index");
                                    else
                                        c.EmailAddresses[index - 1] = newParam;
                                    break;
                                default:
                                    throw new Exception("Please enter valid operation");
                            }
                        }

                        if (paramToEdit.ToLower() == "phonenumber".ToLower())
                        {
                            switch (operation)
                            {
                                case 1: //Add
                                    AddPhoneNumber(name, surname, newParam);
                                    break;
                                case 2: //Remove
                                    RemovePhoneNumber(name, surname, index);
                                    break;
                                case 3: //Edit
                                    if (index > c.EmailAddresses.Count || index <= 0)
                                        throw new IndexOutOfRangeException("Please enter valid index");
                                    else
                                        c.PhoneNumbers[index - 1] = newParam;
                                    break;
                                default:
                                    throw new Exception("Please enter valid operation");
                            }
                        }
                        b = true;
                    }
                }
            }

            if (!b)
                throw new ApplicationException("Contact not found!");
        }

        public void AddEmail(string name, string surname, string email)
        {
            foreach (Contact c in ContactList)
            {
                if (c.Name.ToLower() == name.ToLower() && c.Surname.ToLower() == surname.ToLower())
                {
                    c.EmailAddresses.Add(email);
                }
            }
        }
        public void RemoveEmail(string name, string surname, int index)
        {
            if (Contact.EmailAddresses.Count == 0)
                throw new NotImplementedException("Your emailaddresses list is empty");
            else if (index <= 0 || index > Contact.EmailAddresses.Count)
                throw new IndexOutOfRangeException("Please enter valid index");
            else
            {
                foreach (Contact c in ContactList)
                {
                    if (c.Name.ToLower() == name.ToLower() && c.Surname.ToLower() == surname.ToLower())
                        Contact.EmailAddresses.RemoveAt(index - 1);
                }
            }
        }

        public void AddPhoneNumber(string name, string surname, string phoneNumber)
        {
            foreach (Contact c in ContactList)
            {
                if (c.Name.ToLower() == name.ToLower() && c.Surname.ToLower() == surname.ToLower())
                {
                    c.PhoneNumbers.Add(phoneNumber);
                }
            }
        }

        public void RemovePhoneNumber(string name, string surname, int index)
        {
            if (Contact.PhoneNumbers.Count == 0)
                throw new NotImplementedException("Your phone numbers' list is empty");
            else if (index <= 0 || index > Contact.PhoneNumbers.Count)
                throw new IndexOutOfRangeException("Please enter valid index");
            else
            {
                foreach (Contact c in ContactList)
                {
                    if (c.Name.ToLower() == name.ToLower() && c.Surname.ToLower() == surname.ToLower())
                        Contact.PhoneNumbers.RemoveAt(index - 1);
                }
            }
        }

        public void DeleteContact(string name, string surname)
        {
            if (this.isEmpty())
                throw new NotImplementedException("Your contactlist is empty");
            bool b = false;
            for (int i = 0; i < ContactList.Count; i++)
            {
                if (ContactList[i] != null)
                {

                    if (ContactList[i].Name == name && ContactList[i].Surname == surname)
                    {
                        ContactList[i] = null;
                        b = true;
                        Count--;
                        return;
                    }
                }
            }

            if (!b)
                throw new ApplicationException("Contact not found!");
        }



    }
}
