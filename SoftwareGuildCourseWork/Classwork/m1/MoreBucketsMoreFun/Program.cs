using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreBucketsMoreFun
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Declare ALL THE THINGS
            // (Usually it's a good idea to declare them at the beginning of the program)
            int butterflies, beetles, bugs;

            // Now assign values to some of the variables
            butterflies = 5;
            beetles = 9;

            // Next, we use the variables to create output
            bugs = butterflies + beetles;
            Console.WriteLine("There are only {0} butterflies,", butterflies);
            Console.WriteLine("but there are {0} bugs in all.", bugs);

            Console.WriteLine("Uh oh, my dog ate one.");
            butterflies--;
            Console.WriteLine("Now there are only {0} butterflies left.", butterflies);
            Console.WriteLine("But there are still {0} bugs left...", bugs);
            Console.WriteLine("Wait a minute!");
            Console.WriteLine("... maybe my computer can't do math, after all!");
            Console.ReadLine();
        }
    }
}
