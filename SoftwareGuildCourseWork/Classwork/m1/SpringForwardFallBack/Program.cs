using System;

namespace SpringForwardFallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's spring!");

            for (int i = 0; i < 10; i++) // 0 to 9
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine("\nOh no, it's fall...");
            
            for (int i = 10; i > 0; i--) // 10 to 1
            {
                Console.Write(i + ", ");
            }
        }
    }
}
