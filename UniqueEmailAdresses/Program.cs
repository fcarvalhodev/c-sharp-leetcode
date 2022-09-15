using System;
using System.Collections.Generic;

namespace UniqueEmailAdresses
{
    class Program
    {
        //check all values on the array and remove the . and check + signs to remove what's come afterwords.
        //check if the emails are not duplicated
        //check if the emails end's with .com
        //return the number of valid emails
        static void Main(string[] args)
        {

            string[] emails = new string[]
            {
                "a@leetcode.com",
                "b@leetcode.com",
                "c@leetcode.com"
            };

            int total = NumUniqueEmails(emails);
            Console.WriteLine(total);
            Console.ReadKey();
        }

        static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> validEmails = new HashSet<string>();

            for (int i = 0; i < emails.Length; i++)
            {

                string localName = emails[i].Substring(0, emails[i].IndexOf("@"));

                if (localName.Contains("+"))
                    localName = localName.Substring(0, emails[i].IndexOf("+"));

                if (localName.Contains("."))
                    localName = localName.Replace(".", string.Empty);

                string domainName = emails[i].Substring(emails[i].IndexOf("@"));
                string finalEmail = localName + domainName;
                validEmails.Add(finalEmail);
            }

            return validEmails.Count;
        }
    }
}
