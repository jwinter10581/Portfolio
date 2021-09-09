using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Helper
    {
        public const string displayBar = "==========================================================================================";

        public static void DisplayProducts(IEnumerable<Product> Products)  // This method works if the products have the same 5 categories
        {
            var list = Products;

            string format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(format, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine(displayBar);

            foreach (var product in list)
            {
                Console.WriteLine(format, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }
    }
}
