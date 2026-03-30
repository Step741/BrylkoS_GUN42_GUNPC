namespace Final_Task.Games
{
    public abstract class CasinoGameBase
    {
        public event Action OnWin;

        public event Action OnLoose;

        public event Action OnDraw;

        protected CasinoGameBase()
        {
            FactoryMethod();
        }

        public abstract void PlayGame();

        protected abstract void FactoryMethod();

        protected void OnWinInvoke()
        {
            Console.WriteLine("Player wins!");

            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        {
            Console.WriteLine("Player loses!");

            OnLoose?.Invoke();
        }

        protected void OnDrawInvoke()
        {
            Console.WriteLine("Draw!");

            OnDraw?.Invoke();
        }
    }
}