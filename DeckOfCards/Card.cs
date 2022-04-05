namespace DeckOfCards
{
    public class Card
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public Card() { }
        public Card(string name, string suit, int value)
        {
            Name = name;
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $@"
Name:  {Name} 
Suite: {Suit}
Value: {Value}";
        }
    }
}