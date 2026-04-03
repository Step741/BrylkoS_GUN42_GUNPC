using Final_Task.GameDice;
using Final_Task.Games;
using System;
using System.Collections.Generic;

namespace Final_Task.Games
{
    public class DiceGame : CasinoGameBase
    {
        private List<Dice> _playerDices;

        private List<Dice> _enemyDices;

        private int _diceCount;

        private int _min;

        private int _max;

        public DiceGame(int diceCount, int min, int max)
        {
            if (diceCount <= 0)
                throw new ArgumentException("Dice count must be > 0");

            if (min <= 0 || max < min)
                throw new ArgumentException("Wrong dice range");

            _diceCount = diceCount;

            _min = min;

            _max = max;

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _playerDices = new List<Dice>();

            _enemyDices = new List<Dice>();

            for (int i = 0; i < _diceCount; i++)
            {
                _playerDices.Add(
                    new Dice(_min, _max));

                _enemyDices.Add(
                    new Dice(_min, _max));
            }
        }

        public override void PlayGame()
        {
            Console.WriteLine("===== DICE GAME =====");

            int playerResult =
                RollDices(_playerDices, "Player");

            int enemyResult =
                RollDices(_enemyDices, "Enemy");

            Console.WriteLine($"Player total: {playerResult}");

            Console.WriteLine($"Enemy total: {enemyResult}");
            Console.WriteLine();

            if (playerResult > enemyResult)
            {
                OnWinInvoke();
            }
            else if (enemyResult > playerResult)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private int RollDices(
            List<Dice> dices,
            string owner)
        {
            int result = 0;

            Console.WriteLine($"{owner} rolls:");

            foreach (var dice in dices)
            {
                int roll =
                    dice.Number;

                Console.WriteLine(roll);

                result += roll;
            }

            Console.WriteLine();

            return result;
        }
    }
}