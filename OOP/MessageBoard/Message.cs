using System;

namespace MessageBoard
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User Author { get; set; }

        /* 
        Constructor method's are the method's named the same as the class.
        They automatically return the new instance.
        */
        public Message(User author, string content)
        {
            // this.Author = author;
            Author = author;
            Content = content;
        }

        public Message(string content)
        {
            Content = content;
        }

        public override string ToString()
        {
            return $@"
Author:  {Author.FullName()}
Content: {Content}
Date:    {CreatedAt}
            ";
        }
    }
}