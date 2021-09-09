using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentingCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Comments are written to explain code
            // using plain English.  For single lines of comments
            // we use // in front of comments.
            // C# will run any line that doesn't start with // as code.
            Console.WriteLine("Normal code is compiled and runs ...");
            Console.WriteLine("Comments however..."); // do not execute!

            // Comments can be on their own line
            Console.WriteLine("...");  // or they can share a line like this

            // However if you put the // BEFORE a line of code
            // Console.WriteLine("then it is considered a comment");
            // Console.WriteLine("and it won't execute!");

            /*
                This is an example of a multi-line comment, which is useful if
                you want to comment out multiple lines of code quickly.
                Console.WriteLine("C# ignores everything inside the comment markers.");
            */

            Console.ReadLine();
        }
    }
}
