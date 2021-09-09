using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Controller;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactController controller = new ContactController();
            controller.Run();
        }
    }
}
