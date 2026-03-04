namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            int[] fNumbers = new int[10] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            for (int index = 0; index < fNumbers.Length; index++)
            {
                Console.WriteLine(fNumbers[index]);
            };

            //Задание 2
            int[] numbers = new int[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            for (int index = 0; index < numbers.Length; index++)
            {
                if (index % 2 == 0)
                {
                    continue;
                }
                Console.WriteLine(numbers[index]);
            };

            //Задание 3
            for (int line = 1; line <= 5; line++)
            {
                for (int column = 1; column <= 5; column++)
                {
                    Console.Write(line * column + " ");
                }

                Console.WriteLine();
            };

            //Задание 4
            string password = "qwerty";
            string input;

            do
            {
                Console.WriteLine("Enter your password: ");
                input = Console.ReadLine();

                if (input != password)
                {
                    Console.WriteLine("Error. Try again.");
                }

            } while (input != password);

            Console.WriteLine("The password is correct!");
        }
    }
}