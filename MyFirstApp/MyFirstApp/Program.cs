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

        var sign = Console.ReadLine();

        if (sign.Length == 0 || sign.Length > 1)
        {
            Console.WriteLine("Error!");
            return;
        }

        var result = 0;

        switch (sign[0])
        {
            case '&':
                result = a & b;
                break;
            case '|':
                result = a | b;
                break;
            case '^':
                result = a ^ b;
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

        Console.WriteLine(result);
        Console.WriteLine(Convert.ToString(result,2));
        Console.WriteLine(Convert.ToString(result,16));
    }
}
