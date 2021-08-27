using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleFeaturedItem
    {
        public string VINNumber { get; set; }
        public string ImageFilePath { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal SalePrice { get; set; }

        //public int MakeId { get; set; }
        //public int ModelId { get; set; }
    }
}
