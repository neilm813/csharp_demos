using System;
using System.Collections.Generic;

namespace FakeDiscord
{
    public class Guild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TextChannel> TextChannels { get; set; } = new List<TextChannel>();
        public List<User> GuildMembers { get; set; } = new List<User>();

        public Guild(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Join(User newMember)
        {
            if (GuildMembers.Contains(newMember))
            {
                Console.WriteLine($"{newMember.Username} is already in the guild!");
                return;
            }

            GuildMembers.Add(newMember);
            Console.WriteLine($"{newMember.Username} has joined {Name} guild. There are now {GuildMembers.Count} guild members.");
        }

        public override string ToString()
        {
            return @$"
Id:             {Id}
Name:           {Name}
Member Count:   {GuildMembers.Count}
            ";
        }
    }
}