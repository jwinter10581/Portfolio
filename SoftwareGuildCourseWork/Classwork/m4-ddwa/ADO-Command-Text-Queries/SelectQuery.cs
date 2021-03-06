using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Command_Text_Queries
{
    public class SelectQuery
    {
        public List<EmployeePayRate> GetEmployeeRates()
        {
            List<EmployeePayRate> rates = new List<EmployeePayRate>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=localhost;Database=SWCCorp;" +
                                         "User Id=sa;Password=sqlserver;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT e.EmpID, e.FirstName, e.LastName, pr.HourlyRate, " +
                    "pr.MonthlySalary, pr.YearlySalary " +
                    "FROM Employee e " +
                    "INNER JOIN PayRates pr ON e.EmpID = pr.EmpID";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmployeePayRate currentRow = new EmployeePayRate();

                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();

                        if (dr["HourlyRate"] != DBNull.Value)
                        {
                            currentRow.HourlyRate = (decimal)dr["HourlyRate"];
                        }

                        if (dr["MonthlySalary"] != DBNull.Value)
                        {
                            currentRow.MonthlySalary = (decimal)dr["MonthlySalary"];
                        }

                        if (dr["YearlySalary"] != DBNull.Value)
                        {
                            currentRow.YearlySalary = (decimal)dr["YearlySalary"];
                        }

                        currentRow.EmpId = (int)dr["EmpId"];
                        rates.Add(currentRow);
                    }
                }
            }

            return rates;
        }
    }
}
