using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        public string[] CreateFactorArray(int number)
        {
            string factorString = "";

            for (int f = 1; f <= number; f++)
            {
                if (number % f == 0)
                {
                    factorString += $"{f},";
                }
            }

            string[] factorArray = factorString.Split(',');
            return factorArray;
        }
    }
}
