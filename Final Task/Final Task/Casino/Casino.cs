using Final_Task.Core;
using Final_Task.Games;
using Final_Task.Profile;
using Final_Task.SaveLoad;

namespace Final_Task.CasinoNamespace
{
    public class Casino : IGame
    {
        private PlayerProfile _player;

        private ISaveLoadService<string> _saveService;

        private CasinoGameBase _blackjack;

        private CasinoGameBase _dice;

        private int _bet;

        private const int MAX_BANK = 1000000;

        public Casino()
        {
            _saveService =
                new FileSystemSaveLoadService("Saves");

            _blackjack =
                new BlackJackGame(20);

            _dice =
                new DiceGame(2, 1, 6);

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _blackjack.OnWin += PlayerWin;

            _blackjack.OnLoose += PlayerLose;

            _blackjack.OnDraw += Draw;

            _dice.OnWin += PlayerWin;

            _dice.OnLoose += PlayerLose;

            _dice.OnDraw += Draw;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to casino!");

            LoadProfile();

            if (_player.Bank <= 0)
            {
                Console.WriteLine("No money? Go a way!");

                return;
            }

            SelectGame();

            SaveProfile();

            Console.WriteLine("Goodbye!");
        }

        private void LoadProfile()
        {
            var data =
                _saveService.LoadData("profile");

            if (data == null)
            {
                Console.WriteLine("Enter name:");

                string name =
                    Console.ReadLine();

                _player =
                    new PlayerProfile(name);

                return;
            }

            _player =
                PlayerProfile.FromString(data);

            Console.WriteLine($"Welcome back {_player.Name}");

            Console.WriteLine($"Bank {_player.Bank}");
        }

        private void SaveProfile()
        {
            _saveService.SaveData(
                _player.ToString(),
                "profile");
        }

        private void SelectGame()
        {
            Console.WriteLine("Select game");

            Console.WriteLine("1 Blackjack");

            Console.WriteLine("2 Dice");

            string input =
                Console.ReadLine();

            MakeBet();

            if (input == "1")
            {
                _blackjack.PlayGame();
            }
            else if (input == "2")
            {
                _dice.PlayGame();
            }
        }

        private void MakeBet()
        {
            Console.WriteLine("Your bank:");

            Console.WriteLine(_player.Bank);

            Console.WriteLine("Enter bet:");

            while (true)
            {
                if (int.TryParse(
                    Console.ReadLine(),
                    out _bet))
                {
                    if (_bet <= _player.Bank)
                        break;
                }

                Console.WriteLine("Wrong bet");
            }
        }

        private void PlayerWin()
        {
            Console.WriteLine("You win!");

            _player.Bank += _bet;

            CheckBankLimits();
        }

        private void PlayerLose()
        {
            Console.WriteLine("You lose :(");

            _player.Bank -= _bet;
        }

        private void Draw()
        {
            Console.WriteLine("Bet returned");
        }

        private void CheckBankLimits()
        {
            if (_player.Bank > MAX_BANK)
            {
                int extra =
                    _player.Bank - MAX_BANK;

                _player.Bank =
                    MAX_BANK;

                Console.WriteLine(
                    $"You broke casino! Extra {extra}");
            }

            if (_player.Bank > MAX_BANK)
            {
                _player.Bank /= 2;

                Console.WriteLine(
                    "You wasted half");
            }
        }
    }
}
