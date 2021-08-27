using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Models.Responses
{
    public class EditOrderResponse : Response
    {
        public Order OldOrder { get; set; }
        public Order NewOrder { get; set; }
    }
}
