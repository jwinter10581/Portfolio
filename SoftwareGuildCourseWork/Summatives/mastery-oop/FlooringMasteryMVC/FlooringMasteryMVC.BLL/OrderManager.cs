using FlooringMasteryMVC.Models;
using FlooringMasteryMVC.Models.Responses;
using FlooringMasteryMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private ProductRepository _productRepository;
        private TaxRepository _taxRepository;
        private string dateFormat = "MM/dd/yyyy";

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = new ProductRepository();
            _taxRepository = new TaxRepository();
        }

        public LookupOrdersResponse LookupMultipleOrders(DateTime date)
        {
            LookupOrdersResponse response = new LookupOrdersResponse();

            response.Orders = _orderRepository.RetrieveAllOrdersByDate(date);

            //if (response.Orders.Count() == 0)
            if (!response.Orders.Any())
            {
                response.Success = false;
                response.Message = $"No orders were found for that date.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public CreateOrderResponse CreateOrder(Order newOrder)
        {
            CreateOrderResponse response = new CreateOrderResponse();

            response.Order = _orderRepository.AddOrder(newOrder);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Order wasn't added to the repository.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public RemoveOrderResponse RemoveOrder(Order order)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();

            response.Order = order;

            response.Removal = _orderRepository.DeleteOrder(order.OrderDate, order.OrderNumber);

            if (response.Removal == true)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "The order was unable to be removed from the repository.";
            }
            return response;
        }

        public EditOrderResponse EditOrder(Order oldOrder, Order newOrder)
        {
            EditOrderResponse response = new EditOrderResponse();

            response.OldOrder = oldOrder;
            response.NewOrder = newOrder;

            if (response.NewOrder == null)
            {
                response.Success = false;
                response.Message = "The order was unable to be updated in the repository.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public void SaveOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public Order CalculateFields(Order updatedOrder)
        {
            _orderRepository.CalculateFields(updatedOrder);

            if (updatedOrder == null)
            {              
                return null;
            }
            else
            {
                return updatedOrder;
            }
        }

        public Order CopyOrderInformation(Order oldOrder, Order newOrder)
        {
            newOrder.OrderDate = oldOrder.OrderDate;
            newOrder.OrderNumber = oldOrder.OrderNumber;
            newOrder.CustomerName = oldOrder.CustomerName;
            newOrder.Area = oldOrder.Area;
            newOrder.TaxInfo = oldOrder.TaxInfo;
            newOrder.ProductInfo = oldOrder.ProductInfo;

            return newOrder;
        }

        public List<Order> RetrieveOrderList(DateTime date)
        {
            return _orderRepository.RetrieveAllOrdersByDate(date);
        }

        public List<Product> RetrieveProductList()
        {
            return _productRepository.RetrieveProductList();
        }

        public List<Product> RetrieveProductList(string location) //Overloaded for testing
        {
            return _productRepository.RetrieveProductList(location);
        }

        public List<Tax> RetrieveTaxList()
        {
            return _taxRepository.RetrieveTaxList();
        }

        public List<Tax> RetrieveTaxList(string location) //Overloaded for testing
        {
            return _taxRepository.RetrieveTaxList(location);
        }
    }
}
