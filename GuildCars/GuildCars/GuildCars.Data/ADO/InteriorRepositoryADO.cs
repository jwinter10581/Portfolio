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
    public class InteriorRepositoryADO : IInteriorRepository
    {
        public List<Interior> GetAll()
        {
            List<Interior> interiors = new List<Interior>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();
                        currentRow.InteriorId = Convert.ToByte(dr["InteriorId"]);
                        currentRow.InteriorName = dr["InteriorName"].ToString();

                        interiors.Add(currentRow);
                    }
                }
            }

            return interiors;
        }
    }
}
