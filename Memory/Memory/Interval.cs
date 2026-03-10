using System;

namespace Memory
{
    public struct Interval
    {
        private float min;
        private float max;
        private Random random;

        //Открытые свойства
        public float Min
        {
            get { return min; }
        }

        public float Max
        {
            get { return max; }
        }

        public float Get()
        {
            return (float)(min + random.NextDouble() * (max - min));
        }

        //Конструкторы
        public Interval(int minValue, int maxValue)
        {
            random = new Random();

            if (minValue < 0)
            {
                Console.WriteLine("Incorrect input data.");
                minValue = 0;
            }

            else if (maxValue < 0)
            {
                Console.WriteLine("Incorrect input data.");
                maxValue = 0;
            }

            else if (minValue > maxValue)
            {
                Console.WriteLine("Incorrect input data. These data are swapped.");

                int change = minValue;
                minValue = maxValue;
                maxValue = change;
            }

            else if (minValue == maxValue)
            {
                Console.WriteLine("Incorrect input data.");
                maxValue += 10;
            }

            min = minValue;
            max = maxValue;
        }
    }
}

