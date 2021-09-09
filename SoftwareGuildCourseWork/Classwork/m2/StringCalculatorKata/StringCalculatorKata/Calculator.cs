using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int sum = 0;

            if (numbers == "")
            {
                return sum;
            }

            if (numbers.Contains(","))
            {
                // split and sum
                string[] elements = numbers.Split(',');

                for(int i = 0; i <elements.Length; i++)
                {
                    sum += int.Parse(elements[i]);
                }
            }
            else
            {
                sum += int.Parse(numbers);
            }
            return sum;
        }
    }
}
