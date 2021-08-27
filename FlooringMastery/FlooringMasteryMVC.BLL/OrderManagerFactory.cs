using FlooringMasteryMVC.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderRepositoryMemory());
                case "Prod":
                    return new OrderManager(new OrderRepositoryText());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
