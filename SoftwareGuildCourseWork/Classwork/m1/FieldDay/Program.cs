using System;

namespace FieldDay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the mandatory fun morale event!");
            Console.WriteLine("Much like in grade school, we'll be assigning you by your last name.");
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();

            if (string.Compare(lastName, "Baggins") < 0)
            {
                Console.WriteLine("You're on team \"Red Dragons\", get a move on!");
            }

            else if (string.Compare(lastName, "Dresden") < 0)
            {
                Console.WriteLine("Yer on team \"Dark Wizards\", please go join Bellatrix over there.");
            }

            else if (string.Compare(lastName, "Howl") < 0)
            {
                Console.WriteLine("How quaint, you're on team \"Moving Castles\".");
            }

            else if (string.Compare(lastName, "Potter") < 0)
            {
                Console.WriteLine("Grab that broom and go join team \"Golden Snitches\".");
            }

            else if (string.Compare(lastName, "Vimes") < 0)
            {
                Console.WriteLine("There's a few rough-grizzled types over there, but you'll be on team \"Night Guards\".");
            }

            else
            {
                Console.WriteLine("You're at the end of the lot and will be joining team \"Black Holes\".");
            }
        }
    }
}
