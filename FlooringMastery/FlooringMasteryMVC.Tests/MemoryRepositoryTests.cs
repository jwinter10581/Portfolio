using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMasteryMVC.Models;
using FlooringMasteryMVC.Repository;
using NUnit.Framework;

namespace FlooringMasteryMVC.Tests
{
    [TestFixture]
    public class MemoryRepositoryTests
    {
        public Order Initialize() //Creates an order for tests to use
        {
            Order _orderTest = new Order
            {
                OrderDate = new DateTime(10, 10, 10),
                OrderNumber = 1,
                CustomerName = "Testy McTesterson",
                Area = 100m
            };
            Tax _taxOne = new Tax
            {
                StateAbbreviation = "TS",
                StateName = "Testing State",
                TaxRate = 10.00m
            };
            Product _productOne = new Product
            {
                ProductType = "Punchcard",
                CostPerSquareFoot = 2.50m,
                LaborCostPerSquareFoot = 5.00m
            };

            _orderTest.TaxInfo = _taxOne;
            _orderTest.ProductInfo = _productOne;
            _orderTest.MaterialCost = _orderTest.Area * _orderTest.ProductInfo.CostPerSquareFoot;
            _orderTest.LaborCost = _orderTest.Area * _orderTest.ProductInfo.LaborCostPerSquareFoot;
            _orderTest.TaxCost = (_orderTest.MaterialCost + _orderTest.LaborCost) * (_orderTest.TaxInfo.TaxRate / 100);
            _orderTest.Total = _orderTest.MaterialCost + _orderTest.LaborCost + _orderTest.TaxCost;

            return _orderTest;

        }

        [Test]
        public void AddOrderSuccesfullyAddsOrder()
        {
            Order order = Initialize();
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            repo.AddOrder(order);

            Assert.AreEqual(1, repo.RetrieveAllOrdersByDate(new DateTime(10, 10, 10)).Count());
        }

        [Test]
        public void AddOrderFailsToAddOrder()
        {
            Order order = Initialize();
            order.TaxInfo = null;
            order.ProductInfo = null;
            order.Area = 0;

            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            order = repo.AddOrder(order);

            Assert.AreEqual(null, order);
        }

        [Test]
        public void DeleteOrderSuccessfullyDeletesOrder()
        {
            Order order = Initialize();
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            repo.AddOrder(order);

            repo.DeleteOrder(order.OrderDate,order.OrderNumber);

            Assert.AreEqual(0, repo.RetrieveAllOrdersByDate(new DateTime(10, 10, 10)).Count());
        }

        [Test]
        public void RetrieveAllOrdersByDateGetsAllOrders()
        {
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            DateTime date = DateTime.Parse("9/1/21");
            List<Order> orders = repo.RetrieveAllOrdersByDate(date);

            Assert.AreEqual(2, orders.Count());
        }

        [Test]
        public void RetrieveAllOrdersByDateReturnsZeroOrders()
        {
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            DateTime date = DateTime.Parse("1/1/21");
            List<Order> orders = repo.RetrieveAllOrdersByDate(date);

            Assert.AreEqual(0, orders.Count());
        }

        [Test]
        public void RetrieveOrderByDateGetsCorrectOrder()
        {
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            DateTime date = DateTime.Parse("9/1/21");
            Order order = repo.RetrieveOrderByNumber(date, 1);

            Assert.AreEqual("Jonathan", order.CustomerName);
            Assert.AreEqual("Obsidian", order.ProductInfo.ProductType);
            Assert.AreEqual("New Zealand", order.TaxInfo.StateName);
        }

        [Test]
        public void RetrieveOrderByDateReturnsNoOrder()
        {
            OrderRepositoryMemory repo = new OrderRepositoryMemory();
            DateTime date = DateTime.Parse("1/1/21");
            Order order = repo.RetrieveOrderByNumber(date, 1);

            Assert.AreEqual(null, order);
        }
    }
}
