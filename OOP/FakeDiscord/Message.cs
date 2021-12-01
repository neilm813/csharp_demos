using System;

namespace FakeDiscord
{
    public class Message
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public TextChannel TextChannel { get; set; }
        public Guild Guild { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Message(User author, Guild guild, TextChannel textChannel, string content)
        {
            Author = author;
            TextChannel = textChannel;
            Guild = guild;
            Content = content;

            // Add this message to the text channel it was sent to.
            textChannel.Messages.Add(this);
        }
    }
}