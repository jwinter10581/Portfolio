using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class VehicleTypeRepositoryMock : IVehicleTypeRepository
    {
        private static List<VehicleType> _vehicleTypes = new List<VehicleType>
        {
            new VehicleType
            {VehicleTypeId = 1, VehicleTypeName = "New" },
            new VehicleType
            {VehicleTypeId = 2, VehicleTypeName = "Used" }
        };

        public List<VehicleType> GetAll()
        {
            return _vehicleTypes;
        }
    }
}
