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
    public class SpecialRepositoryADO : ISpecialRepository
    {
        public void Delete(int specialId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Special> GetAll()
        {
            List<Special> specials = new List<Special>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
                        currentRow.SpecialId = Convert.ToByte(dr["SpecialId"]);
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Description = dr["Description"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }

            return specials;
        }

        public Special GetById(int specialId)
        {
            Special special = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        special = new Special();
                        special.SpecialId = Convert.ToByte(dr["SpecialId"]);
                        special.Title = dr["Title"].ToString();
                        special.Description = dr["Description"].ToString();
                    }
                }
            }

            return special;
        }

        public void Insert(Special newSpecial)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", newSpecial.Title);
                cmd.Parameters.AddWithValue("@Description", newSpecial.Description);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
