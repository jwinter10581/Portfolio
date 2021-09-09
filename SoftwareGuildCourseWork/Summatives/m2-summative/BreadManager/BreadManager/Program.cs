using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadManager.Controller;

namespace BreadManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BreadController oven = new BreadController();
            oven.Bake();
        }
    }
}
