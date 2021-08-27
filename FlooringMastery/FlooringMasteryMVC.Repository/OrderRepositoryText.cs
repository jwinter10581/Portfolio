using FlooringMasteryMVC.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Repository
{
    public class OrderRepositoryText : IOrderRepository // Orders_06012013.txt 
    {
        public Order AddOrder(Order newOrder)
        {
            if (newOrder.TaxInfo == null || newOrder.ProductInfo == null || newOrder.Area == 0)
            {
                return null;
            }
            else
            {
                List<Order> orders = RetrieveAllOrdersByDate(newOrder.OrderDate);
                
                if (orders.Count() == 0)
                {
                    CreateTextFile(newOrder.OrderDate);
                }

                orders.Add(newOrder);
                WriteAllOrdersByDate(orders, newOrder.OrderDate);
            }

            return newOrder;
        }

        public bool DeleteOrder(DateTime date, int number)
        {
            Order deletedOrder = RetrieveOrderByNumber(date, number);

            if (deletedOrder == null)
            {
                return false;
            }
            else
            {
                List<Order> orders = RetrieveAllOrdersByDate(date);
                orders.RemoveAll(d => d.OrderDate == deletedOrder.OrderDate && d.OrderNumber == deletedOrder.OrderNumber);

                if(orders.Count() == 0)
                {
                    File.Delete(LocateTextFile(date));
                }
                else
                {
                    WriteAllOrdersByDate(orders, date);
                }

                return true;
            }
        }

        public Order CalculateFields(Order updatedOrder)  // Used to calculate Order fields
        {
            if (updatedOrder.TaxInfo.StateName is null || updatedOrder.TaxInfo.StateAbbreviation is null || updatedOrder.ProductInfo.ProductType is null || updatedOrder.Area is 0)
            {
                return updatedOrder = null;
            }
            else
            {
                updatedOrder.MaterialCost = (updatedOrder.Area * updatedOrder.ProductInfo.CostPerSquareFoot);
                updatedOrder.LaborCost = (updatedOrder.Area * updatedOrder.ProductInfo.LaborCostPerSquareFoot);
                updatedOrder.TaxCost = ((updatedOrder.MaterialCost + updatedOrder.LaborCost) * (updatedOrder.TaxInfo.TaxRate / 100));
                updatedOrder.Total = (updatedOrder.MaterialCost + updatedOrder.LaborCost + updatedOrder.TaxCost);
            }

            List<Order> orders = RetrieveAllOrdersByDate(updatedOrder.OrderDate);

            if (orders.Count == 0 && updatedOrder.OrderNumber == 0)
            {
                updatedOrder.OrderNumber = 1;
            }
            else
            {
                foreach (var order in orders)
                {
                    if (updatedOrder.OrderNumber != 0)
                    {
                        break; // order has an order number
                    }
                    else
                    {
                        updatedOrder.OrderNumber = orders.Max(n => n.OrderNumber) + 1;
                    }
                }
            }

            return updatedOrder;
        }

        public List<Order> RetrieveAllOrdersByDate(DateTime date) // https://stackoverflow.com/questions/6542996/how-to-split-csv-whose-columns-may-contain
        {
            List<Order> orders = new List<Order>();

            if (LocateTextFile(date) == null)
            {
                return orders;
            }

            TextFieldParser parser = new TextFieldParser(LocateTextFile(date));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] fields;
            bool firstLine = true;

            try
            {
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    Order tempOrder = new Order();
                    Tax tempTax = new Tax();
                    Product tempProduct = new Product();

                    tempOrder.OrderNumber = Convert.ToInt32(fields[0]);
                    tempOrder.CustomerName = fields[1];
                    tempOrder.CustomerName = tempOrder.CustomerName.Replace('"', ' ').Trim(); // remove quotations from txt file & trim extra spaces
                    tempOrder.Area = Convert.ToDecimal(fields[5]);
                    tempOrder.MaterialCost = Convert.ToDecimal(fields[8]);
                    tempOrder.LaborCost = Convert.ToDecimal(fields[9]);
                    tempOrder.TaxCost = Convert.ToDecimal(fields[10]);
                    tempOrder.Total = Convert.ToDecimal(fields[11]);

                    tempTax.StateAbbreviation = fields[2];
                    tempTax.TaxRate = Convert.ToDecimal(fields[3]);

                    tempProduct.ProductType = fields[4];
                    tempProduct.CostPerSquareFoot = Convert.ToDecimal(fields[6]);
                    tempProduct.LaborCostPerSquareFoot = Convert.ToDecimal(fields[7]);

                    tempOrder.ProductInfo = tempProduct;
                    tempOrder.TaxInfo = tempTax;
                    tempOrder.OrderDate = date;

                    orders.Add(tempOrder);
                }

                parser.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("There may be an error in the orders text file.  Please check the text file and try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }

            if (!orders.Any())
            {
                return orders;
            }
            else
            {
                TaxRepository taxRepo = new TaxRepository();
                List<Tax> taxes = taxRepo.RetrieveTaxList();

                foreach (var order in orders)
                {
                    try
                    {
                        var match = taxes.FirstOrDefault(t => t.StateAbbreviation.ToLower() == order.TaxInfo.StateAbbreviation.ToLower());

                        if (match == null)
                        {
                            throw new Exception();  // State Abbreviation that doesn't exist is in text file
                        }
                        else
                        {
                            order.TaxInfo.StateName = match.StateName;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("There is a state abbreviation in the orders file that doesn't match.  Please check orders text file and try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return null;
                    }
                }
                return orders;
            }
        }

        public Order RetrieveOrderByNumber(DateTime date, int number)
        {
            List<Order> orders = RetrieveAllOrdersByDate(date);

            foreach (var locatedOrder in orders)
            {
                if (locatedOrder.OrderNumber == number)
                {
                    return locatedOrder;
                }
            }

            return null; // order not found
        }

        private void WriteAllOrdersByDate(List<Order> orders, DateTime date)
        {
            string fileLocation = LocateTextFile(date);

            using (StreamWriter writer = new StreamWriter(fileLocation))
            {
                writer.Write("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine();
                    writer.WriteLine(ConvertObjectToString(order));
                }
            }
        }

        private string ConvertObjectToString(Order order)
        {
            order.CustomerName = $@"""{order.CustomerName}""";

            string objectAsString = $"{order.OrderNumber},{order.CustomerName},{order.TaxInfo.StateAbbreviation},{order.TaxInfo.TaxRate},{order.ProductInfo.ProductType},{order.Area},{order.ProductInfo.CostPerSquareFoot},{order.ProductInfo.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.TaxCost},{order.Total}";

            return objectAsString;
        }

        private string CreateFileName(DateTime date)
        {
            string fileName = @".\Orders\Orders_" + date.ToString("MMddyyyy") + ".txt";
            return fileName;
        }

        private bool CheckToSeeIfFileExists(DateTime date)
        {
            string fileName = CreateFileName(date);

            if (File.Exists(fileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string LocateTextFile(DateTime date)
        {
            if (CheckToSeeIfFileExists(date))
            {
                return CreateFileName(date);
            }
            else
            {
                return null;
            }
        }

        private string CreateTextFile(DateTime date)
        {
            if (CheckToSeeIfFileExists(date))
            {
                return CreateFileName(date);
            }
            else
            {
                using (StreamWriter writer = File.CreateText(CreateFileName(date)))
                {
                    writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    return CreateFileName(date);
                }
            }
        }
    }
}
