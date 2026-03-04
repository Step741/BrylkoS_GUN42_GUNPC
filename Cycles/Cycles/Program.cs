using System.Data.Common;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("The first 10 Fibonacci numbers");
            int a = 0;
            int b = 1;
            Console.Write(a + " " + b + " ");

            for (int index = 2; index < 10; index++)
            {
                int next = a + b;
                Console.Write(next + " ");
                a = b;
                b = next;
            };

            //Задание 2
            Console.WriteLine("\nEven numbers from 1 to 20");

            for (int index = 2; index <= 20; index +=2)
            {
                Console.Write(index + " ");
            };

            //Задание 3]
            Console.WriteLine("\nMultiplication table from 1 to 5");
            for (int line = 1; line <= 5; line++)
            {
                for (int column = 1; column <= 5; column++)
                {
                    Console.Write(line * column + " ");
                }

                Console.WriteLine();
            };

            //Задание 4
            Console.WriteLine("\nPassword entry program");
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