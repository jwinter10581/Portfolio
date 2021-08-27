using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public string VINNumber { get; set; }
        public string BodyStyleType { get; set; }
        public string ColorName { get; set; }
        public string InteriorName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string TransmissionType { get; set; }
        public string VehicleTypeName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateSold { get; set; }
        public string Description { get; set; }
        public bool FeaturedStatus { get; set; }
        public string ImageFilePath { get; set; }
        public int Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public bool SoldStatus { get; set; }
        public int Year { get; set; }

        //public int BodyStyleId { get; set; }
        //public int ColorId { get; set; }
        //public int InteriorId { get; set; }
        //public int ModelId { get; set; }
        //public int TransmissionId { get; set; }
        //public int VehicleTypeId { get; set; }
    }
}
