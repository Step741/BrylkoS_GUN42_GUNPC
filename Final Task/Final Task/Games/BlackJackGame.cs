using Final_Task.Cards;
using Final_Task.Games;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Task.Games
{
    public class BlackJackGame : CasinoGameBase
    {
        private Queue<Card> Deck;

        private List<Card> _playerCards;

        private List<Card> _enemyCards;

        private int _cardCount;

        private Random _random = new Random();

        public BlackJackGame(int cardCount)
        {
            if (cardCount <= 0)
                throw new ArgumentException("Card count must be > 0");

            _cardCount = cardCount;

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            List<Card> cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));
                }
            }

            Shuffle(cards);
        }

        private void Shuffle(List<Card> cards)
        {
            var shuffled =
                cards.OrderBy(x => _random.Next()).ToList();

            Deck =
                new Queue<Card>(shuffled);
        }

        public override void PlayGame()
        {
            _playerCards = new List<Card>();

            _enemyCards = new List<Card>();

            DealStartCards();

            GameLoop();

            ShowResults();
        }

        private void DealStartCards()
        {
            _playerCards.Add(DrawCard());
            _playerCards.Add(DrawCard());

            _enemyCards.Add(DrawCard());
            _enemyCards.Add(DrawCard());
        }

        private void GameLoop()
        {
            while (true)
            {
                int playerScore =
                    CalculateScore(_playerCards);

                int enemyScore =
                    CalculateScore(_enemyCards);

                if (playerScore == enemyScore &&
                   playerScore < 21)
                {
                    _playerCards.Add(DrawCard());

                    _enemyCards.Add(DrawCard());

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

                if (playerScore >= 21 &&
                   enemyScore >= 21)
                {
                    OnDrawInvoke();

                    return;
                }

                break;
            }
        }

        private int CalculateScore(List<Card> cards)
        {
            int score = 0;

            foreach (var card in cards)
            {
                score += GetCardValue(card);
            }

            return score;
        }

        private int GetCardValue(Card card)
        {
            switch (card.Value)
            {
                case CardValue.Six:
                    return 6;

                case CardValue.Seven:
                    return 7;

                case CardValue.Eight:
                    return 8;

                case CardValue.Nine:
                    return 9;

                case CardValue.Ten:
                case CardValue.Jack:
                case CardValue.Queen:
                case CardValue.King:
                    return 10;

                case CardValue.Ace:
                    return 11;

                default:
                    return 0;
            }
        }

        private Card DrawCard()
        {
            if (Deck.Count == 0)
            {
                FactoryMethod();
            }

            return Deck.Dequeue();
        }

        private void ShowResults()
        {
            Console.WriteLine("Player cards:");

            foreach (var card in _playerCards)
            {
                Console.WriteLine($"{card.Value} {card.Suit}");
            }

            Console.WriteLine();
            Console.WriteLine("Enemy cards:");

            foreach (var card in _enemyCards)
            {
                Console.WriteLine($"{card.Value} {card.Suit}");
            }

            Console.WriteLine();
            Console.WriteLine($"Player score: {CalculateScore(_playerCards)}");

            Console.WriteLine($"Enemy score: {CalculateScore(_enemyCards)}");
            Console.WriteLine();
        }
    }
}