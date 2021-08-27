using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetById(string VINNumber);
        void Insert(Vehicle newVehicle);
        void Update(Vehicle updatedVehicle, string oldVIN);
        void Delete(string VINNumber);
        List<VehicleFeaturedItem> GetFeatured();
        VehicleDetailItem GetDetails(string VINNumber);
        IEnumerable<VehicleSearchItem> Search(VehicleSearchParameters parameters);
        void Purchase(string purchasedVIN);
        IEnumerable<VehicleReportItem> InventoryReport(string vehicleTypeName);
    }
}
