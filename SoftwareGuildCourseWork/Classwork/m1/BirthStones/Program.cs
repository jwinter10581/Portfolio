using System;

namespace BirthStones
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthNumber;

            Console.WriteLine("Welcome to the wonderful world of birthstones.");
            Console.WriteLine("Which birthstone would you like to know?");
            Console.Write("Please enter a number corresponding with the month: ");
            monthNumber = Convert.ToInt32(Console.ReadLine());

            switch (monthNumber)
            {
                case 1:
                    Console.WriteLine("January's birthstone is Garnet.");
                        break;
                case 2:
                    Console.WriteLine("February's birthstone is Amethyst.");
                    break;
                case 3:
                    Console.WriteLine("March's birthstone is Aquamarine.");
                    break;
                case 4:
                    Console.WriteLine("April's birthstone is Diamond.");
                    break;
                case 5:
                    Console.WriteLine("May's birthstone is Emerald.");
                    break;
                case 6:
                    Console.WriteLine("June's birthstone is Pearl.");
                    break;
                case 7:
                    Console.WriteLine("July's birthstone is Ruby.");
                    break;
                case 8:
                    Console.WriteLine("August's birthstone is Peridot.");
                    break;
                case 9:
                    Console.WriteLine("September's birthstone is Sapphire.");
                    break;
                case 10:
                    Console.WriteLine("October's birthstone is Opal.");
                    break;
                case 11:
                    Console.WriteLine("November's birthstone is Topaz.");
                    break;
                case 12:
                    Console.WriteLine("December's birthstone is Turquoise.");
                    break;
                default:
                    Console.WriteLine($"{monthNumber} doesn't correspond to a month.");
                    break;
            }
        }
    }
}
