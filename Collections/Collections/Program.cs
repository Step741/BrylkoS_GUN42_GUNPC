using System;
using System.Collections.Generic;

namespace Collections
{
    internal class Program
    {   //Задача с Main
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2,3");

            if (!int.TryParse(Console.ReadLine(), out int task))
                return;

            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;

                case 2:
                    CheckTaskSecond();
                    break;

                case 3:
                    CheckTaskThird();
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            var task = new ListTask();
            task.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var task = new DictionaryTask();
            task.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var task = new LinkedListTask();
            task.TaskLoop();
        }

        //Задание 1
        private class ListTask
        {
            private readonly List<string> _list = new List<string>();

            public void TaskLoop()
            {
                Console.WriteLine("Abort execution -exit");

                _list.Add("Book");
                _list.Add("Magazine");
                _list.Add("notebook");

                Console.WriteLine("Enter new string: ");

                string input = Console.ReadLine();

                if (input == "-exit")
                    return;

                _list.Add(input);

                Console.WriteLine("List: ");

                foreach (var item in _list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Enter another string: ");

                input = Console.ReadLine();

                if (input == "-exit")
                    return;

                _list.Insert(_list.Count / 2, input);

                Console.WriteLine("list: ");

                foreach (var item in _list)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //Задание 2
        private class DictionaryTask
        {
            private readonly Dictionary<string, int> students =
                new Dictionary<string, int>();

            public void TaskLoop()
            {
                Console.WriteLine("Abort execution -exit");

                Console.WriteLine("Enter student name: ");

                string name = Console.ReadLine();

                if (name == "-exit")
                    return;

                Console.WriteLine("Enter score from 2 to 5: ");

                if (!int.TryParse(Console.ReadLine(), out int score))
                {
                    Console.WriteLine("Wrong score!");
                    return;
                }

                if (score < 2 || score > 5)
                {
                    Console.WriteLine("Score must be between 2 and 5.");
                    return;
                }

                students[name] = score;

                Console.WriteLine("Enter student name: ");

                string search = Console.ReadLine();

                if (students.ContainsKey(search))
                {
                    Console.WriteLine("Score: " + students[search]);
                }
                else
                {
                    Console.WriteLine("There is no student with that name.");
                }
            }
        }

        //Задание 3
        private class LinkedListTask
        {
            private class Node
            {
                public int Value;
                public Node Next;
                public Node Prev;

                public Node(int value)
                {
                    Value = value;
                }
            }

            private Node head;
            private Node tail;

            public void TaskLoop()
            {
                Console.WriteLine("Abort execution -exit");

                Console.WriteLine("Enter 3 to 6 elements: ");

                string input = Console.ReadLine();

                if (input == "-exit")
                    return;

                if (!int.TryParse(input, out int count))
                    return;

                if (count < 3 || count > 6)
                {
                    Console.WriteLine("Must be between from 3 to 6.");
                    return;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Enter number or -exit to quit:");

                    input = Console.ReadLine();

                    if (input == "-exit")
                        return;

                    if (!int.TryParse(input, out int value))
                    {
                        Console.WriteLine("Wrong input");
                        i--;
                        continue;
                    }

                    Add(value);
                }

                Console.WriteLine("Forward:");
                PrintForward();

                Console.WriteLine("Backward:");
                PrintBackward();
            }

            private void Add(int value)
            {
                Node node = new Node(value);

                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                    tail = node;
                }
            }

            private void PrintForward()
            {
                Node current = head;

                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }

            private void PrintBackward()
            {
                Node current = tail;

                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Prev;
                }
            }
        }
    }
}