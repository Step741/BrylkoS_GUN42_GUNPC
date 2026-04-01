namespace Final_Task.GameDice
{
    public struct Dice
    {
        private int Min;

        private int Max;

        private static Random random = new Random();

        public int Number => random.Next(Min, Max + 1);

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue || min > max)
            {
                throw new WrongDiceNumberException($"Wrong dice values {min}-{max}");
            }

            Min = min;

            Max = max;
        }
    }
}
