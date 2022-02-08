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

        public User TopPoster()
        {
            User topUser = null;
            Dictionary<User, int> userMessageFrequencyTable = new Dictionary<User, int>();
            int maxMessageCount = 0;

            foreach (Message message in Messages)
            {
                bool isUserInTable = userMessageFrequencyTable.ContainsKey(message.Author);

                if (isUserInTable)
                {
                    userMessageFrequencyTable[message.Author] += 1;
                }
                else
                {
                    userMessageFrequencyTable[message.Author] = 1;
                }

                int updatedMessageCount = userMessageFrequencyTable[message.Author];

                if (updatedMessageCount > maxMessageCount)
                {
                    maxMessageCount = updatedMessageCount;
                    topUser = message.Author;
                }
            }

            return topUser;
        }
    }
}