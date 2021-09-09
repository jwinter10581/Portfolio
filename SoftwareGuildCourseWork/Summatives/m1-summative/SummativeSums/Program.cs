<<<<<<< Updated upstream
﻿using System;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] arrayTwo = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] arrayThree = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
                110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            Console.WriteLine("#1 Array Sum: " + SumArray(arrayOne));
            Console.WriteLine("#2 Array Sum: " + SumArray(arrayTwo));
            Console.WriteLine("#3 Array Sum: " + SumArray(arrayThree));
        }

        public static int SumArray (int[] array)
        {
            int sum = 0;

            for (int s = 0; s < array.Length; s++)
            {
                sum += array[s];
            }
            return sum;
        }
    }
}
=======
﻿using System;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] arrayTwo = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] arrayThree = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
                110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            Console.WriteLine("#1 Array Sum: " + SumArray(arrayOne));
            Console.WriteLine("#2 Array Sum: " + SumArray(arrayTwo));
            Console.WriteLine("#3 Array Sum: " + SumArray(arrayThree));
        }

        public static int SumArray (int[] array)
        {
            int sum = 0;

            for (int s = 0; s < array.Length; s++)
            {
                sum += array[s];
            }
            return sum;
        }
    }
}
>>>>>>> Stashed changes
