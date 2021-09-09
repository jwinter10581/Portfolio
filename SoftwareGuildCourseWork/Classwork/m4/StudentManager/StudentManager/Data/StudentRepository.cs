using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Data
{
    public class StudentRepository // All reading and writing for student file [Create, Read, Update, Delete] list, add, edit, delete
    {
        private string _filePath;
        public StudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public ListStudentResponse List()
        {
            ListStudentResponse response = new ListStudentResponse();
            response.Success = true;
            
            response.Students = new List<Student>();

            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Student newStudent = new Student();

                        string[] columns = line.Split(','); // pos 0 is firstName, pos 1 is LastName, etc...

                        newStudent.FirstName = columns[0];
                        newStudent.LastName = columns[1];
                        newStudent.Major = columns[2];
                        newStudent.GPA = decimal.Parse(columns[3]);

                        response.Students.Add(newStudent);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public void Add(Student student)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCSVforStudent(student);

                sw.WriteLine(line);
            }
        }

        public void Edit(Student student, int index)
        {
            var response = List();

            response.Students[index] = student;

            CreateStudentFile(response.Students);
        }

        public void Delete(int index)
        {
            var response = List();
            response.Students.RemoveAt(index);

            CreateStudentFile(response.Students);
        }

        private string CreateCSVforStudent(Student student)
        {
            return string.Format("{0},{1},{2},{3}",
                    student.FirstName, student.LastName, student.Major, student.GPA.ToString());
        }

        private void CreateStudentFile(List<Student> students)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("FirstName,LastName,Major,GPA");
                foreach (var student in students)
                {
                    sr.WriteLine(CreateCSVforStudent(student));
                }
            }
        }
    }
}
