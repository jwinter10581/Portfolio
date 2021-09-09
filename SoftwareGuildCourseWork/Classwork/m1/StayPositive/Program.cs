using System;

namespace StayPositive
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("The spaceship is about to launch... How much time is left? ");
            
            int countDown = Convert.ToInt32(Console.ReadLine());
            while(countDown < 0)
            {
                Console.Write("Please enter a value greater than 0: ");
                countDown = Convert.ToInt32(Console.ReadLine());
            }

            int tracker = 0;

            while (countDown >= 0)
            {
                while (tracker < 10 && countDown >= 0)
                {
                    Console.Write(countDown + " ");
                    tracker++;
                    countDown--;
                }
                Console.WriteLine("");
                tracker = 0;
            }
            Console.WriteLine("Blast off!");
        }
    }
}
