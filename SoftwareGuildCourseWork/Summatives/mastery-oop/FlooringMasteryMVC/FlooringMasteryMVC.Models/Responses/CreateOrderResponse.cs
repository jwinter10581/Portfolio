using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Models.Responses
{
    public class CreateOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
