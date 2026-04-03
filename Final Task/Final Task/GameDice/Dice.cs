using Final_Task.GameDice;
using System;

namespace Final_Task.GameDice
{
    public struct Dice
    {
        private int Min;

        private int Max;

        private static Random _random =
            new Random();

        public int Number =>
            _random.Next(Min, Max + 1);

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue || min > max)
            {
                throw new WrongDiceNumberException(
                    $"Wrong dice range {min}-{max}");
            }

            Min = min;

            Max = max;
        }
    }
}
