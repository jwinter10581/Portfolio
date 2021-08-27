using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.View
{
    public class FlooringValidation
    {
        //private FlooringView _view;
        //public FlooringValidation()
        //{
        //    _view = new FlooringView();
        //}

        public decimal ReadArea(string prompt)
        {
            decimal output = 0.0m;

            do
            {
                Console.WriteLine(prompt);

                string userInput = Console.ReadLine().Trim();

                if (decimal.TryParse(userInput, out output))
                {
                    if (output <= 0)
                    {
                        Console.WriteLine("Please enter a positive decimal and try again.");
                        Helpers.PressAnyKey();
                        output = 0.0m;
                    }
                    else if (output < 100)
                    {
                        Console.WriteLine("Minimum order size is 100 square feet. Please try again.");
                        Helpers.PressAnyKey();
                        output = 0.0m;
                    }
                    else
                    {
                        break; //Successfully parsed
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please enter a positive decimal and try again.");
                    Helpers.PressAnyKey();
                }
            } while (output == 0.0m);

            Console.Clear();
            return output;
        }

        public decimal ReadArea(string prompt, decimal oldArea) // Overloaded for editing an Order
        {
            decimal output = 0.0m;

            do
            {
                Console.WriteLine(prompt);

                string userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    return oldArea;
                }
                if (decimal.TryParse(userInput, out output))
                {
                    if (output <= 0)
                    {
                        Console.WriteLine("Please enter a positive decimal and try again.");
                        Helpers.PressAnyKey();
                        output = 0.0m;
                    }
                    else if (output < 100)
                    {
                        Console.WriteLine("Minimum order size is 100 square feet. Please try again.");
                        Helpers.PressAnyKey();
                        output = 0.0m;
                    }
                    else
                    {
                        break; //Successfully parsed
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please enter a positive decimal and try again.");
                    Helpers.PressAnyKey();
                }
            } while (output == 0.0m);

            return output;
        } 

        public string ReadCustomerName(string prompt) //allowed to have [a-z][0-9][,][.]
        {
            string userInput = "";

            do
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That wasn't a valid input, please try again.");
                    Helpers.PressAnyKey();
                }       
                else if (IsValidCustomerName(userInput) == false)                 
                {
                    Console.WriteLine("Customer names can only include letters, numbers, periods (.), and commas (,).");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // successfully parsed
                }
            } while (userInput == "");

            Console.Clear();
            return userInput;
        }

        public string ReadCustomerName(string prompt, string oldName) // Overloaded for editing an Order
        {
            string userInput = "";

            do
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();
            
                if (userInput == "")
                {
                    userInput = oldName;
                    break;
                }
                else if (IsValidCustomerName(userInput) == false)
                {
                    Console.WriteLine("Customer names can only include letters, numbers, periods (.), and commas (,).");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // successfully parsed
                }
            } while (userInput == "");

            Console.Clear();
            return userInput;
        }

        private bool IsValidCustomerName(string inputName)
        {

            if (Regex.IsMatch(inputName, @"^[a-zA-Z0-9,.\s]*$"))  // check all characters in inputName.  If any aren't lowercase, uppercase, numbers, commas, periods or spaces return false.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime ReadDate(string prompt) // Must be in the future, also printed like MMDDYYYY
        {
            string userInput = "";
            DateTime userDate = new DateTime();

            do
            {
                Console.Write(prompt);

                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That wasn't a valid input, please try again.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }

                else if (DateTime.TryParse(userInput, out userDate))
                {
                    break;  // successfully parsed
                }

                else
                {
                    Console.WriteLine("That wasn't a valid date format.  Please try entering the date as MM/DD/YYYY or MM-DD-YYYY.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
            } while (userInput == "");

            Console.Clear();
            return userDate;
        }

        public int ReadInt(string prompt, int min, int max)
        {
            int output = 0;

            do
            {
                //FlooringView.ShowMenu();
                Console.Write(prompt);

                string userInput = Console.ReadLine().Trim();

                if (int.TryParse(userInput, out output))
                {
                    if (output < min || output > max)
                    {
                        Console.WriteLine($"Please enter a number between {min} and {max} and try again.");
                        Helpers.PressAnyKey();
                        output = 0;
                    }
                    else
                    {
                        break;  // successfully parsed
                    }
                }
                else
                {
                    Console.WriteLine($"That was not a valid input, please enter a number between {min} and {max} and try again.");
                    Helpers.PressAnyKey();
                }
            } while (output == 0);

            Console.Clear();
            return output;
        }

        public int ReadOrderNumber(string prompt, List<Order> orders)
        {
            int output = 0;
            //FlooringView view = new FlooringView();
            List<int> orderNumbers = orders.Select(n => n.OrderNumber).ToList();

            do
            {
                //view.DisplayOrderInformation(orders);
                Console.Write("Here is a list of order numbers: ");
                orderNumbers.ForEach(n => Console.Write("({0}), ", n));
                Console.WriteLine($"\n{prompt}");

                string userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out output))
                {
                    if (orderNumbers.Contains(output))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number from the list and try again.");
                        Helpers.PressAnyKey();
                        output = 0;
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please enter a number from the list and try again.");
                    Helpers.PressAnyKey();
                }
            } while (output == 0);

            Console.Clear();
            return output;
        }

        public Product ReadProduct(string prompt, List<Product> products)
        {
            Product match = null;
            string userInput = "";

            do
            {
                //_view.DisplayProductInformation(products);

                Console.WriteLine("\n" + prompt);

                userInput = Console.ReadLine().Trim().ToLower();

                match = products.FirstOrDefault(p => p.ProductType.ToLower() == userInput); // this will match up name, but we will need to update other fields

                if (match == null)
                {
                    Console.WriteLine("That wasn't a valid product, please reference the product list and try again.");
                    Console.WriteLine("Please enter the product type exactly as listed.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // Successfully Parsed
                }
            } while (userInput == "");

            Console.Clear();
            return match;
        }

        public Product ReadProduct(string prompt, List<Product> products, Product oldProduct) // Overloaded for editing an Order
        {
            Product match = null;
            string userInput = "";

            do
            {
                //_view.DisplayProductInformation(products);

                Console.WriteLine("\n" + prompt);

                userInput = Console.ReadLine().Trim().ToLower();

                match = products.FirstOrDefault(p => p.ProductType.ToLower() == userInput); // this will match up name, but we will need to update other fields

                if (userInput == "")
                {
                    Console.Clear();
                    return oldProduct;
                }
                else if (match == null)
                {
                    Console.WriteLine("That wasn't a valid product, please reference the product list and try again.");
                    Console.WriteLine("Please enter the product type exactly as listed.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // Successfully Parsed
                }
            } while (userInput == "");

            Console.Clear();
            return match;
        }

        public Tax ReadState(string prompt, List<Tax> taxes)
        {
            Tax match = null;
            string userInput = "";

            do
            {
                //_view.DisplayTaxInformation(taxes);

                Console.WriteLine("\n" + prompt);

                userInput = Console.ReadLine().Trim().ToLower();

                match = taxes.FirstOrDefault(t => t.StateAbbreviation.ToLower() == userInput); // This will match up name, but we will need to update other fields

                if (match == null)
                {
                    match = taxes.FirstOrDefault(t => t.StateName.ToLower() == userInput); // Attempt to match by full state name if state abbreviation didn't work.
                }

                if (match == null)
                {
                    Console.WriteLine("That wasn't a valid state, please reference the list of states and try again.");
                    Console.WriteLine("You can enter either the full state or the abbreviation.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // Successfully Parsed
                }
            } while (userInput == "");

            Console.Clear();
            return match;
        }

        public Tax ReadState(string prompt, List<Tax> taxes, Tax oldState) // Overloaded for editing an Order
        {
            Tax match = null;
            string userInput = "";

            do
            {
                //_view.DisplayTaxInformation(taxes);

                Console.WriteLine("\n" + prompt);

                userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "")
                {
                    Console.Clear();
                    return oldState;
                }

                match = taxes.FirstOrDefault(t => t.StateAbbreviation.ToLower() == userInput); // This will match up name, but we will need to update other fields

                if (match == null)
                {
                    match = taxes.FirstOrDefault(t => t.StateName.ToLower() == userInput); // Attempt to match by full state name if state abbreviation didn't work.
                }

                if (match == null)
                {
                    Console.WriteLine("That wasn't a valid state, please reference the list of states and try again.");
                    Console.WriteLine("You can enter either the full state or the abbreviation.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
                else
                {
                    break; // Successfully Parsed
                }
            } while (userInput == "");

            Console.Clear();
            return match;
        }

        private string ReadString(string prompt)
        {
            string userInput = "";

            do
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That wasn't a valid input, please try again.");
                    Helpers.PressAnyKey();
                }
            } while (userInput == "");

            Console.Clear();
            return userInput;
        }

        private string ReadString(string prompt, string oldString) // Overloaded for editing an Order
        {
            string userInput = "";

            Console.WriteLine(prompt);

            userInput = Console.ReadLine().Trim();

            if (userInput == "")
            {
                userInput = oldString;
            }

            Console.Clear();
            return userInput;
        }
    }
}
