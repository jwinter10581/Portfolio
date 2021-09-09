using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class VehicleTypeRepositoryADO : IVehicleTypeRepository
    {
        public List<VehicleType> GetAll()
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleTypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleType currentRow = new VehicleType();
                        currentRow.VehicleTypeId = Convert.ToByte(dr["VehicleTypeId"]);
                        currentRow.VehicleTypeName = dr["VehicleTypeName"].ToString();

                        vehicleTypes.Add(currentRow);
                    }
                }
            }

            return vehicleTypes;
        }
    }
}
