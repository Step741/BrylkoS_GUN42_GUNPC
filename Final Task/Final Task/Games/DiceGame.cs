using Final_Task.GameDice;

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

            _diceCount = diceCount;

            _min = min;

            _max = max;
        }

        protected override void FactoryMethod()
        {
            _playerDices = new List<Dice>();

            _enemyDices = new List<Dice>();

            for (int i = 0; i < _diceCount; i++)
            {
                _playerDices.Add(new Dice(_min, _max));

                _enemyDices.Add(new Dice(_min, _max));
            }
        }

        public override void PlayGame()
        {
            int playerSum = CalculateSum(_playerDices);

            int enemySum = CalculateSum(_enemyDices);

            Console.WriteLine($"Player result: {playerSum}");

            Console.WriteLine($"Enemy result: {enemySum}");

            if (playerSum > enemySum)
            {
                OnWinInvoke();

                return;
            }

            if (enemySum > playerSum)
            {
                OnLooseInvoke();

                return;
            }

            OnDrawInvoke();
        }

        private int CalculateSum(List<Dice> dices)
        {
            int sum = 0;

            foreach (var dice in dices)
            {
                int number = dice.Number;

                Console.WriteLine($"Dice roll: {number}");

                sum += number;
            }

            return sum;
        }
    }
}