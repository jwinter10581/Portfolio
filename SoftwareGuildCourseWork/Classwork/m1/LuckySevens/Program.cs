using System;

namespace LuckySevens
{
    class Program
    {
        static void Main(string[] args)
        {
            int userMoney, userMax = 0, rollCounter = 0, rollMax = 0, diceOne, diceTwo;
            Random rng = new Random();

            Console.WriteLine("$$$ Welcome to Lucky Sevens!! $$$");
            Console.Write("How many dollars do you have? ");

            while (!int.TryParse(Console.ReadLine(), out userMoney))
            {
                Console.Write("Please enter your money as an integer: ");
            }

            while(userMoney > 0)
            {
                diceOne = rng.Next(1, 7);
                diceTwo = rng.Next(1, 7);
                rollCounter++;

                if (diceOne + diceTwo == 7)
                {
                    userMoney += 4;

                    if (userMoney > userMax)
                    {
                        userMax = userMoney;
                        rollMax = rollCounter;
                    }               
                }
                else
                {
                    userMoney -= 1;
                }
            }

            Console.WriteLine($"You are broke after {rollCounter} rolls.");
            Console.WriteLine($"You should have quit after {rollMax} rolls when you had ${userMax}.");

        }
    }
}
