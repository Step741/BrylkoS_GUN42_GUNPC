namespace Final_Task.Dice
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message)
            : base(message)
        {
        }
    }
}