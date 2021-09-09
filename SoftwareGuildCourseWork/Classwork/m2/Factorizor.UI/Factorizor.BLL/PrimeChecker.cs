using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PrimeChecker
    {
        public bool PrimeFactor(string[] factorArray)
        {
            int counter = 0;
            bool prime = false;

            for (int p = 0; p < factorArray.Length-1; p++)
            {
                counter++;
            }

            if (counter == 2)
            {
                prime = true;
            }

            return prime;
        }
    }
}
