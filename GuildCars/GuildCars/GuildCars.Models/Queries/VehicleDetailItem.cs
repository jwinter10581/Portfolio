using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleDetailItem
    {
        public string VINNumber { get; set; }
        public string BodyStyleType { get; set; }
        public string ColorName { get; set; }
        public string InteriorName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string TransmissionType { get; set; }
        public string VehicleTypeName { get; set; }
        public string ImageFilePath { get; set; }
        public int Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public bool SoldStatus { get; set; }

        //public int MakeId { get; set; }
        //public int ModelId { get; set; }
    }
}
