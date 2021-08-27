using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMasteryMVC.BLL;
using FlooringMasteryMVC.Models;
using FlooringMasteryMVC.Models.Responses;
using FlooringMasteryMVC.View;


namespace FlooringMasteryMVC.Controller
{
    public class FlooringController
    {
        private OrderManager _orderManager;
        private FlooringView _flooringView;

        public FlooringController()
        {
            _orderManager = OrderManagerFactory.Create();
            _flooringView = new FlooringView();
        }

        public void Run()
        {
            bool keepRunning = true;

            do
            {
                int menuChoice = _flooringView.ShowMenuAndGetChoice();

                switch (menuChoice)
                {
                    case 1:
                        DisplayOrders();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        EditOrder();
                        break;
                    case 4:
                        RemoveOrder();
                        break;
                    case 5: // Quit
                        keepRunning = false;
                        return;
                }
            } while (keepRunning);
        }

        public void DisplayOrders()
        {
            FlooringValidation validation = new FlooringValidation();
            DateTime userDate = validation.ReadDate("Please enter a date to retrieve orders: ");
            LookupOrdersResponse lookupResponse = _orderManager.LookupMultipleOrders(userDate);

            if (lookupResponse.Orders.Count() == 0)
            {
                _flooringView.ShowFailure("Lookup orders", lookupResponse.Message);
            }
            else
            {
                _flooringView.DisplayOrderInformation(lookupResponse.Orders);
                _flooringView.ShowSuccess("Lookup orders");
            }
        }

        public void AddOrder()
        {
            Order newOrder = _flooringView.CreateNewOrder(_orderManager.RetrieveProductList(), _orderManager.RetrieveTaxList());
            newOrder = _orderManager.CalculateFields(newOrder);
            newOrder = _flooringView.ConfirmOrder(newOrder, "added");

            if (newOrder == null)
            {
                _flooringView.ShowFailure("Add Order");
                return;
            }

            CreateOrderResponse createResponse = _orderManager.CreateOrder(newOrder);

            if (createResponse.Order == null)
            {
                _flooringView.ShowFailure("Add order", createResponse.Message);
            }
            else
            {
                _flooringView.ShowSuccess("Add order");
            }
        }

        public void EditOrder()
        {
            FlooringValidation validation = new FlooringValidation();
            DateTime userDate = validation.ReadDate("Please enter a date to retrieve orders: ");
            List<Order> ordersFromDate = _orderManager.RetrieveOrderList(userDate);
            
            if (!ordersFromDate.Any())
            {
                _flooringView.ShowFailure("Edit Order", $"No orders were found for {userDate:MM/dd/yyyy}");
                return;
            }

            Order oldOrder = _flooringView.SelectOrder(ordersFromDate, "edit");
            Order editedOrder = new Order();

            _orderManager.CopyOrderInformation(oldOrder, editedOrder);
            _orderManager.RemoveOrder(oldOrder);
            editedOrder = _flooringView.EditOrder(editedOrder, _orderManager.RetrieveProductList(), _orderManager.RetrieveTaxList());
            editedOrder = _orderManager.CalculateFields(editedOrder);
            editedOrder = _flooringView.ConfirmOrder(editedOrder, "edited");

            if (editedOrder == null)
            {
                _flooringView.ShowFailure("Edit Order");
                _orderManager.SaveOrder(oldOrder);
                return;
            }

            EditOrderResponse editResponse = _orderManager.EditOrder(editedOrder, oldOrder);

            if (editResponse.NewOrder == null)
            {
                _flooringView.ShowFailure("Edit order", editResponse.Message);
            }
            else
            {
                _flooringView.ShowSuccess("Edit order");
                _orderManager.SaveOrder(editedOrder);
            }
        }

        public void RemoveOrder()
        {
            FlooringValidation validation = new FlooringValidation();
            DateTime userDate = validation.ReadDate("Please enter a date to retrieve orders: ");
            List<Order> ordersFromDate = _orderManager.RetrieveOrderList(userDate);

            if (!ordersFromDate.Any())
            {
                _flooringView.ShowFailure("Remove Order", $"No orders were found for {userDate:MM/dd/yyyy}");
                return;
            }

            Order orderToRemove = _flooringView.SelectOrder(ordersFromDate, "remove");
            orderToRemove = _flooringView.ConfirmOrder(orderToRemove, "removed");

            if (orderToRemove == null)
            {
                _flooringView.ShowFailure("Remove Order");
                return;
            }

            RemoveOrderResponse removeResponse = _orderManager.RemoveOrder(orderToRemove);

            if (removeResponse.Removal == true)
            {
                _flooringView.ShowSuccess("Remove order");
            }
            else
            {
                _flooringView.ShowFailure("Remove order", removeResponse.Message);
            }
        }
    }
}
