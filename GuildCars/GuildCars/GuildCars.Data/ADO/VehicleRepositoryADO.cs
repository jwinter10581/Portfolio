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
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void Delete(string VINNumber)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VINNumber", VINNumber);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VINNumber = dr["VINNumber"].ToString();
                        currentRow.BodyStyleType = dr["BodyStyleType"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.InteriorName = dr["InteriorName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Year = Convert.ToInt16(dr["Year"]);
                        currentRow.SoldStatus = (bool)dr["SoldStatus"];
                        currentRow.FeaturedStatus = (bool)dr["FeaturedStatus"];
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        if (dr["DateSold"] != DBNull.Value)
                        {
                            currentRow.DateSold = (DateTime)dr["DateSold"];
                        }

                        if (dr["Description"] != DBNull.Value)
                        {
                            currentRow.Description = dr["Description"].ToString();
                        }

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public Vehicle GetById(string VINNumber)
        {
            Vehicle vehicle = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VINNumber", VINNumber);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VINNumber = dr["VINNumber"].ToString();
                        vehicle.BodyStyleType = dr["BodyStyleType"].ToString();
                        vehicle.ColorName = dr["ColorName"].ToString();
                        vehicle.InteriorName = dr["InteriorName"].ToString();
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.TransmissionType = dr["TransmissionType"].ToString();
                        vehicle.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        vehicle.ImageFilePath = dr["ImageFilePath"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.SalePrice = (decimal)dr["SalePrice"];
                        vehicle.Year = Convert.ToInt16(dr["Year"]);
                        vehicle.SoldStatus = (bool)dr["SoldStatus"];
                        vehicle.FeaturedStatus = (bool)dr["FeaturedStatus"];
                        vehicle.DateAdded = (DateTime)dr["DateAdded"];

                        if (dr["DateSold"] != DBNull.Value)
                        {
                            vehicle.DateSold = (DateTime)dr["DateSold"];
                        }

                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicle.Description = dr["Description"].ToString();
                        }
                    }
                }
            }

            return vehicle;
        }

        public VehicleDetailItem GetDetails(string VINNumber)
        {
            VehicleDetailItem vehicleDetail = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VINNumber", VINNumber);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicleDetail = new VehicleDetailItem();
                        vehicleDetail.VINNumber = dr["VINNumber"].ToString();
                        vehicleDetail.BodyStyleType = dr["BodyStyleType"].ToString();
                        vehicleDetail.ColorName = dr["ColorName"].ToString();
                        vehicleDetail.InteriorName = dr["InteriorName"].ToString();
                        vehicleDetail.MakeName = dr["MakeName"].ToString();
                        vehicleDetail.ModelName = dr["ModelName"].ToString();
                        vehicleDetail.TransmissionType = dr["TransmissionType"].ToString();
                        vehicleDetail.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        vehicleDetail.ImageFilePath = dr["ImageFilePath"].ToString();
                        vehicleDetail.Mileage = (int)dr["Mileage"];
                        vehicleDetail.MSRP = (decimal)dr["MSRP"];
                        vehicleDetail.SalePrice = (decimal)dr["SalePrice"];
                        vehicleDetail.Year = Convert.ToInt16(dr["Year"]);
                        vehicleDetail.SoldStatus = (bool)dr["SoldStatus"];

                        if (dr["Description"] != DBNull.Value)
                        {
                            vehicleDetail.Description = dr["Description"].ToString();
                        }
                    }
                }
            }

            return vehicleDetail;
        }

        public List<VehicleFeaturedItem> GetFeatured()
        {
            List<VehicleFeaturedItem> featuredVehicles = new List<VehicleFeaturedItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleFeaturedItem currentRow = new VehicleFeaturedItem();
                        currentRow.VINNumber = dr["VINNumber"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Year = Convert.ToInt16(dr["Year"]);

                        featuredVehicles.Add(currentRow);
                    }
                }
            }

            return featuredVehicles;
        }

        public void Insert(Vehicle newVehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VINNumber", newVehicle.VINNumber);
                cmd.Parameters.AddWithValue("@BodyStyleType", newVehicle.BodyStyleType);
                cmd.Parameters.AddWithValue("@ColorName", newVehicle.ColorName);
                cmd.Parameters.AddWithValue("@InteriorName", newVehicle.InteriorName);
                cmd.Parameters.AddWithValue("@ModelName", newVehicle.ModelName);
                cmd.Parameters.AddWithValue("@TransmissionType", newVehicle.TransmissionType);
                cmd.Parameters.AddWithValue("@VehicleTypeName", newVehicle.VehicleTypeName);
                cmd.Parameters.AddWithValue("@DateSold", DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", newVehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFilePath", newVehicle.ImageFilePath);
                cmd.Parameters.AddWithValue("@Mileage", newVehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", newVehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", newVehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Year", newVehicle.Year);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Purchase(string purchasedVIN)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclePurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VINNumber", purchasedVIN);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<VehicleReportItem> InventoryReport(string vehicleTypeName)
        {
            List<VehicleReportItem> reportVehicles = new List<VehicleReportItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInventoryReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeName);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleReportItem currentRow = new VehicleReportItem();
                        currentRow.Year = Convert.ToInt16(dr["Year"]);
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.VehicleCount = (int)dr["VehicleCount"];
                        currentRow.StockValue = (decimal)dr["StockValue"];

                        reportVehicles.Add(currentRow);
                    }
                }
            }

            return reportVehicles;
        }

        public IEnumerable<VehicleSearchItem> Search(VehicleSearchParameters parameters)
        {
            List<VehicleSearchItem> searchItems = new List<VehicleSearchItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VINNumber, BodyStyleType, ColorName, InteriorName, MakeName, ModelName, TransmissionType, VehicleTypeName, ImageFilePath, Mileage, MSRP, SalePrice, [Year], SoldStatus FROM Vehicle v INNER JOIN BodyStyle bs ON v.BodyStyleId = bs.BodyStyleId INNER JOIN Color c ON v.ColorId = c.ColorId INNER JOIN Interior i ON v.InteriorId = i.InteriorId INNER JOIN Model md ON v.ModelId = md.ModelId INNER JOIN Make mk ON mk.MakeId = md.MakeId INNER JOIN Transmission t ON v.TransmissionId = t.TransmissionId INNER JOIN VehicleType vt ON v.VehicleTypeId = vt.VehicleTypeId WHERE SoldStatus = 0 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.VehicleTypeName.ToLower() == "new" || parameters.VehicleTypeName.ToLower() == "used")
                {
                    query += "AND VehicleTypeName = @VehicleTypeName ";
                    cmd.Parameters.AddWithValue("@VehicleTypeName", parameters.VehicleTypeName);
                }
                else
                {
                    query += "AND SoldStatus = 0 ";
                }

                if (!string.IsNullOrEmpty(parameters.QuickSearch)) // make, model, or year
                {
                    query += "AND MakeName LIKE @QuickSearch ";
                    query += "OR ModelName LIKE @QuickSearch ";
                    cmd.Parameters.AddWithValue("@QuickSearch", '%' + parameters.QuickSearch + '%');
                }

                if (int.TryParse(parameters.QuickSearch, out int searchNumber))
                {
                    if (searchNumber >= 2000 && searchNumber < DateTime.Now.AddYears(1).Year)
                    {
                        query += "OR [Year] = @QuickSearchYear ";
                        cmd.Parameters.AddWithValue("@QuickSearchYear ", parameters.QuickSearch);
                    }
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND SalePrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND SalePrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += "AND [Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += "AND [Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                query += "ORDER BY SalePrice DESC";

                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleSearchItem currentRow = new VehicleSearchItem();
                        currentRow.VINNumber = dr["VINNumber"].ToString();
                        currentRow.BodyStyleType = dr["BodyStyleType"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.InteriorName = dr["InteriorName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalePrice = (decimal)dr["SalePrice"];
                        currentRow.Year = Convert.ToInt16(dr["Year"]);

                        searchItems.Add(currentRow);
                    }
                }
            }

            return searchItems;
        }

        public void Update(Vehicle updatedVehicle, string oldVIN)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OldVINNumber", oldVIN);
                cmd.Parameters.AddWithValue("@VINNumber", updatedVehicle.VINNumber);
                cmd.Parameters.AddWithValue("@BodyStyleType", updatedVehicle.BodyStyleType);
                cmd.Parameters.AddWithValue("@ColorName", updatedVehicle.ColorName);
                cmd.Parameters.AddWithValue("@InteriorName", updatedVehicle.InteriorName);
                cmd.Parameters.AddWithValue("@ModelName", updatedVehicle.ModelName);
                cmd.Parameters.AddWithValue("@TransmissionType", updatedVehicle.TransmissionType);
                cmd.Parameters.AddWithValue("@VehicleTypeName", updatedVehicle.VehicleTypeName);
                cmd.Parameters.AddWithValue("@Description", updatedVehicle.Description);
                cmd.Parameters.AddWithValue("@ImageFilePath", updatedVehicle.ImageFilePath);
                cmd.Parameters.AddWithValue("@Mileage", updatedVehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", updatedVehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", updatedVehicle.SalePrice);
                cmd.Parameters.AddWithValue("@Year", updatedVehicle.Year);
                cmd.Parameters.AddWithValue("@FeaturedStatus", updatedVehicle.FeaturedStatus);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
