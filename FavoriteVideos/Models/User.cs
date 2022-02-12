namespace FavoriteVideos.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        /* 
        If you create your own constructor you MUST add back in the
        parameterless constructor because the ASP.NET framework
        needs it.
        */
        public User() { }
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}