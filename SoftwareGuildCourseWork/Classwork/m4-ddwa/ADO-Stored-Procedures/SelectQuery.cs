using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Stored_Procedures
{
    public class SelectQuery
    {
        public List<EmployeePayRate> GetEmployeeRates()
        {
            List<EmployeePayRate> rates = new List<EmployeePayRate>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                    ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "EmployeeRatesSelect";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmployeePayRate rate = new EmployeePayRate();

                        rate.FirstName = dr["FirstName"].ToString();
                        rate.LastName = dr["LastName"].ToString();

                        if (dr["HourlyRate"] != DBNull.Value)
                        {
                            rate.HourlyRate = (decimal)dr["HourlyRate"];
                        }

                        if (dr["MonthlySalary"] != DBNull.Value)
                        {
                            rate.MonthlySalary = (decimal)dr["MonthlySalary"];
                        }

                        if (dr["YearlySalary"] != DBNull.Value)
                        {
                            rate.YearlySalary = (decimal)dr["YearlySalary"];
                        }

                        rate.EmpId = (int)dr["EmpId"];
                        rates.Add(rate);
                    }
                }
            }

            return rates;
        }
    }
}
