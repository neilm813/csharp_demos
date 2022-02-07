namespace MessageBoard
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /* 
        This is a 2nd constructor that comes in a different form (polymorphism) many-forms.

        It isn't necessary if the first constructor had a default age param.
        */
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        /* 
        ToString is built in and is executed whenever console logging, but here
        we want to override the default behavior to print pretty.
        */
        public override string ToString()
        {
            return $@"
Full Name:  {FullName()}
Age:        {Age}
            ";
        }
    }
}