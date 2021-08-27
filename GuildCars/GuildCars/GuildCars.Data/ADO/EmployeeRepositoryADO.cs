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
    public class EmployeeRepositoryADO : IEmployeeRepository
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Employee currentRow = new Employee();
                        currentRow.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        currentRow.RoleName = dr["RoleName"].ToString();
                        currentRow.EmployeeFirstName = dr["EmployeeFirstName"].ToString();
                        currentRow.EmployeeLastName = dr["EmployeeLastName"].ToString();
                        currentRow.EmployeeEmail = dr["EmployeeEmail"].ToString();

                        employees.Add(currentRow);
                    }
                }
            }

            return employees;
        }

        public Employee GetByEmployeeEmail(string employeeEmail)
        {
            Employee employee = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeSelectByEmail", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeEmail", employeeEmail);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        employee.RoleName = dr["RoleName"].ToString();
                        employee.EmployeeFirstName = dr["EmployeeFirstName"].ToString();
                        employee.EmployeeLastName = dr["EmployeeLastName"].ToString();
                        employee.EmployeeEmail = dr["EmployeeEmail"].ToString();
                    }
                }
            }

            return employee;
        }

        public Employee GetByEmployeeId(int employeeId)
        {
            Employee employee = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        employee.RoleName = dr["RoleName"].ToString();
                        employee.EmployeeFirstName = dr["EmployeeFirstName"].ToString();
                        employee.EmployeeLastName = dr["EmployeeLastName"].ToString();
                        employee.EmployeeEmail = dr["EmployeeEmail"].ToString();
                    }
                }
            }

            return employee;
        }

        public void Insert(Employee newEmployee)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@EmployeeId", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@RoleName", newEmployee.RoleName);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", newEmployee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", newEmployee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeEmail", newEmployee.EmployeeEmail);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee updatedEmployee)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EmployeeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", updatedEmployee.EmployeeId);
                cmd.Parameters.AddWithValue("@RoleName", updatedEmployee.RoleName);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", updatedEmployee.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", updatedEmployee.EmployeeLastName);
                cmd.Parameters.AddWithValue("@EmployeeEmail", updatedEmployee.EmployeeEmail);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
