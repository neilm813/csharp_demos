using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.Deal();

            if (dealtCard != null)
            {
                Hand.Add(dealtCard);
            }

            return dealtCard;
        }

        public Card Discard(int i)
        {
            if (i < 0 || i >= Hand.Count)
            {
                return null;
            }

            Card cardToRemove = Hand[i];
            Hand.Remove(cardToRemove);
            return cardToRemove;
        }
    }
}