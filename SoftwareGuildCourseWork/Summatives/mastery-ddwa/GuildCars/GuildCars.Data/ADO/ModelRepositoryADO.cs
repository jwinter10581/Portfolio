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
    public class ModelRepositoryADO : IModelRepository
    {
        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = Convert.ToByte(dr["ModelId"]);
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        currentRow.EmployeeEmail = dr["EmployeeEmail"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public Model GetById(int modelId)
        {
            Model model = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", modelId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        model = new Model();
                        model.ModelId = Convert.ToByte(dr["ModelId"]);
                        model.ModelName = dr["ModelName"].ToString();
                        model.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        model.EmployeeEmail = dr["EmployeeEmail"].ToString();
                        model.MakeName = dr["MakeName"].ToString();
                        model.DateAdded = (DateTime)dr["DateAdded"];
                    }
                }
            }

            return model;
        }

        public void Insert(Model newModel)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelName", newModel.ModelName);
                cmd.Parameters.AddWithValue("@EmployeeId", newModel.EmployeeId);
                cmd.Parameters.AddWithValue("@MakeName", newModel.MakeName);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
