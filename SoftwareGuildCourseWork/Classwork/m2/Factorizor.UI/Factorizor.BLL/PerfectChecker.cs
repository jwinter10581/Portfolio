using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        public bool PerfectFactor(string[] factorArray)
        {
            int sum = 0;
            bool perfect = false;

            for (int p = 0; p < factorArray.Length-2; p++)
            {
                sum += Convert.ToInt32(factorArray[p]);
            }

            if (sum == Convert.ToInt32(factorArray[factorArray.Length-2]))
            {
                perfect = true;
            }

            return perfect;
        }
    }
}
