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
    public class TransmissionRepositoryADO : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionId = Convert.ToByte(dr["TransmissionId"]);
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }

            return transmissions;
        }
    }
}
