using FlooringMasteryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Repository
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        bool DeleteOrder(DateTime date, int number);
        Order CalculateFields(Order order);
        List<Order> RetrieveAllOrdersByDate(DateTime date);
        Order RetrieveOrderByNumber(DateTime date, int number);
    }
}
