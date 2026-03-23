using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collections
{
    class Assignment3
    {
        static void Main()
        {
            HashSet<string> emails = new HashSet<string>{
            "a@gmail.com","b@gmail.com","c@gmail.com","a@gmail.com",
            "d@gmail.com","e@gmail.com","f@gmail.com","b@gmail.com",
            "g@gmail.com","h@gmail.com"
        };

            Console.WriteLine("Unique Emails:");
            foreach (var e in emails) Console.WriteLine(e);

            Console.WriteLine(emails.Contains("c@gmail.com") ? "Registered" : "Not Registered");

            emails.Remove("d@gmail.com");

            HashSet<string> event2 = new HashSet<string> { "c@gmail.com", "x@gmail.com", "y@gmail.com", "g@gmail.com" };
            var common = emails.Intersect(event2);

            Console.WriteLine("\nCommon Participants:");
            foreach (var e in common) Console.WriteLine(e);
        }
    }

}
