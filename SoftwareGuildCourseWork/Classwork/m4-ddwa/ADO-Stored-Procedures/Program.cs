using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Stored_Procedures
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            string grantId, grantName;
            decimal amount;
            bool quit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Don't forget you may need to update the connection string in app.config!!!!!\n");

                Console.WriteLine("ADO.NET Example Queries");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Select query");
                Console.WriteLine("2. Select query with parameters");
                Console.WriteLine("3. Insert query");
                Console.WriteLine("4. Update query");
                Console.WriteLine("5. Delete query");
                Console.WriteLine("\nQ to quit");

                Console.Write("\nEnter choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        SelectQuery query = new SelectQuery();
                        PrintRates(query.GetEmployeeRates());
                        break;
                    case "2":
                        SelectWithParameters query2 = new SelectWithParameters();
                        Console.Write("Enter a city: ");
                        string city = Console.ReadLine();
                        PrintRates(query2.GetEmployeeRates(city));
                        break;
                    case "3":
                        InsertQuery query3 = new InsertQuery();

                        Console.Write("Enter a 3 character grant id: ");
                        grantId = Console.ReadLine();

                        Console.Write("Enter a grant name: ");
                        grantName = Console.ReadLine();

                        Console.Write("Enter a grant amount: ");
                        amount = decimal.Parse(Console.ReadLine());

                        query3.InsertGrant(grantId, grantName, amount);
                        break;
                    case "4":
                        UpdateQuery query4 = new UpdateQuery();

                        Console.Write("Enter a 3 character grant id: ");
                        grantId = Console.ReadLine();

                        Console.Write("Enter a grant name: ");
                        grantName = Console.ReadLine();

                        Console.Write("Enter a grant amount: ");
                        amount = decimal.Parse(Console.ReadLine());

                        query4.UpdateGrant(grantId, grantName, amount);
                        break;
                    case "5":
                        DeleteQuery query5 = new DeleteQuery();

                        Console.Write("Enter a 3 character grant id: ");
                        grantId = Console.ReadLine();

                        query5.DeleteGrant(grantId);
                        break;
                    case "Q":
                    case "q":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("That was not a valid choice!  Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } while (!quit);
        }

        private static void PrintRates(List<EmployeePayRate> rates)
        {
            Console.Clear();
            string headerFormat = "{0,-2} {1,-15} {2,-15} {3,10} {4,10} {5,10}";
            string lineFormat = "{0,-2} {1,-15} {2,-15} {3,10:c} {4,10:c} {5,10:c}";
            Console.WriteLine(headerFormat, "Id", "First Name", "Last Name", "Hourly", "Monthly", "Yearly");

            foreach(var rate in rates)
            {
                Console.WriteLine(lineFormat, rate.EmpId, rate.FirstName, rate.LastName, 
                    rate.HourlyRate == null ? "0" : rate.HourlyRate.Value.ToString(), 
                    rate.MonthlySalary == null ? "0" : rate.MonthlySalary.Value.ToString(), 
                    rate.YearlySalary == null ? "0" : rate.YearlySalary.Value.ToString());
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
