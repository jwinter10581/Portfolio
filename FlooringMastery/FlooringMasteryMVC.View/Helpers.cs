using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.View
{
    public class Helpers
    {
        public const string asteriskLine = "**************************************************";

        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //Console.Clear();
        }
    }
}
