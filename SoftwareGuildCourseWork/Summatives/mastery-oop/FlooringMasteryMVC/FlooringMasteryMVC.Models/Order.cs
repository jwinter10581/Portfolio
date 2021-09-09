using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMasteryMVC.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Area { get; set; }
        public Tax TaxInfo { get; set; } // Contains State Abbreviation, State Name, and Tax Rate
        public Product ProductInfo { get; set; } // Contains Product Type, Cost Per Square Foot, and Labor Cost Per Square Foot
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TaxCost { get; set; }
        public decimal Total { get; set; }
    }
}
