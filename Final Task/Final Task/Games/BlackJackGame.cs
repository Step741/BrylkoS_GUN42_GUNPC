using Final_Task.Cards;

namespace Final_Task.Games
{
    public class BlackJackGame : CasinoGameBase
    {
        private Queue<Card> Deck;

        private List<Card> _cards;

        private int _cardCount;

        private Random _random = new Random();

        public BlackJackGame(int cardCount)
        {
            if (cardCount <= 0)
                throw new ArgumentException("Card count must be > 0");

            _cardCount = cardCount;
        }

        protected override void FactoryMethod()
        {
            _cards = new List<Card>();

            var suits = Enum.GetValues<CardSuit>();
            var values = Enum.GetValues<CardValue>();

            for (int i = 0; i < _cardCount; i++)
            {
                var suit =
                    suits[_random.Next(suits.Length)];

                var value =
                    values[_random.Next(values.Length)];

                _cards.Add(new Card(suit, value));
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Deck = new Queue<Card>(
                _cards.OrderBy(x => _random.Next())
            );
        }

        public override void PlayGame()
        {
            var playerCards = new List<Card>();

            var enemyCards = new List<Card>();

            playerCards.Add(DrawCard());
            playerCards.Add(DrawCard());

            enemyCards.Add(DrawCard());
            enemyCards.Add(DrawCard());

            while (true)
            {
                int playerScore = CalculateScore(playerCards);

                int enemyScore = CalculateScore(enemyCards);

                Console.WriteLine($"Player score {playerScore}");

                Console.WriteLine($"Enemy score {enemyScore}");

                if (playerScore == enemyScore && playerScore < 21)
                {
                    playerCards.Add(DrawCard());

                    enemyCards.Add(DrawCard());

                    continue;
                }

                if (playerScore <= 21 &&
                   (enemyScore > 21 ||
                    playerScore > enemyScore))
                {
                    OnWinInvoke();

                    return;
                }

                if (enemyScore <= 21 &&
                   (playerScore > 21 ||
                    enemyScore > playerScore))
                {
                    OnLooseInvoke();

                    return;
                }

                OnDrawInvoke();

                return;
            }
        }

        private Card DrawCard()
        {
            return Deck.Dequeue();
        }

        private int CalculateScore(List<Card> cards)
        {
            int sum = 0;

            foreach (var card in cards)
            {
                sum += (int)card.Value;
            }

            return sum;
        }
    }
}
