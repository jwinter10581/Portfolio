using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Repository
{
    public class ProductRepository
    {
        string path = @".\Products\Products.txt";

        private List<Product> ReadAllProducts()
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                List<Product> products = new List<Product>();

                for (int p = 1; p < lines.Length; p++)
                {
                    string[] columns = lines[p].Split(',');

                    Product product = new Product();
                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);

                    products.Add(product);
                }

                return products;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong while accessing the product file, please check the text file and its location.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }
        }

        private List<Product> ReadAllProducts(string location) //Overloaded for testing
        {
            try
            {
                string[] lines = File.ReadAllLines(location);

                List<Product> products = new List<Product>();

                for (int p = 1; p < lines.Length; p++)
                {
                    string[] columns = lines[p].Split(',');

                    Product product = new Product();
                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);

                    products.Add(product);
                }

                return products;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong while accessing the product file, please check the text file and its location.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }
        }

        public List<Product> RetrieveProductList()
        {
            return ReadAllProducts();
        }

        public List<Product> RetrieveProductList(string location) //Overloaded for testing
        {
            return ReadAllProducts(location);
        }

        private Product ReadProductByID(string productType)
        {
            List<Product> products = RetrieveProductList();

            foreach (var product in products)
            {
                if (product.ProductType == productType)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
