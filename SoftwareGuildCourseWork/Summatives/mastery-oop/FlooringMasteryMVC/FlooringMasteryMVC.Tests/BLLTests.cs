using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMasteryMVC.BLL;
using FlooringMasteryMVC.Models;
using FlooringMasteryMVC.Models.Responses;
using NUnit.Framework;

namespace FlooringMasteryMVC.Tests
{
    [TestFixture]
    class BLLTests
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
        public void LookupMultipleOrdersReturnsOrders()
        {
            DateTime date = DateTime.Parse("9/1/21");
            OrderManager manager = OrderManagerFactory.Create();
            LookupOrdersResponse response = manager.LookupMultipleOrders(date);

            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(response.Orders.Count(), 2); // Two orders in memory repository
        }

        [Test]
        public void LookupMultpleOrdersReturnsZeroOrders()
        {
            DateTime date = DateTime.Parse("12/31/21");
            OrderManager manager = OrderManagerFactory.Create();

            LookupOrdersResponse response = manager.LookupMultipleOrders(date);

            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(response.Orders.Count(), 0); // Zero orders in memory repository
        }

        [Test]
        public void CreateOrderCreatesAnOrder()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();

            CreateOrderResponse response = manager.CreateOrder(orderTest);
            var orderAdded = manager.RetrieveOrderList(orderTest.OrderDate);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(1, orderAdded.Count());
        }

        [Test]
        public void CreateOrderCannotCreateOrder()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();
            orderTest.TaxInfo = null;

            CreateOrderResponse response = manager.CreateOrder(orderTest);
            var orderAdded = manager.RetrieveOrderList(orderTest.OrderDate);
            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(0, orderAdded.Count());
        }

        [Test]
        public void RemoveOrderRemovesAnOrder()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();
            CreateOrderResponse createResponse = manager.CreateOrder(orderTest);
            Assert.AreEqual(true, createResponse.Success);

            RemoveOrderResponse removeResponse = manager.RemoveOrder(orderTest);
            var orderRemoved = manager.RetrieveOrderList(orderTest.OrderDate);
            Assert.AreEqual(true, removeResponse.Success);
            Assert.AreEqual(true, removeResponse.Removal);
            Assert.AreEqual(0, orderRemoved.Count());
        }

        [Test]
        public void RemoveOrderFailsToRemoveOrder()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();

            RemoveOrderResponse removeResponse = manager.RemoveOrder(orderTest);
            Assert.AreEqual(false, removeResponse.Success);
        }

        [Test]
        public void SaveOrderSuccessfullyAddsOrderToRepository()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();
            manager.SaveOrder(orderTest);

            var orderAdded = manager.RetrieveOrderList(orderTest.OrderDate);

            Assert.AreEqual(1, orderAdded.Count());
        }

        [Test]
        public void CalculateFieldsSuccesfullyUpdatesFields()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order orderTest = Initialize();

            orderTest.LaborCost = 0;
            Assert.AreEqual(0, orderTest.LaborCost);

            orderTest.MaterialCost = 0;
            Assert.AreEqual(0, orderTest.MaterialCost);

            orderTest.TaxCost = 0;
            Assert.AreEqual(0, orderTest.TaxCost);

            orderTest.Total = 0;
            Assert.AreEqual(0, orderTest.Total);

            manager.CalculateFields(orderTest);

            Assert.AreEqual(500m, orderTest.LaborCost);
            Assert.AreEqual(250m, orderTest.MaterialCost);
            Assert.AreEqual(75m, orderTest.TaxCost);
            Assert.AreEqual(825m, orderTest.Total);
        }

        [Test]
        public void RetrieveOrderListRetrievesAllOrdersOnDate()
        {
            OrderManager manager = OrderManagerFactory.Create();

            var ordersFromDate = manager.RetrieveOrderList(DateTime.Parse("9/1/21"));

            Assert.AreEqual(2, ordersFromDate.Count());
        }

        [Test]
        public void RetrieveProductListRetrievesAllProducts()
        {
            OrderManager manager = OrderManagerFactory.Create();

            var allProducts = manager.RetrieveProductList(@"C:\Users\Jonathan\Documents\GitHub\online-net-2021-jwinter10581\Summatives\mastery-oop\FlooringMasteryMVC\FlooringMasteryMVC\bin\Debug\Products\Products.txt");

            Assert.AreEqual(4, allProducts.Count());
        }

        [Test]
        public void RetrieveTaxListRetrievesAllTaxes()
        {
            OrderManager manager = OrderManagerFactory.Create();

            var allTaxes = manager.RetrieveTaxList(@"C:\Users\Jonathan\Documents\GitHub\online-net-2021-jwinter10581\Summatives\mastery-oop\FlooringMasteryMVC\FlooringMasteryMVC\bin\Debug\Taxes\Taxes.txt");

            Assert.AreEqual(4, allTaxes.Count());
        }
    }
}
