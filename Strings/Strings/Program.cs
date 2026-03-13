using System;
using System.Text;

namespace Strings
{
    internal class Program
    {   //Задание 1
        static string ConcatenateStrings(string a, string b)
        {
            return a + b;
        }

        //Задание 2
        static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\nYou are {age} years old.";
        }

        //Задание 3
        static string GetStringInfo(string input)
        {
            return $"Length: {input.Length}\n" +
                   $"Upper: {input.ToUpper()}\n" +
                   $"Lower: {input.ToLower()}";
        }

        //Задание 4
        static string GetFirstFiveChars(string input)
        {
            if (input.Length < 5)
                return input;

            return input.Substring(0, 5);
        }

        //Задание 5
        static StringBuilder BuildSentence(string[] words)
        {
            StringBuilder result = new StringBuilder();

            foreach (var word in words)
            {
                result.Append(word + " ");
            }

            return result;
        }
        //Задание 6
        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {
            return inputString.Replace(wordToReplace, replacementWord);
        }
        //Проверки
        static void Main()
        {
            Console.WriteLine("Task 1:");
            Console.WriteLine(ConcatenateStrings("Nice ", "Day"));

            Console.WriteLine("\nTask 2:");
            Console.WriteLine(GreetUser("Stepan", 35));

            Console.WriteLine("\nTask 3:");
            Console.WriteLine(GetStringInfo("NiceDay"));

            Console.WriteLine("\nTask 4:");
            Console.WriteLine(GetFirstFiveChars("Netology"));

            Console.WriteLine("\nTask 5:");

            string[] words = { "My", "name", "is", "Stepan" };

            StringBuilder check = BuildSentence(words);

            Console.WriteLine(check);

            Console.WriteLine("\nTask 6:");

            Console.WriteLine(ReplaceWords("I like to sleep a lot", "sleep", "eat"));
        }
    }
}