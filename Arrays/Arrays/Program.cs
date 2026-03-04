using System.Text;
using System.Text.RegularExpressions;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            int[] fNumbers = new int[8] { 0, 1, 1, 2, 3, 5, 8, 13 };

            //Задание 2
            string[] mounths = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //Задание 3
            int[,] matrix = new int[3, 3];
            int[] numbers = { 2, 3, 4 };

            for (int lines = 0; lines < 3; lines++)
            {
                for (int column = 0; column < 3; column++)
                {
                    matrix[lines, column] = (int)Math.Pow(numbers[column], lines + 1);
                }
            }
            ;

            //Задание 4
            double[][] jArray = new double[3][];

            jArray[0] = new double[5] { 1, 2, 3, 4, 5 };

            jArray[1] = new double[2] { Math.E, Math.PI };

            jArray[2] = new double[4]
            {
                Math.Log10(1),
                Math.Log10(10),
                Math.Log10(100),
                Math.Log10(1000)
            };

            //Задание 5
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            Array.Copy(array, 0, array2, 0, 3);

            foreach (int result in array2)
            {
                Console.Write(result + " ");
            };
            //Задание 6
            Array.Resize(ref array, array.Length * 2);

            foreach (int resizeResult in array)
            {
                Console.Write(resizeResult + " ");
            };
        }
    }
}
