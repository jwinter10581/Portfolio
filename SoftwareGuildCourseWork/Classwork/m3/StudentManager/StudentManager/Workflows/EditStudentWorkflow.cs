using StudentManager.Data;
using StudentManager.Helpers;
using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Workflows
{
    public class EditStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Student GPA");

            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            ConsoleIO.PrintPickListOfStudents(students);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFromUser("Which student would you like to edit? ", students.Count());
            index--;

            Console.WriteLine();

            students[index].GPA = ConsoleIO.GetRequiredDecimalFromUser(
                string.Format($"Enter a new GPA for {students[index].FirstName} {students[index].LastName}: "));

            repo.Edit(students[index], index);
            Console.WriteLine("GPA Updated");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
