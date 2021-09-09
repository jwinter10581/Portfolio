using System;

namespace MiniMadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string nounOne, adjTwo, nounThree, adjFive, nounSix,
                nounSeven, nounEight, verbNine, verbTen;
            int numberFour;

            Console.WriteLine("We're gonna play MAD LIBS! WAHOO!");
            Console.WriteLine("Please provide the information as requested.");

            Console.Write("First, a noun: ");
            nounOne = Console.ReadLine();

            Console.Write("Second, an adjective: ");
            adjTwo = Console.ReadLine();

            Console.Write("Third, another noun: ");
            nounThree = Console.ReadLine();

            Console.Write("Fourth, a whole number: ");
            numberFour = Convert.ToInt32(Console.ReadLine());

            Console.Write("Fifth, another adjective: ");
            adjFive = Console.ReadLine();

            Console.Write("Sixth, a plural noun: ");
            nounSix = Console.ReadLine();

            Console.Write("Seventh, yet another plural noun: ");
            nounSeven = Console.ReadLine();

            Console.Write("Eighth, the last of the plural nouns: ");
            nounEight = Console.ReadLine();

            Console.Write("Ninth, a verb in present tense: ");
            verbNine = Console.ReadLine();

            Console.Write("Lastly, that same verb but in past tense: ");
            verbTen = Console.ReadLine();

            Console.WriteLine("~~~Now lets make this MAD LIB~~~");
            Console.WriteLine($"{nounOne}: the final {adjTwo} frontier. These are the voyages of the starship {nounThree}. ");
            Console.WriteLine($"Its {numberFour}-year mission: to explore strange {adjFive} {nounSix}, to seek out ");
            Console.WriteLine($"{adjFive} {nounSeven} and {adjFive} {nounEight}, to boldly {verbNine} where no one has {verbTen} before.");
        }
    }
}
