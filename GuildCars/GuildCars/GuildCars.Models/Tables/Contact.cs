using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string VINNumber { get; set; } // Can be null
        public string Name { get; set; }
        public string Email { get; set; } // Either phone or email can be null
        public string Phone { get; set; } // Either phone or email can be null
        public string Message { get; set; }
    }
}
