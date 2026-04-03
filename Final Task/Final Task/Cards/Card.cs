namespace Final_Task.Cards
{
    public struct Card
    {
        public readonly Suit Suit;

        public readonly CardValue Value;

        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}