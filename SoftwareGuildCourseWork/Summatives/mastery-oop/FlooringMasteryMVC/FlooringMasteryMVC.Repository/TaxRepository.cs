using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Repository
{
    public class TaxRepository
    {
        string path = @".\Taxes\Taxes.txt";

        private List<Tax> ReadAllTaxes()
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                List<Tax> taxes = new List<Tax>();

                for (int t = 1; t < lines.Length; t++)
                {
                    string[] columns = lines[t].Split(',');

                    Tax tax = new Tax();
                    tax.StateAbbreviation = columns[0];
                    tax.StateName = columns[1];
                    tax.TaxRate = Convert.ToDecimal(columns[2]);

                    taxes.Add(tax);
                }

                return taxes;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong while accessing the tax file, please check the text file and its location.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }
        }

        private List<Tax> ReadAllTaxes(string location) // Overloaded for Testing
        {
            try
            {
                string[] lines = File.ReadAllLines(location);

                List<Tax> taxes = new List<Tax>();

                for (int t = 1; t < lines.Length; t++)
                {
                    string[] columns = lines[t].Split(',');

                    Tax tax = new Tax();
                    tax.StateAbbreviation = columns[0];
                    tax.StateName = columns[1];
                    tax.TaxRate = Convert.ToDecimal(columns[2]);

                    taxes.Add(tax);
                }

                return taxes;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong while accessing the tax file, please check the text file and its location.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }
        }

        public List<Tax> RetrieveTaxList()
        {
            return ReadAllTaxes();
        }

        public List<Tax> RetrieveTaxList(string location) //Overloaded for Testing
        {
            return ReadAllTaxes(location);
        }

        private Tax ReadTaxByID(string state)
        {
            List<Tax> taxes = RetrieveTaxList();

            foreach (var tax in taxes)
            {
                if (tax.StateName == state.Trim())
                {
                    return tax;
                }
                else if (tax.StateAbbreviation == state.Trim().ToUpper())
                {
                    return tax;
                }
            }

            return null;
        }
    }
}
