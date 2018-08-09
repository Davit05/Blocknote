using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknoteApp
{
    public class Contact : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public List<string> EmailAddresses { get; set; }

        public Contact()
        {
            Name = "";
            Surname = "";
            PhoneNumbers = new List<string>();
            EmailAddresses = new List<string>();
        }

        private string ConcatList(List<string> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                    result += list[i] + ", ";
                else
                    result += list[i] + " ";
            }
            return result;
        }



        public override string ToString()
        {
            return $"{Name}, {Surname}, {ConcatList(EmailAddresses)}, {ConcatList(PhoneNumbers)}";
        }

        public int CompareTo(object obj)
        {
            Contact c = (Contact)obj;

            if (c != null)
            {
                return c.Name == this.Name ? CompareString(c.Surname, Surname) : CompareString(c.Name, Name);
            }
            throw new Exception("Object is not a Contact type.");
        }

        private int CompareString(string s1, string s2)
        {
            int length = Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < length; i++)
            {
                if (s1[i] < s1[2])
                    return 1;
                else if (s1[i] > s2[i])
                    return -1;
            }
            return 0;
        }

    }
}
