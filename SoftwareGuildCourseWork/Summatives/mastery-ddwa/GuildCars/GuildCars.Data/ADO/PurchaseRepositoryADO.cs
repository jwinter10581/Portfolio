using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
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
    public class PurchaseRepositoryADO : IPurchaseRepository
    {
        public List<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseId = Convert.ToInt16(dr["PurchaseId"]);
                        currentRow.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        currentRow.EmployeeName = dr["EmployeeName"].ToString();
                        currentRow.PurchaseTypeId = Convert.ToByte(dr["PurchaseTypeId"]);
                        currentRow.StateAbbreviation = dr["StateAbbreviation"].ToString();
                        currentRow.VINNumber = dr["VINNumber"].ToString();
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.ZipCode = dr["ZipCode"].ToString();
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.PurchaseDate = (DateTime)dr["PurchaseDate"];

                        if (dr["Email"] != DBNull.Value)
                        {
                            currentRow.Email = dr["Email"].ToString();
                        }

                        if (dr["Phone"] != DBNull.Value)
                        {
                            currentRow.Phone = dr["Phone"].ToString();
                        }

                        if (dr["Street2"] != DBNull.Value)
                        {
                            currentRow.Street2 = dr["Street2"].ToString();
                        }

                        purchases.Add(currentRow);
                    }
                }
            }

            return purchases;
        }

        public Purchase GetById(int purchaseId)
        {
            Purchase purchase = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PurchaseId", purchaseId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        purchase = new Purchase();
                        purchase.PurchaseId = Convert.ToInt16(dr["PurchaseId"]);
                        purchase.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        purchase.EmployeeName = dr["EmployeeName"].ToString();
                        purchase.PurchaseTypeId = Convert.ToByte(dr["PurchaseTypeId"]);
                        purchase.StateAbbreviation = dr["StateAbbreviation"].ToString();
                        purchase.VINNumber = dr["VINNumber"].ToString();
                        purchase.Name = dr["Name"].ToString();
                        purchase.Street1 = dr["Street1"].ToString();
                        purchase.City = dr["City"].ToString();
                        purchase.ZipCode = dr["ZipCode"].ToString();
                        purchase.PurchasePrice = (decimal)dr["PurchasePrice"];
                        purchase.PurchaseDate = (DateTime)dr["PurchaseDate"];

                        if (dr["Email"] != DBNull.Value)
                        {
                            purchase.Email = dr["Email"].ToString();
                        }

                        if (dr["Phone"] != DBNull.Value)
                        {
                            purchase.Phone = dr["Phone"].ToString();
                        }

                        if (dr["Street2"] != DBNull.Value)
                        {
                            purchase.Street2 = dr["Street2"].ToString();
                        }
                    }
                }
            }

            return purchase;
        }

        public void Insert(Purchase newPurchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PurchaseId", SqlDbType.SmallInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@EmployeeId", newPurchase.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", newPurchase.Name);
                cmd.Parameters.AddWithValue("@Street1", newPurchase.Street1);
                cmd.Parameters.AddWithValue("@City", newPurchase.City);
                cmd.Parameters.AddWithValue("@StateAbbreviation", newPurchase.StateAbbreviation);
                cmd.Parameters.AddWithValue("@ZipCode", newPurchase.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", newPurchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", newPurchase.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@VINNumber", newPurchase.VINNumber);

                if (string.IsNullOrEmpty(newPurchase.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", newPurchase.Phone);
                }

                if (string.IsNullOrEmpty(newPurchase.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", newPurchase.Email);
                }

                if (string.IsNullOrEmpty(newPurchase.Street2))
                {
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", newPurchase.Street2);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                newPurchase.PurchaseId = Convert.ToInt16(param.Value);
            }
        }

        public IEnumerable<SalesReportItem> Search(PurchaseSearchParameters parameters)
        {
            List<SalesReportItem> reportItems = new List<SalesReportItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT p.EmployeeId, CONCAT(e.EmployeeFirstName, ' ', e.EmployeeLastName) AS EmployeeName, TotalSales = SUM(PurchasePrice), TotalVehicles = COUNT(PurchaseId) FROM Purchase p INNER JOIN Employee e ON p.EmployeeId = e.EmployeeId WHERE 1 = 1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.EmployeeId.HasValue)
                {
                    query += "AND e.EmployeeId = @EmployeeId ";
                    cmd.Parameters.AddWithValue("@EmployeeId", parameters.EmployeeId);
                }

                if (DateTime.TryParse(parameters.FromText, out DateTime searchFrom))
                {
                    parameters.FromDate = searchFrom;
                    query += "AND PurchaseDate >= @FromDate ";
                    cmd.Parameters.AddWithValue("@FromDate", parameters.FromDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    query += "AND PurchaseDate >= @FromDate ";
                    cmd.Parameters.AddWithValue("@FromDate", new DateTime(2000, 1, 1).ToString("yyyy-MM-dd"));
                }

                if (DateTime.TryParse(parameters.ToText, out DateTime searchTo))
                {
                    parameters.ToDate = searchTo;
                    query += "AND PurchaseDate <= @ToDate ";
                    cmd.Parameters.AddWithValue("@ToDate", parameters.ToDate.ToString("yyyy-MM-dd"));
                }
                else
                {
                    query += "AND PurchaseDate <= @ToDate ";
                    cmd.Parameters.AddWithValue("@ToDate", DateTime.Now.ToString("yyyy-MM-dd"));
                }

                query += "GROUP BY p.EmployeeId, e.EmployeeFirstName, e.EmployeeLastName ";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportItem currentRow = new SalesReportItem();

                        currentRow.EmployeeId = Convert.ToByte(dr["EmployeeId"]);
                        currentRow.EmployeeName = dr["EmployeeName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];

                        reportItems.Add(currentRow);
                    }
                }
            }

            return reportItems;
        }
    }
}