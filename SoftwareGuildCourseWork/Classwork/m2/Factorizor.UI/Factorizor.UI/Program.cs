using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorFlow factorize = new FactorFlow();

            factorize.FactorNumber();

            Console.ReadLine();
        }
    }
}
