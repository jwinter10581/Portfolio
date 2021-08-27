using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SIS_Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}
