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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleId = Convert.ToByte(dr["BodyStyleId"]);
                        currentRow.BodyStyleType = dr["BodyStyleType"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }
            }

            return bodyStyles;
        }
    }
}
