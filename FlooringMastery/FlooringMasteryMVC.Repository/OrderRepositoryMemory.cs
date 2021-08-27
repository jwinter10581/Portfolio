using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Repository
{
    public class OrderRepositoryMemory : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        #region First Order Information
        private Order _orderOne = new Order
        {
            OrderDate = new DateTime(2021, 09, 01),
            OrderNumber = 1,
            CustomerName = "Jonathan",
            Area = 117.1757m
        };
        private Tax _taxOne = new Tax
        {
            StateAbbreviation = "NZ",
            StateName = "New Zealand",
            TaxRate = 7.25m
        };
        private Product _productOne = new Product
        {
            ProductType = "Obsidian",
            CostPerSquareFoot = 4.44m,
            LaborCostPerSquareFoot = 8.88m
        };
        #endregion
        #region Second Order Information
        private Order _orderTwo = new Order
        {
            OrderDate = new DateTime(2021, 09, 01),
            OrderNumber = 2,
            CustomerName = "Mariah",
            Area = 142.92m
        };
        private Tax _taxTwo = new Tax
        {
            StateAbbreviation = "JP",
            StateName = "Japan",
            TaxRate = 8.50m
        };
        private Product _productTwo = new Product
        {
            ProductType = "Bamboo",
            CostPerSquareFoot = 3.33m,
            LaborCostPerSquareFoot = 6.66m
        };
        #endregion
        public OrderRepositoryMemory()
        {
            #region Information for two orders added to Repo
            _orderOne.TaxInfo = _taxOne;
            _orderOne.ProductInfo = _productOne;
            _orderOne.MaterialCost = _orderOne.Area * _orderOne.ProductInfo.CostPerSquareFoot;
            _orderOne.LaborCost = _orderOne.Area * _orderOne.ProductInfo.LaborCostPerSquareFoot;
            _orderOne.TaxCost = (_orderOne.MaterialCost + _orderOne.LaborCost) * (_orderOne.TaxInfo.TaxRate / 100);
            _orderOne.Total = _orderOne.MaterialCost + _orderOne.LaborCost + _orderOne.TaxCost;
            _orders.Add(_orderOne);

            _orderTwo.TaxInfo = _taxTwo;
            _orderTwo.ProductInfo = _productTwo;
            _orderTwo.MaterialCost = _orderTwo.Area * _orderTwo.ProductInfo.CostPerSquareFoot;
            _orderTwo.LaborCost = _orderTwo.Area * _orderTwo.ProductInfo.LaborCostPerSquareFoot;
            _orderTwo.TaxCost = (_orderTwo.MaterialCost + _orderTwo.LaborCost) * (_orderTwo.TaxInfo.TaxRate / 100);
            _orderTwo.Total = _orderTwo.MaterialCost + _orderTwo.LaborCost + _orderTwo.TaxCost;
            _orders.Add(_orderTwo);
            #endregion
        }

        public Order AddOrder(Order newOrder)
        {
            if (newOrder.TaxInfo == null || newOrder.ProductInfo == null || newOrder.Area == 0)
            {
                return null;
            }
            else
            {
                ReadAllOrders().Add(newOrder);
            }

            return newOrder;
        }

        public bool DeleteOrder(DateTime date, int number)
        {
            Order deletedOrder = RetrieveOrderByNumber(date, number);

            return ReadAllOrders().Remove(deletedOrder);
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

        private List<Order> ReadAllOrders()
        {
            return _orders;
        }

        public List<Order> RetrieveAllOrdersByDate(DateTime date)
        {
            var ordersFromDate = ReadAllOrders().Where(o => o.OrderDate == date).ToList();

            return ordersFromDate;
        }

        public Order RetrieveOrderByNumber(DateTime date, int number)
        {
            try
            {
                var orderByNumber = ReadAllOrders().FirstOrDefault(d => d.OrderDate == date && d.OrderNumber == number);

                return orderByNumber; // If it returns null, there is no matching order.
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
