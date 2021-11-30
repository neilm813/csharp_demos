using System.Collections.Generic;

namespace FakeDiscord
{
    public class TextChannel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Messages { get; set; }
    }
}