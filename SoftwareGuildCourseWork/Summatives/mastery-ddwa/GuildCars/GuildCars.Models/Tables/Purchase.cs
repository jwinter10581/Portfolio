using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int PurchaseTypeId { get; set; }
        public string StateAbbreviation { get; set; }
        public string VINNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; } // Can be null
        public string City { get; set; }
        public string ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
