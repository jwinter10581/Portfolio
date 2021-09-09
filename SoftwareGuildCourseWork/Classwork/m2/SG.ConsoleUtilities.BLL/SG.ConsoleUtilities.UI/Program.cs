using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.ConsoleUtilities.BLL;

namespace SG.ConsoleUtilities.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = UserInput.GetIntFromUser("Enter your age: ");
            Console.WriteLine($"The entered age was: {age}");
            Console.ReadLine();
        }
    }
}
