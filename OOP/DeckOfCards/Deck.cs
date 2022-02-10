using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            // Reset has to build the deck in order to reset it.
            Reset();
        }

        public Deck Reset()
        {
            // Don't add more than 52 cards in case deck still has some cards in it.
            Cards = new List<Card>();

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

            return this;
        }

        public Card Deal()
        {
            if (Cards.Count > 0)
            {
                Card topCard = Cards[Cards.Count - 1];
                // Alternatively we can remove like so:
                // Cards.Remove(topCard);

                // RemoveAt does not return what is removed, sad.
                Cards.RemoveAt(Cards.Count - 1);
                return topCard;
            }

            // Empty Cards list.
            return null;
        }

        public Deck Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                int randomIndex = random.Next(Cards.Count);
                Card temp = Cards[i];

                // Swap card at random index with card at index i.
                Cards[i] = Cards[randomIndex];
                Cards[randomIndex] = temp;
            }
            return this;
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