using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Helpers
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "============================================================";
        public const string StudentLineFormat = "{0,-20} {1,-15} {2,5}";
        public const string PickStudentLineFormat = "{0, -2} {1,-20} {2,-15} {3,5}";

        public static void PrintStudentListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(StudentLineFormat, "Name", "Major", "GPA");
            Console.WriteLine(SeparatorBar);
        }

        public static void PrintPickListOfStudents(List<Student> students)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(PickStudentLineFormat, "", "Name", "Major", "GPA");
            Console.WriteLine(SeparatorBar);

            for (int i = 0; i < students.Count; i++) // starting at 1 makes more sense for user
            {
                Console.WriteLine(PickStudentLineFormat, i + 1, students[i].LastName + "," + students[i].FirstName, students[i].Major, students[i].GPA);
            }

            Console.WriteLine();
            Console.WriteLine(SeparatorBar);
        }

        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            decimal output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if(output < 0 || output > 4)
                    {
                        Console.WriteLine("GPA must be between 0.0 and 4.0.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return input;
                }
            }
        }

        public static int GetStudentIndexFromUser(string prompt, int count)
        {
            int output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!Int32.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid integer.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 0 || output > 4)
                    {
                        Console.WriteLine("Please choose a student by number between and {0} and {1}.", 1, count);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }
    }
}
