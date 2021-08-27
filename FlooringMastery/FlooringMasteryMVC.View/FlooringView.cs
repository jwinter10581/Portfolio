using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.View
{
    public class FlooringView
    {
        private FlooringValidation _flooringValidation;
        public FlooringView()
        {
            _flooringValidation = new FlooringValidation();
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(Helpers.asteriskLine);
            Console.WriteLine("* Flooring Program");
            Console.WriteLine("*");
            Console.WriteLine("* 1. Display Orders");
            Console.WriteLine("* 2. Add an Order");
            Console.WriteLine("* 3. Edit an Order");
            Console.WriteLine("* 4. Remove an Order");
            Console.WriteLine("* 5. Quit");
            Console.WriteLine("*");
            Console.WriteLine(Helpers.asteriskLine);
        }

        public int ShowMenuAndGetChoice()
        {
            ShowMenu();
            return _flooringValidation.ReadInt("\nEnter selection (1-5): ", 1, 5);
        }

        public Order CreateNewOrder(List<Product> products, List<Tax> taxes)
        {
            Order newOrder = new Order();

            Console.Clear();
            Console.WriteLine("Create an order");
            Console.WriteLine("********************");

            do
            {
                newOrder.OrderDate = _flooringValidation.ReadDate("Please enter a date.  It must be in the future: ");

                if (newOrder.OrderDate < DateTime.Now)
                {
                    Console.WriteLine("Please enter a future date.");
                    Helpers.PressAnyKey();
                }
            } while (newOrder.OrderDate < DateTime.Now);

            newOrder.CustomerName = _flooringValidation.ReadCustomerName("Please enter a name.  It can contain [a-z], [0-9], as well as periods and commas: ");

            DisplayTaxInformation(taxes);        
            newOrder.TaxInfo = _flooringValidation.ReadState("Please enter a state.  You can either enter in the state name or it's abbreviation: ", taxes);

            DisplayProductInformation(products);
            newOrder.ProductInfo = _flooringValidation.ReadProduct("Please enter a product type exactly as displayed in the list: ", products);

            newOrder.Area = _flooringValidation.ReadArea("Enter an area as a positive decimal.  Minimum order size is 100 square feet: ");

            return newOrder;
        }

        public Order EditOrder(Order oldOrder, List<Product> products, List<Tax> taxes)
        {
            Console.Clear();
            Console.WriteLine("Edit an order");
            Console.WriteLine("********************");

            oldOrder.CustomerName = _flooringValidation.ReadCustomerName("Please enter a name.  It can contain [a-z], [0-9], as well as periods and commas: ", oldOrder.CustomerName);

            DisplayTaxInformation(taxes);
            oldOrder.TaxInfo = _flooringValidation.ReadState("Please enter a state.  You can either enter in the state name or it's abbreviation: ", taxes, oldOrder.TaxInfo);

            DisplayProductInformation(products);
            oldOrder.ProductInfo = _flooringValidation.ReadProduct("Please enter a product type exactly as displayed in the list: ", products, oldOrder.ProductInfo);

            oldOrder.Area = _flooringValidation.ReadArea("Enter an area as a positive decimal.  Minimum order size is 100 square feet: ", oldOrder.Area);

            return oldOrder;
        }
        
        public Order SelectOrder(List<Order> orders, string actionName)
        {
            int userInput = _flooringValidation.ReadOrderNumber($"Which order would you like to {actionName}? ", orders);

            return orders.FirstOrDefault(o => o.OrderNumber == userInput);
        }

        public Order ConfirmOrder(Order order, string actionName)
        {
            Console.Clear();
            //DisplayOrderInformation(order);

            //Console.WriteLine($"Please enter (y) to confirm this order being {actionName} to the system, or (n) to cancel and return to the main menu.");
            string userInput = "";

            do
            {
                DisplayOrderInformation(order);

                Console.WriteLine($"Please enter (y) to confirm this order being {actionName} to the system, or (n) to cancel and return to the main menu.");
                userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "y")
                {
                    break;
                }
                else if (userInput == "n")
                {
                    order = null;
                }
                else
                {
                    Console.WriteLine("Please enter either y to confirm, or n to cancel.");
                    Helpers.PressAnyKey();
                    userInput = "";
                }
            } while (userInput == "");

            return order;
        }

        public void DisplayOrderInformation(Order order)
        {
            Console.WriteLine(Helpers.asteriskLine);
            Console.WriteLine($"{ order.OrderNumber } | { order.OrderDate:MM/dd/yyyy}");
            Console.WriteLine($"{ order.CustomerName }");
            Console.WriteLine($"State: { order.TaxInfo.StateName }");
            Console.WriteLine($"Area: { order.Area } ft²");
            Console.WriteLine($"Product: { order.ProductInfo.ProductType }");
            Console.WriteLine($"Materials: { order.MaterialCost:C}");
            Console.WriteLine($"Labor: { order.LaborCost:C}");
            Console.WriteLine($"Tax: { order.TaxCost:C}");
            Console.WriteLine($"Total: { order.Total:C}");
            Console.WriteLine(Helpers.asteriskLine);
        }

        public void DisplayOrderInformation(List<Order> orders)
        {
            if (orders is null)
            {
                Console.WriteLine("No orders to display.");
            }
            else
            {

                foreach (Order order in orders.OrderBy(n => n.OrderNumber))
                {
                    DisplayOrderInformation(order);
                    Console.WriteLine("");
                }
            }
        }

        public void DisplayProductInformation(List<Product> products)
        {
            if (products is null)
            {
                Console.WriteLine("No products to display.");
            }
            else
            {
                Console.WriteLine("{0,-15} | {1,12} | {2,12}\n", "Product Type", "Cost Per Ft²", "Labor Cost Ft²");
                foreach (Product product in products)
                {
                    Console.WriteLine("{0,-15:C} | {1,12:C} | {2,14:C}\n", product.ProductType, product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
                }
            }
        }

        public void DisplayTaxInformation(List<Tax> taxes)
        {
            if (taxes is null)
            {
                Console.WriteLine("No taxes to display.");
            }
            else
            {
                Console.WriteLine("{0,-13} | {1,12} | {2,9}\n", "State Name", "Abbreviation", "Tax Rate");
                foreach (Tax tax in taxes)
                {
                    Console.WriteLine("{0,-13} | {1,12} | {2,8}%\n", tax.StateName, tax.StateAbbreviation, tax.TaxRate);
                }
            }
        }

        public void ShowSuccess(string actionName)
        {
            Console.WriteLine($"{actionName} was a success!");
            Helpers.PressAnyKey();
        }

        public void ShowFailure(string actionName)
        {
            Console.WriteLine($"{actionName} did not succeed.");
            Helpers.PressAnyKey();
        }

        public void ShowFailure(string actionName, string failureMessage)
        {
            Console.WriteLine($"{actionName} did not succeed.");
            Console.WriteLine(failureMessage);
            Helpers.PressAnyKey();
        }
    }
}
