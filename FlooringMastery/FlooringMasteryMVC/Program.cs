using FlooringMasteryMVC.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            FlooringController controller = new FlooringController();
            controller.Run();
        }
    }
}
