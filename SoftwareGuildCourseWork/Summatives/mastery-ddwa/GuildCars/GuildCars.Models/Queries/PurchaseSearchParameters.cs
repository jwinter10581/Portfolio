using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class PurchaseSearchParameters
    {
        public int? EmployeeId { get; set; }
        public string FromText { get; set; }
        public DateTime FromDate { get; set; }
        public string ToText { get; set; }
        public DateTime ToDate { get; set; }
    }
}
