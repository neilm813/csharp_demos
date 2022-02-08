using System.Collections.Generic;

namespace MessageBoard
{
    public class Board
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();

        public Board(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}