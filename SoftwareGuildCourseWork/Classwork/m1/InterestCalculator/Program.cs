using System;

namespace InterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my interest calculator!");
            Console.WriteLine("I have just a few questions to get started...");

            decimal initialBalance, numberYears, annualInterest,
                interestRateUsed = 0, currentBalance = 0, interestEarned = 0;

            int compound = 0;

            Console.Write("How much do you want to invest? ");
            while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.Write("Please enter the initial balance as an integer: ");
            }

            Console.Write("How many years will you be investing? ");
            while (!decimal.TryParse(Console.ReadLine(), out numberYears))
            {
                Console.Write("Please enter the number of years as an integer: ");
            }

            Console.Write("What is the annual interest rate? ");
            while (!decimal.TryParse(Console.ReadLine(), out annualInterest))
            {
                Console.Write("Please enter the annual interest rate as an integer: ");
            }

            Console.Write("Would you like quarterly, monthly, or daily interest? "); ;
            string timePeriod = Console.ReadLine();
            bool timeValidation = false;
            while (!timeValidation)
            { 
                if (timePeriod == "quarterly")
                {
                    interestRateUsed = annualInterest / 4;
                    compound = 4;
                    break;
                }
                else if (timePeriod == "monthly")
                {
                    interestRateUsed = annualInterest / 12;
                    compound = 12;
                    break;
                }
                else if (timePeriod == "daily")
                {
                    interestRateUsed = annualInterest / 365;
                    compound = 365;
                    break;
                }
                else
                {
                    Console.Write("Please enter quarterly, monthly, or daily: ");
                    timePeriod = Console.ReadLine();
                }
            }

            Console.WriteLine("Calculating...");
            Console.WriteLine("Calculating...");

            for (int y = 1; y <= numberYears; y++)
            {
                for (int i = 1; i <= compound; i++)
                {
                    currentBalance = interestEarned + initialBalance;
                    interestEarned += (currentBalance * (1 + (interestRateUsed / 100)) - currentBalance);
                }

                currentBalance = interestEarned + initialBalance;

                Console.WriteLine($"Year {y}:");
                Console.WriteLine($"Began with {initialBalance:C}");
                Console.WriteLine($"Earned {interestEarned:C}");
                Console.WriteLine($"Ended with {currentBalance:C}");

                initialBalance = currentBalance;
                interestEarned = 0;
            }
        }
    }
}
