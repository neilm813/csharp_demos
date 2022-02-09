using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            string[] suits =
            {
                "Hearts",
                "Diamonds",
                "Spades",
                "Clubs"
            };

            Dictionary<int, string> faceCardNames = new Dictionary<int, string>()
            {
                { 1, "Ace" },
                { 11, "Jack" },
                { 12, "Queen" },
                { 13, "King" },
            };

            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    string name = i.ToString();

                    if (faceCardNames.ContainsKey(i))
                    {
                        name = faceCardNames[i];
                    }

                    Card card = new Card(name, suit, i);
                    Cards.Add(card);
                }
            }

        }
        public void Print()
        {
            string printableDeck = "";

            foreach (Card card in Cards)
            {
                // Since printableDeck is a string when we += card C# knows
                // to execute the card's ToString method.
                printableDeck += card + "\n";
            }

            Console.WriteLine(printableDeck);
        }
    }
}