namespace Final_Task.GameDice
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message)
            : base(message)
        {
        }
    }
}