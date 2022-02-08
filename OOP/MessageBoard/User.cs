using System;
using System.Collections.Generic;

namespace MessageBoard
{
    public class User : Person
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();

        public User() { }

        public User(string username, string email, string firstName, string lastName, int? age = null) : base(firstName, lastName, age)
        {
            Username = username;
            Email = email;
        }

        public Message SendMessage(Message newMessage)
        {
            // this refers to whichever User instance called SendMessage
            // e.g., user1.SendMessage, this = user1.
            newMessage.Author = this;
            Messages.Add(newMessage);
            return newMessage;
        }

        public void PrintMessages()
        {
            foreach (Message message in Messages)
            {
                Console.WriteLine(message);
            }
        }

        public override string ToString()
        {
            return $@"
Full Name:  {FullName()}
Age:        {Age}
Username:   {Username}
Email:      {Email}
            ";
        }
    }
}