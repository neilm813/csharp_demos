using System.Collections.Generic;

namespace FakeDiscord
{
    public class TextChannel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public Guild Guild { get; set; }

        public TextChannel(Guild guild, int id, string name)
        {
            Id = id;
            Name = name;
            Guild = guild;

            // If the guild needs to run some logic before the text channel is added, we should create a Guild.AddTextChannel method so the Guild can control how it works.
            guild.TextChannels.Add(this);
        }
    }
}