using System;

namespace SimpleCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstHalf = { 3, 7, 9, 10, 16, 19, 20, 34, 35, 45, 47, 49 }; // 12 numbers
            int[] secondHalf = { 51, 54, 68, 71, 75, 78, 82, 84, 85, 89, 91, 100 }; // also 12 numbers

            int[] wholeNumbers = new int[24];
            int tracker = 0;

            for (int i = 0; i < firstHalf.Length; i++)
            {
                wholeNumbers[i] = firstHalf[i];
                tracker++;
            }

            for (int i = 0; i < secondHalf.Length; i++)
            {
                wholeNumbers[tracker] = secondHalf[i];
                tracker++;
            }
         
            Console.WriteLine("All together now!");

            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                Console.Write(wholeNumbers[i] + " ");
            }

        }
    }
}
