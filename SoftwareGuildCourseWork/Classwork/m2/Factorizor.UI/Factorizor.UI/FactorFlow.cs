using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    public class FactorFlow
    {

        public void FactorNumber()
        {
            FactorFinder Finder = new FactorFinder();
            PerfectChecker Perfect = new PerfectChecker();
            PrimeChecker Prime = new PrimeChecker();
            int factor;
            UserOutput.DisplayIntroduction();

            do
            {
                factor = UserInput.GetIntFromUser("What number would you like factored today? ");
            } while (!UserInput.IsValidFactor(factor));

            string[] factorArray = Finder.CreateFactorArray(factor);
            bool isPerfectNumber = Perfect.PerfectFactor(factorArray);
            bool isPrimeNumber = Prime.PrimeFactor(factorArray);

            UserOutput.DisplayFactors(factorArray);
            UserOutput.DisplayPerfect(isPerfectNumber, factorArray);
            UserOutput.DisplayPrime(isPrimeNumber, factorArray);
        }
    }
}
