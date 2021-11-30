namespace FakeDiscord
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Constructor method's are named the same as the class and are executed when using new ClassName()

        // Default constructor lets you construct an empty user.
        // This is automatically available unless you add another constructor with params.
        public User() { }

        // This constructor method is named the same but it has a unique 'signature' b/c
        // it has different params so it knows which one we are trying to
        // execute based on what arguments are passed in.
        public User(int id, string username, string email)
        {
            // Property = parameter value.
            Id = id;
            Username = username;
            Email = email;
            // this is implicit, doesn't need to be explicitly written:
            // this.Username = username;
        }

        public override string ToString()
        {
            return @$"
Id:         {Id}
Username:   {Username}
Email:      {Email}
            ";
        }
    }
}