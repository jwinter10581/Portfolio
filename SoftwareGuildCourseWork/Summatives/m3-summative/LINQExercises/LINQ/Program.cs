using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            //ExerciseOne();
            //ExerciseTwo();
            //ExerciseThree();
            //Skip 4 - 8
            //ExerciseNine();
            //Skip 10
            //ExerciseEleven();
            //ExerciseTwelve();
            //Skip 13
            //ExerciseFourteen();
            //ExerciseFifteen();
            //ExerciseSixteen();
            //ExerciseSeventeen();
            // Skip 18 - 19
            //ExerciseTwenty();
            // Skip 21
            //ExerciseTwentyTwo();
            //ExerciseTwentyThree();
            //ExerciseTwentyFour();
            //ExerciseTwentyFive();
            // Skip 26 - 31
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var outOfStock = from product in allProducts
                             where product.UnitsInStock == 0
                             select product;

            PrintProductInformation(outOfStock);
        }

        static void ExerciseOne()
        {
            var outOfStock = DataLoader.LoadProducts().Where(s => s.UnitsInStock == 0);

            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var inStockMoreThanThree = from product in allProducts
                                       where product.UnitsInStock > 0 && product.UnitPrice > 3.00M
                                       select product;

            PrintProductInformation(inStockMoreThanThree);
        }

        static void ExerciseTwo()
        {
            var inStockMoreThanThree = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);

            PrintProductInformation(inStockMoreThanThree);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> allCustomers = DataLoader.LoadCustomers();

            var customerWA = from customer in allCustomers
                             where customer.Region == "WA"
                             select customer;

            PrintCustomerInformation(customerWA);
        }

        static void ExerciseThree()
        {
            var customerWA = DataLoader.LoadCustomers().Where(c => c.Region == "WA");

            PrintCustomerInformation(customerWA);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var anonProduct = from product in allProducts
                              select new
                              {
                                  product.ProductName
                              };

            foreach (var product in anonProduct)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var anonProductMarkup = from product in allProducts
                                    select new
                                    {
                                        product.ProductID,
                                        product.ProductName,
                                        product.Category,
                                        UnitPrice = product.UnitPrice * 1.25M,
                                        product.UnitsInStock
                                    };

            string format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(format, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine(Helper.displayBar);
            foreach (var product in anonProductMarkup)
            {
                Console.WriteLine(format, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> allproducts = DataLoader.LoadProducts();

            var productNameCategory = from product in allproducts
                                      select new
                                      {
                                          product.ProductName, // I read it as only category in upper-case... but I would add .ToUpper() here if I wanted both in upper-case.
                                          ProductCategory = product.Category.ToUpper()
                                      };

            string line = "{0,-35} {1, -15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine(Helper.displayBar);

            foreach (var product in productNameCategory)
            {
                Console.WriteLine(line, product.ProductName, product.ProductCategory);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var reorderProducts = from product in allProducts
                                  select new
                                  {
                                      product.ProductID,
                                      product.ProductName,
                                      product.Category,
                                      product.UnitPrice,
                                      product.UnitsInStock,
                                      Reorder = product.UnitsInStock < 3 ? true : false
                                  };

            string format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,10}";
            Console.WriteLine(format, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder");
            Console.WriteLine(Helper.displayBar);

            foreach (var product in reorderProducts)
            {
                Console.WriteLine(format, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.Reorder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var stockValueProducts = from product in allProducts
                                     select new
                                     {
                                         ProductID = product.ProductID,
                                         ProductName = product.ProductName,
                                         Category = product.Category,
                                         UnitPrice = product.UnitPrice,
                                         UnitsInStock = product.UnitsInStock,
                                         StockValue = product.UnitPrice * product.UnitsInStock
                                     };

            string format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,12:c}";
            Console.WriteLine(format, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine(Helper.displayBar);

            foreach (var product in stockValueProducts)
            {
                Console.WriteLine(format, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] evenNumbersA = DataLoader.NumbersA;

            foreach (int number in evenNumbersA)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }

        static void ExerciseNine()
        {
            var evenNumbersA = DataLoader.NumbersA.Where(n => n % 2 == 0);

            foreach (var number in evenNumbersA)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> allCustomers = DataLoader.LoadCustomers();

            var customerMoreThan500 = from customer in allCustomers
                                      from order in customer.Orders
                                      where order.Total < 500
                                      group customer by customer.CompanyName;

            foreach (var customer in customerMoreThan500)
            {
                Console.WriteLine(customer.Key);
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var firstThreeOddC = DataLoader.NumbersC.Where(number => number % 2 == 1).Take(3);

            foreach (int odd in firstThreeOddC)
            {
                Console.WriteLine(odd);
            }
        }

        static void ExerciseEleven()
        {
            var firstThreeOddC = (from number in DataLoader.NumbersC
                                  where number % 2 == 1
                                  select number).Take(3);

            foreach (var odd in firstThreeOddC)
            {
                Console.WriteLine(odd);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var notFirstThreeB = DataLoader.NumbersB.Skip(3);

            foreach (int number in notFirstThreeB)
            {
                Console.WriteLine(number);
            }
        }

        static void ExerciseTwelve()
        {
            var notFirstThreeB = (from number in DataLoader.NumbersB
                                  select number).Skip(3);

            foreach (var number in notFirstThreeB)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> allCustomers = DataLoader.LoadCustomers();

            var recentWAOrder = from customer in allCustomers
                                where customer.Region == "WA"
                                select new
                                {
                                    customer.CompanyName,
                                    recentOrder = customer.Orders.OrderByDescending(x => x.OrderDate).Take(1)
                                };

            foreach (var customer in recentWAOrder)
            {
                Console.WriteLine(customer.CompanyName);

                foreach (var order in customer.recentOrder)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                    Console.WriteLine(Helper.displayBar);
                }
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbersUntilSix = DataLoader.NumbersC;

            foreach (int number in numbersUntilSix)
            {
                if (number >= 6)
                {
                    break;
                }

                Console.WriteLine(number);
            }
        }

        static void ExerciseFourteen()
        {
            var numbersUntilSix = DataLoader.NumbersC.TakeWhile(n => n <= 6);

            foreach (var number in numbersUntilSix)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbersC = DataLoader.NumbersC;
            int counter = 0;

            foreach (int c in numbersC)
            {
                if (c % 3 == 0)
                {
                    var divisibleByThreeC = numbersC.Skip(counter);

                    foreach (int number in divisibleByThreeC)
                    {
                        Console.WriteLine(number);
                    }

                    break;
                }
                else
                {
                    counter++;
                }
            }
        }

        static void ExerciseFifteen()
        {
            var numbersC = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).Skip(1);

            foreach (var number in numbersC)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var alphabeticalProducts = allProducts.OrderBy(name => name.ProductName);

            Helper.DisplayProducts(alphabeticalProducts);
        }

        static void ExerciseSixteen()
        {
            var alphabeticalProducts = from product in DataLoader.LoadProducts()
                                       orderby product.ProductName
                                       select product;

            Helper.DisplayProducts(alphabeticalProducts);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var descendingStock = allProducts.OrderByDescending(product => product.UnitsInStock);

            Helper.DisplayProducts(descendingStock);
        }

        static void ExerciseSeventeen()
        {
            var descendingStock = from product in DataLoader.LoadProducts()
                                  orderby product.UnitsInStock descending
                                  select product;

            Helper.DisplayProducts(descendingStock);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var productsByCategoryAndPrice = allProducts.OrderBy(product => product.Category).ThenByDescending(product => product.UnitPrice);

            Helper.DisplayProducts(productsByCategoryAndPrice);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] allNumbersB = DataLoader.NumbersB;

            var reverseB = allNumbersB.Reverse();

            foreach (int number in reverseB)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var groupedProducts = from product in allProducts
                                  group product by product.Category;

            foreach (var group in groupedProducts)
            {
                Console.WriteLine(group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine($"\t{product.ProductName}");
                }
            }
        }

        static void ExerciseTwenty()
        {
            var groupedProducts = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in groupedProducts)
            {
                Console.WriteLine(group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine($"\t{product.ProductName}");
                }

            }
        }

        /// <summary>
        /// // https://stackoverflow.com/questions/6380844/group-posts-by-year-then-by-month  (this helped me understand how to do a nested groupby)
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            List<Customer> allCustomers = DataLoader.LoadCustomers();

            var customersWithYearAndMonth = from customer in allCustomers
                                            select new
                                            {
                                                CompanyName = customer.CompanyName,
                                                Orders = from order in customer.Orders
                                                         group order by order.OrderDate.Year into yearGroup
                                                         select new
                                                         {
                                                             Year = yearGroup.Key, // yearGroup.Key == year of the order
                                                             MonthGroups = from order in yearGroup
                                                                           group order by order.OrderDate.Month into monthGroup // group orders into months
                                                                           select new
                                                                           {
                                                                               Month = monthGroup.Key, // monthGroup.Key is the int month
                                                                               Orders = monthGroup // monthGroup are all the orders for that month
                                                                           }
                                                         } //).OrderByDescending(y => y.Year)  -- optionally add to reverse order                                                     
                                            };

            foreach (var customer in customersWithYearAndMonth)
            {
                Console.WriteLine(customer.CompanyName);

                foreach (var orderYearGroup in customer.Orders)
                {
                    Console.WriteLine(orderYearGroup.Year);

                    foreach (var orderMonthGroup in orderYearGroup.MonthGroups)
                    {
                        foreach (var order in orderMonthGroup.Orders)
                        {
                            Console.WriteLine("     {0} - {1:C}", order.OrderDate.Month, order.Total);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        #region Attempt 21
        //var groupedCustomers = from customer in allCustomers
        //                       from order in customer.Orders
        //                       group order.OrderDate by new
        //                       {
        //                           companyName = customer.CompanyName,
        //                           year = order.OrderDate.Year,
        //                           month = order.OrderDate.Month,
        //                           total = order.Total
        //                       };
        //            foreach (var customer in groupedCustomers)
        //    {
        //        Console.WriteLine(customer.Key);
        //    }
        #endregion

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var uniqueProducts = allProducts.GroupBy(category => category.Category);

            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product.Key);
            }
        }

        static void ExerciseTwentyTwo()
        {
            var uniqueProducts = from product in DataLoader.LoadProducts()
                                 group product by product.Category;
            
            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var product789 = allProducts.FirstOrDefault(product => product.ProductID == 789);

            if (product789 is null)
            {
                Console.WriteLine($"Product 789 doesn't exist.");
            }
            else
            {
                Console.WriteLine("Product 789 does exist! Hurray!");
            }
        }

        static void ExerciseTwentyThree()
        {
            var product789 = from product in DataLoader.LoadProducts()
                             where product.ProductID == 789
                             select product;

            if (!product789.Any())
            {
                Console.WriteLine($"Product 789 doesn't exist.");
            }
            else
            {
                Console.WriteLine("Product 789 does exist! Hurray!");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var categoryWithoutStock = from product in allProducts
                                       where product.UnitsInStock is 0
                                       group product by product.Category;

            foreach (var product in categoryWithoutStock)
            {
                Console.WriteLine(product.Key);
            }
        }

        static void ExerciseTwentyFour()
        {
            var categoryWithoutStock = DataLoader.LoadProducts().Where(p => p.UnitsInStock == 0).GroupBy(c => c.Category);

            foreach (var product in categoryWithoutStock)
            {
                Console.WriteLine(product.Key);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var categoriesWithOutStock = from product in allProducts
                                         where product.UnitsInStock is 0
                                         select product.Category;

            var categoriesWithAllProductsStocked = from product in allProducts
                                                   where !categoriesWithOutStock.Contains(product.Category)
                                                   group product by product.Category;

            foreach (var product in categoriesWithAllProductsStocked)
            {
                Console.WriteLine(product.Key);
            }
        }
        #region 25 attempt
        //var groupedByCategory = from product in allProducts
        //                        group product by product.Category;

        //var categoryWithoutStock = from product in allProducts
        //                           where product.UnitsInStock is 0
        //                           group product by product.Category;

        //var eliminateCategory = groupedByCategory.Except(categoryWithoutStock);

        //foreach (var category in eliminateCategory)
        //{
        //    Console.WriteLine(category.Key);
        //}
        #endregion
        static void ExerciseTwentyFive()
        {
            var categoryWithoutStock = DataLoader.LoadProducts().Where(p => p.UnitsInStock == 0).GroupBy(c => c.Category).Select(s => s.Key);

            var categoriesWithAllProductsStocked = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0).GroupBy(c => c.Category).Select(s => s.Key);

            var result = categoriesWithAllProductsStocked.Except(categoryWithoutStock);

            foreach (var product in result)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] allNumbersA = DataLoader.NumbersA;

            var amountOfOddA = allNumbersA.Count(number => number % 2 == 1);

            Console.WriteLine(amountOfOddA);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> allCustomers = DataLoader.LoadCustomers();

            var customerWithOrders = allCustomers.Select(customer => new
            {
                CustomerID = customer.CustomerID,
                OrderCount = customer.Orders.Count()
            });

            foreach (var cust in customerWithOrders)
            {
                Console.WriteLine(cust.CustomerID);
                Console.WriteLine(cust.OrderCount);
                Console.WriteLine("==========");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var productCategoriesAndCount = from product in allProducts
                                            group product by product.Category into productGroups
                                            select new
                                            {
                                                Category = productGroups.Key,
                                                TotalCount = productGroups.Count()
                                            };

            foreach (var products in productCategoriesAndCount)
            {
                Console.WriteLine(products.Category + " - " + products.TotalCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var productCategoriesAndSum = from product in allProducts
                                          group product by product.Category into productGroups
                                          select new
                                          {
                                              Category = productGroups.Key,
                                              TotalStock = productGroups.Sum(s => s.UnitsInStock)
                                          };

            foreach (var products in productCategoriesAndSum)
            {
                Console.WriteLine(products.Category + " - " + products.TotalStock);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var productCategoriesAndLowest = from product in allProducts
                                             group product by product.Category into productGroups
                                             select new
                                             {
                                                 Category = productGroups.Key,
                                                 LowestPrice = productGroups.Min(m => m.UnitPrice)
                                             };

            foreach (var products in productCategoriesAndLowest)
            {
                Console.WriteLine("{0} - {1:C}", products.Category, products.LowestPrice);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> allProducts = DataLoader.LoadProducts();

            var productCategoriesAndAverage = from product in allProducts
                                              group product by product.Category into productGroups
                                              select new
                                              {
                                                  Category = productGroups.Key,
                                                  AveragePrice = productGroups.Average(a => a.UnitPrice)
                                              };

            var orderedByAverage = productCategoriesAndAverage.OrderByDescending(a => a.AveragePrice).Take(3);

            foreach (var products in orderedByAverage)
            {
                Console.WriteLine("{0} - {1:C}", products.Category, products.AveragePrice);
            }
        }
    }
}
