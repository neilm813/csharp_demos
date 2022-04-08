using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVideos.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /*
        If you add your own constructor when using ASP.NET
        you MUST add back the empty constructor (parameterless) because ASP.NET
        uses that one to automatically construct your models.
        */
        public User()
        {
            Console.WriteLine("Constructing User!");
        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}