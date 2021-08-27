using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Models.Responses
{
    public class LookupOrdersResponse : Response
    {
        public List<Order> Orders { get; set; }
    }
}
