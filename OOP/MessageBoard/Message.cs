using System;

namespace MessageBoard
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /* 
        Constructor method's are the method's named the same as the class.
        They automatically return the new instance.
        */
        public Message(string content)
        {
            // this.Content = content;
            Content = content;
        }
    }
}