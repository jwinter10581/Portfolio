using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllTheMaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1 + 2 is: ");
            Console.WriteLine(1 + 2);

            Console.Write("42001 modulus 5 is: ");
            Console.WriteLine(42001 % 5);

            Console.Write("5565.0 divided by 22.0 is : ");
            Console.WriteLine(5565.0 / 22.0);

            Console.Write("223 times 31 - 42: ");
            Console.WriteLine(223 * 31 - 42);

            Console.Write("4 is greater than -1: ");
            Console.WriteLine(4 > -1);

            Console.WriteLine("\n****** Now make the computer do some harder math!");

            Console.Write("8043.52 minus 4.2 plus 23.0 divided by 56.0 times -76.13 is: ");
            Console.WriteLine(8043.52 - 4.2 + 23.0 / 56 * -76.13);

            Console.Write("11111 modulus 3 minus 67 minus 1 plus 9 is: ");
            Console.WriteLine(11111 % 3 - 67 - 1 + 9);

            Console.Write("44 minus 22 plus 11 minus 66 minus 88 plus 76 minus 11 minus 33 is : ");
            Console.WriteLine(44 - 22 + 11 - 66 - 88 + 76 - 11 - 33);

            Console.Write("22 times 3 minus 1 plus 4 times 6 minus -9 is : ");
            Console.WriteLine(22 * 3 - 1 + 4 * 6 - -9);

            Console.Write("67 is greater than 4 * 5: ");
            Console.WriteLine(67 > 4 * 5);

            Console.Write("78 is less than 4 * 5: ");
            Console.WriteLine(78 < 4 * 5);

            Console.ReadLine();
        }
    }
}
