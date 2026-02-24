class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number");

        if (!Int32.TryParse(Console.ReadLine(), out var a)) 
        {
            Console.WriteLine("Not a number!");
            return;
        }

        Console.WriteLine("Enter the second number");

        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number!");
            return;
        }

        Console.WriteLine("Enter the operator: & | or ^");

        var s = Console.ReadLine();
        var boolVar = true;

        if (s.Length == 0 || s.Length > 1 && !boolVar)
        {
            Console.WriteLine("Error!");
            return;
        }

        switch (s[0])
        {
            case '&':
                Console.WriteLine(a & b);
                Console.WriteLine(Convert.ToString(a & b,2));
                Console.WriteLine(Convert.ToString(a & b,16));
                break;
            case '|':
                Console.WriteLine(a | b);
                Console.WriteLine(Convert.ToString(a | b,2));
                Console.WriteLine(Convert.ToString(a | b,16));
                break;
            case '^':
                Console.WriteLine(a ^ b);
                Console.WriteLine(Convert.ToString(a ^ b,2));
                Console.WriteLine(Convert.ToString(a ^ b,16));
                break;
            default:
                Console.WriteLine("Error!");
                break;

                //switch (s[0]) 
                //{
                //    case '+':
                //        Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b);
                //        break;
                //    case '-':
                //        Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b);
                //        break;
                //    case '*':
                //        Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b);
                //        break;
                //    case '/':
                //        Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b);
                //        break;
                //    case '%':
                //        Console.WriteLine("Result of {0} % {1} = {2}", a, b, a % b);
                //        break;
                //    default: Console.WriteLine("Error!");
                //        break;
        }
    }
}
