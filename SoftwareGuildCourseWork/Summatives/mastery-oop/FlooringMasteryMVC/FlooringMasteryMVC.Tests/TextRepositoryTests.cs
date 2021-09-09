using FlooringMasteryMVC.Models;
using FlooringMasteryMVC.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlooringMasteryMVC.Tests
{
    public class TextRepositoryTests
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
            OrderRepositoryText repo = new OrderRepositoryText();
            repo.AddOrder(order);

            Assert.AreEqual(1, repo.RetrieveAllOrdersByDate(new DateTime(10, 10, 10)).Count());

            repo.DeleteOrder(new DateTime(10, 10, 10), 1); // Delete order to ensure other tests succeed
        }

        [Test]
        public void AddOrderFailsToAddOrder()
        {
            Order order = Initialize();
            order.TaxInfo = null;
            order.ProductInfo = null;
            order.Area = 0;

            OrderRepositoryText repo = new OrderRepositoryText();
            order = repo.AddOrder(order);

            Assert.AreEqual(null, order);
        }

        [Test]
        public void DeleteOrderSuccessfullyDeletesOrder()
        {
            Order order = Initialize();
            OrderRepositoryText repo = new OrderRepositoryText();
            repo.AddOrder(order);

            repo.DeleteOrder(order.OrderDate, order.OrderNumber);

            Assert.AreEqual(0, repo.RetrieveAllOrdersByDate(new DateTime(10, 10, 10)).Count());
        }

        [Test]
        public void RetrieveAllOrdersByDateGetsAllOrders()
        {
            Order order = Initialize();      
            OrderRepositoryText repo = new OrderRepositoryText();

            repo.AddOrder(order); // Add order to find

            DateTime date = new DateTime(10, 10, 10);
            List<Order> orders = repo.RetrieveAllOrdersByDate(date);

            Assert.AreEqual(1, orders.Count());

            repo.DeleteOrder(date, 1); // Delete order to ensure other tests succeed
        }

        [Test]
        public void RetrieveAllOrdersByDateReturnsZeroOrders()
        {
            OrderRepositoryText repo = new OrderRepositoryText();
            DateTime date = DateTime.Parse("1/1/21");
            List<Order> orders = repo.RetrieveAllOrdersByDate(date);

            Assert.AreEqual(0, orders.Count());
        }

        [Test]
        public void RetrieveOrderByDateReturnsNoOrder()
        {
            OrderRepositoryText repo = new OrderRepositoryText();
            DateTime date = DateTime.Parse("1/1/21");
            Order order = repo.RetrieveOrderByNumber(date, 1);

            Assert.AreEqual(null, order);
        }
    }
}
