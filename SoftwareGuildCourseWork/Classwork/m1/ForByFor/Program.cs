using System;

namespace ForByFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");

                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                }
                Console.WriteLine("");
            }
        }
    }
}
