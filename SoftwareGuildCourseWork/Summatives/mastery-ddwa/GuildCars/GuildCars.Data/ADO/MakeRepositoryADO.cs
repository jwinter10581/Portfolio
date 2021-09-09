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
    public class MakeRepositoryADO : IMakeRepository
    {
        public List<Make> GetAll()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeId = Convert.ToByte(dr["MakeId"]);
                        currentRow.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        currentRow.EmployeeEmail = dr["EmployeeEmail"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        makes.Add(currentRow);
                    }
                }
            }

            return makes;
        }

        public Make GetById(int makeId)
        {
            Make make = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        make = new Make();
                        make.MakeId = Convert.ToByte(dr["MakeId"]);
                        make.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        make.EmployeeEmail = dr["EmployeeEmail"].ToString();
                        make.MakeName = dr["MakeName"].ToString();
                        make.DateAdded = (DateTime)dr["DateAdded"];
                    }
                }
            }

            return make;
        }

        public void Insert(Make newMake)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@EmployeeId", newMake.EmployeeId);
                cmd.Parameters.AddWithValue("@MakeName", newMake.MakeName);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
