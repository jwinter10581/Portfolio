<<<<<<< Updated upstream
﻿using System;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            double userAge, userHeartMax, userZoneMin, userZoneMax;
           
            Console.WriteLine("Hey there, we're going to calculate some heart info!");
            Console.Write("First, what is your age? ");

            while (!double.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Please enter your age as a whole number. "); // mostly for simplicity, but you could enter as a decimal
            }

            userHeartMax = 220 - userAge;
            userZoneMin = Math.Round(userHeartMax * .50, MidpointRounding.AwayFromZero);
            userZoneMax = Math.Round(userHeartMax * .85, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Your maximum heart rate should be {userHeartMax}.");
            Console.WriteLine($"Your Heart Rate Zone is {userZoneMin} - {userZoneMax} beats per minute.");
        }
    }
}
=======
﻿using System;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            double userAge, userHeartMax, userZoneMin, userZoneMax;
           
            Console.WriteLine("Hey there, we're going to calculate some heart info!");
            Console.Write("First, what is your age? ");

            while (!double.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Please enter your age as a whole number. "); // mostly for simplicity, but you could enter as a decimal
            }

            userHeartMax = 220 - userAge;
            userZoneMin = Math.Round(userHeartMax * .50, MidpointRounding.AwayFromZero);
            userZoneMax = Math.Round(userHeartMax * .85, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Your maximum heart rate should be {userHeartMax}.");
            Console.WriteLine($"Your Heart Rate Zone is {userZoneMin} - {userZoneMax} beats per minute.");
        }
    }
}
>>>>>>> Stashed changes
