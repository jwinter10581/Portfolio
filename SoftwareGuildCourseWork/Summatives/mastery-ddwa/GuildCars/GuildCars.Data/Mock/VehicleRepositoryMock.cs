using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class VehicleRepositoryMock : IVehicleRepository
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            { VINNumber = "3MZBM1U76FM220997", BodyStyleType = "Car", ColorName = "Blue", InteriorName = "Black", MakeName = "Mazda", ModelName = "3", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's my car!", FeaturedStatus = true, ImageFilePath = "inventory-3MZBM1U76FM220997.jpg", Mileage = 50000, MSRP = 12000M, SalePrice = 11400M, SoldStatus = false, Year = 2015 },
            new Vehicle
            { VINNumber = "KNDJT2A59C7444605", BodyStyleType = "Car", ColorName = "White", InteriorName = "Grey", MakeName = "Kia", ModelName = "Soul", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's my other car!", FeaturedStatus = true, ImageFilePath = "inventory-KNDJT2A59C7444605.jpg", Mileage = 100000, MSRP = 8000M, SalePrice = 7600M, SoldStatus = false, Year = 2012 },
            new Vehicle
            { VINNumber = "3VW6T7AU7MM007118", BodyStyleType = "Car", ColorName = "White", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Golf", TransmissionType = "Manual", VehicleTypeName = "New", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's got a bunch of super new nice features!", FeaturedStatus = true, ImageFilePath = "inventory-3VW6T7AU7MM007118.jpg", Mileage = 150, MSRP = 35135M, SalePrice = 34000M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "4S4BSACC2J3216989", BodyStyleType = "SUV", ColorName = "Blue", InteriorName = "Black", MakeName = "Subaru", ModelName = "Outback", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = new DateTime(2021, 8, 2),
                Description = "People like to take these camping!", FeaturedStatus = false, ImageFilePath = "inventory-4S4BSACC2J3216989.jpg", Mileage = 98463, MSRP = 20000M, SalePrice = 19000M, SoldStatus = true, Year = 2018 },
            new Vehicle
            { VINNumber = "WV1ZZZ2HZHH018327", BodyStyleType = "Van", ColorName = "Black", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Amarok", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = new DateTime(2021, 8, 3),
                Description = "It's a truck that you can haul stuff in!", FeaturedStatus = false, ImageFilePath = "inventory-WV1ZZZ2HZHH018327.jpg", Mileage = 111174, MSRP = 45000M, SalePrice = 44800M, SoldStatus = true, Year = 2017 },
            new Vehicle
            { VINNumber = "JF2SKADC3MH567373", BodyStyleType = "SUV", ColorName = "Blue", InteriorName = "Grey", MakeName = "Subaru", ModelName = "Forester", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "The Forester is the perfect vehicle to expore nature with!", FeaturedStatus = true, ImageFilePath = "inventory-JF2SKADC3MH567373.jpg", Mileage = 200, MSRP = 28282M, SalePrice = 28000M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "KNDMB5C16L6633732", BodyStyleType = "Van", ColorName = "White", InteriorName = "Blue", MakeName = "Kia", ModelName = "Carnival", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "The Sedona is also known as the Carnival in some places!", FeaturedStatus = true, ImageFilePath = "inventory-KNDMB5C16L6633732.jpg", Mileage = 4175, MSRP = 33000M, SalePrice = 31350M, SoldStatus = false, Year = 2020 },
            new Vehicle
            { VINNumber = "MM0UP0YF100227000", BodyStyleType = "Truck", ColorName = "Grey", InteriorName = "Red", MakeName = "Mazda", ModelName = "BT-50", TransmissionType = "Manual", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "This truck is equipped for all kinds of things!", FeaturedStatus = true, ImageFilePath = "inventory-MM0UP0YF100227000.jpg", Mileage = 135204, MSRP = 30000M, SalePrice = 29000M, SoldStatus = false, Year = 2014 },
            new Vehicle
            { VINNumber = "WA1AAAFY0M2129834", BodyStyleType = "SUV", ColorName = "Black", InteriorName = "Yellow", MakeName = "Audi", ModelName = "Q5", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "This is a premium tier SUV!", FeaturedStatus = true, ImageFilePath = "inventory-WA1AAAFY0M2129834.jpg", Mileage = 999, MSRP = 49000M, SalePrice = 46999M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "WA1AJAF71MD040415", BodyStyleType = "SUV", ColorName = "White", InteriorName = "White", MakeName = "Audi", ModelName = "Q7", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "Bigger, better, and more premium than all other SUVs!", FeaturedStatus = true, ImageFilePath = "inventory-WA1AJAF71MD040415.jpg", Mileage = 333, MSRP = 60000M, SalePrice = 57499M, SoldStatus = false, Year = 2021 },
            //new Vehicle
            //{ VINNumber = "11111111111111111", BodyStyleType = "Van", ColorName = "Black", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Bus", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 11), DateSold = null,
            //    Description = "NEW Placeholder Vehicle!", FeaturedStatus = false, ImageFilePath = "inventory-11111111111111111.jpg", Mileage = 100, MSRP = 100000M, SalePrice = 95000M, SoldStatus = false, Year = 2021 },
            //new Vehicle
            //{ VINNumber = "AAAAAAAAAAAAAAAAA", BodyStyleType = "Truck", ColorName = "White", InteriorName = "White", MakeName = "Subaru", ModelName = "Baja", TransmissionType = "Manual", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 11), DateSold = null,
            //    Description = "USED Placeholder Vehicle!", FeaturedStatus = false, ImageFilePath = "inventory-AAAAAAAAAAAAAAAAA.jpg", Mileage = 200000, MSRP = 2000M, SalePrice = 1900M, SoldStatus = false, Year = 2006 },
        };

        public static void Initialize()
        {
            _vehicles = new List<Vehicle>
            {
                        new Vehicle
            { VINNumber = "3MZBM1U76FM220997", BodyStyleType = "Car", ColorName = "Blue", InteriorName = "Black", MakeName = "Mazda", ModelName = "3", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's my car!", FeaturedStatus = true, ImageFilePath = "inventory-3MZBM1U76FM220997.jpg", Mileage = 50000, MSRP = 12000M, SalePrice = 11400M, SoldStatus = false, Year = 2015 },
            new Vehicle
            { VINNumber = "KNDJT2A59C7444605", BodyStyleType = "Car", ColorName = "White", InteriorName = "Grey", MakeName = "Kia", ModelName = "Soul", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's my other car!", FeaturedStatus = true, ImageFilePath = "inventory-KNDJT2A59C7444605.jpg", Mileage = 100000, MSRP = 8000M, SalePrice = 7600M, SoldStatus = false, Year = 2012 },
            new Vehicle
            { VINNumber = "3VW6T7AU7MM007118", BodyStyleType = "Car", ColorName = "White", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Golf", TransmissionType = "Manual", VehicleTypeName = "New", DateAdded = new DateTime(2021, 7, 22), DateSold = null,
                Description = "It's got a bunch of super new nice features!", FeaturedStatus = true, ImageFilePath = "inventory-3VW6T7AU7MM007118.jpg", Mileage = 150, MSRP = 35135M, SalePrice = 34000M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "4S4BSACC2J3216989", BodyStyleType = "SUV", ColorName = "Blue", InteriorName = "Black", MakeName = "Subaru", ModelName = "Outback", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 7, 22), DateSold = new DateTime(2021, 8, 2),
                Description = "People like to take these camping!", FeaturedStatus = false, ImageFilePath = "inventory-4S4BSACC2J3216989.jpg", Mileage = 98463, MSRP = 20000M, SalePrice = 19000M, SoldStatus = true, Year = 2018 },
            new Vehicle
            { VINNumber = "WV1ZZZ2HZHH018327", BodyStyleType = "Van", ColorName = "Black", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Amarok", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = new DateTime(2021, 8, 3),
                Description = "It's a truck that you can haul stuff in!", FeaturedStatus = false, ImageFilePath = "inventory-WV1ZZZ2HZHH018327.jpg", Mileage = 111174, MSRP = 45000M, SalePrice = 44800M, SoldStatus = true, Year = 2017 },
            new Vehicle
            { VINNumber = "JF2SKADC3MH567373", BodyStyleType = "SUV", ColorName = "Blue", InteriorName = "Grey", MakeName = "Subaru", ModelName = "Forester", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "The Forester is the perfect vehicle to expore nature with!", FeaturedStatus = true, ImageFilePath = "inventory-JF2SKADC3MH567373.jpg", Mileage = 200, MSRP = 28282M, SalePrice = 28000M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "KNDMB5C16L6633732", BodyStyleType = "Van", ColorName = "White", InteriorName = "Blue", MakeName = "Kia", ModelName = "Carnival", TransmissionType = "Automatic", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "The Sedona is also known as the Carnival in some places!", FeaturedStatus = true, ImageFilePath = "inventory-KNDMB5C16L6633732.jpg", Mileage = 4175, MSRP = 33000M, SalePrice = 31350M, SoldStatus = false, Year = 2020 },
            new Vehicle
            { VINNumber = "MM0UP0YF100227000", BodyStyleType = "Truck", ColorName = "Grey", InteriorName = "Red", MakeName = "Mazda", ModelName = "BT-50", TransmissionType = "Manual", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "This truck is equipped for all kinds of things!", FeaturedStatus = true, ImageFilePath = "inventory-MM0UP0YF100227000.jpg", Mileage = 135204, MSRP = 30000M, SalePrice = 29000M, SoldStatus = false, Year = 2014 },
            new Vehicle
            { VINNumber = "WA1AAAFY0M2129834", BodyStyleType = "SUV", ColorName = "Black", InteriorName = "Yellow", MakeName = "Audi", ModelName = "Q5", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "This is a premium tier SUV!", FeaturedStatus = true, ImageFilePath = "inventory-WA1AAAFY0M2129834.jpg", Mileage = 999, MSRP = 49000M, SalePrice = 46999M, SoldStatus = false, Year = 2021 },
            new Vehicle
            { VINNumber = "WA1AJAF71MD040415", BodyStyleType = "SUV", ColorName = "White", InteriorName = "White", MakeName = "Audi", ModelName = "Q7", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 1), DateSold = null,
                Description = "Bigger, better, and more premium than all other SUVs!", FeaturedStatus = true, ImageFilePath = "inventory-WA1AJAF71MD040415.jpg", Mileage = 333, MSRP = 60000M, SalePrice = 57499M, SoldStatus = false, Year = 2021 },
            //new Vehicle
            //{ VINNumber = "11111111111111111", BodyStyleType = "Van", ColorName = "Black", InteriorName = "Black", MakeName = "Volkswagen", ModelName = "Bus", TransmissionType = "Automatic", VehicleTypeName = "New", DateAdded = new DateTime(2021, 8, 11), DateSold = null,
            //    Description = "NEW Placeholder Vehicle!", FeaturedStatus = false, ImageFilePath = "inventory-placeholder.jpg", Mileage = 100, MSRP = 100000M, SalePrice = 95000M, SoldStatus = false, Year = 2021 },
            //new Vehicle
            //{ VINNumber = "AAAAAAAAAAAAAAAAA", BodyStyleType = "Truck", ColorName = "White", InteriorName = "White", MakeName = "Subaru", ModelName = "Baja", TransmissionType = "Manual", VehicleTypeName = "Used", DateAdded = new DateTime(2021, 8, 11), DateSold = null,
            //    Description = "USED Placeholder Vehicle!", FeaturedStatus = false, ImageFilePath = "inventory-placeholder.jpg", Mileage = 100000, MSRP = 10000M, SalePrice = 9500M, SoldStatus = false, Year = 2006 },
            };
        }

        public void Delete(string VINNumber)
        {
            _vehicles.RemoveAll(v => v.VINNumber == VINNumber);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public Vehicle GetById(string VINNumber)
        {
            return _vehicles.FirstOrDefault(v => v.VINNumber == VINNumber);
        }

        public VehicleDetailItem GetDetails(string VINNumber)
        {
            VehicleDetailItem vehicleDetail = null;

            Vehicle vehicle = GetById(VINNumber);

            if (vehicle != null)
            {
                vehicleDetail = new VehicleDetailItem();
                vehicleDetail.VINNumber = vehicle.VINNumber;
                vehicleDetail.BodyStyleType = vehicle.BodyStyleType;
                vehicleDetail.ColorName = vehicle.ColorName;
                vehicleDetail.InteriorName = vehicle.InteriorName;
                vehicleDetail.MakeName = vehicle.MakeName;
                vehicleDetail.ModelName = vehicle.ModelName;
                vehicleDetail.TransmissionType = vehicle.TransmissionType;
                vehicleDetail.VehicleTypeName = vehicle.VehicleTypeName;
                vehicleDetail.ImageFilePath = vehicle.ImageFilePath;
                vehicleDetail.Mileage = vehicle.Mileage;
                vehicleDetail.MSRP = vehicle.MSRP;
                vehicleDetail.SalePrice = vehicle.SalePrice;
                vehicleDetail.Year = vehicle.Year;
                vehicleDetail.Description = vehicle.Description;
                vehicleDetail.SoldStatus = vehicle.SoldStatus;
            }

            return vehicleDetail;
        }

        public List<VehicleFeaturedItem> GetFeatured()
        {
            var featuredVehicles = new List<VehicleFeaturedItem>();

            foreach (var vehicle in _vehicles.Where(v => v.FeaturedStatus == true && v.DateSold == null))
            {
                VehicleFeaturedItem featured = new VehicleFeaturedItem();
                featured.VINNumber = vehicle.VINNumber;
                featured.ImageFilePath = vehicle.ImageFilePath;
                featured.Year = vehicle.Year;
                featured.MakeName = vehicle.MakeName;
                featured.ModelName = vehicle.ModelName;
                featured.SalePrice = vehicle.SalePrice;

                featuredVehicles.Add(featured);
            }

            return featuredVehicles;
        }

        public void Insert(Vehicle newVehicle)
        {
            newVehicle.DateAdded = DateTime.Today;
            _vehicles.Add(newVehicle);
        }

        public void Purchase(string purchasedVIN)
        {
            var purchasedVehicle = GetById(purchasedVIN);
            purchasedVehicle.DateSold = DateTime.Today;
            purchasedVehicle.FeaturedStatus = false;
            purchasedVehicle.SoldStatus = true;
            Update(purchasedVehicle, purchasedVIN);
        }

        public IEnumerable<VehicleReportItem> InventoryReport(string vehicleTypeName)
        {
            List<Vehicle> typedVehicles = _vehicles.Where(vt => vt.VehicleTypeName == vehicleTypeName && vt.SoldStatus == false).ToList();
            List<VehicleReportItem> returnedVehicles = new List<VehicleReportItem>();

            foreach (var vehicle in typedVehicles)
            {
                var found = returnedVehicles.FirstOrDefault(v => v.ModelName == vehicle.ModelName);

                if (found == null)
                {
                    VehicleReportItem addedVehicle = new VehicleReportItem();
                    addedVehicle.Year = vehicle.Year;
                    addedVehicle.MakeName = vehicle.MakeName;
                    addedVehicle.ModelName = vehicle.ModelName;
                    addedVehicle.VehicleCount = 1;
                    addedVehicle.StockValue = vehicle.MSRP;
                    returnedVehicles.Add(addedVehicle);
                }
                else
                {
                    var updatedVehicle = returnedVehicles.FirstOrDefault(v => v.ModelName == vehicle.ModelName);
                    updatedVehicle.VehicleCount++;
                    updatedVehicle.StockValue += vehicle.MSRP;
                    returnedVehicles.RemoveAll(v => v.ModelName == vehicle.ModelName);
                    returnedVehicles.Add(updatedVehicle);
                }
            }

            return returnedVehicles;
        }

        public IEnumerable<VehicleSearchItem> Search(VehicleSearchParameters parameters)
        {
            List<Vehicle> typedVehicles = null;

            if (parameters.VehicleTypeName.ToLower() == "all")
            {
                typedVehicles = _vehicles.Where(s => s.SoldStatus == false).ToList();
            }
            else
            {
                typedVehicles = _vehicles.Where(vt => vt.VehicleTypeName.ToLower() == parameters.VehicleTypeName.ToLower()).ToList(); // removed && vt.SoldStatus == false
            }

            if (parameters.MinPrice.HasValue)
            {
                typedVehicles = typedVehicles.Where(sp => sp.SalePrice > parameters.MinPrice).ToList();
            }
            if (parameters.MaxPrice.HasValue)
            {
                typedVehicles = typedVehicles.Where(sp => sp.SalePrice < parameters.MaxPrice).ToList();
            }
            if (parameters.MinYear.HasValue)
            {
                typedVehicles = typedVehicles.Where(y => y.Year > parameters.MinYear).ToList();
            }
            if (parameters.MaxYear.HasValue)
            {
                typedVehicles = typedVehicles.Where(y => y.Year < parameters.MaxYear).ToList();
            }

            List<Vehicle> vehicleResults = new List<Vehicle>();

            if (!string.IsNullOrEmpty(parameters.QuickSearch))  //.Union()
            {
                if (int.TryParse(parameters.QuickSearch, out int searchNumber))
                {
                    if (searchNumber >= 2000 && searchNumber < DateTime.Now.AddYears(1).Year)
                    {
                        vehicleResults = typedVehicles.Where(y => y.Year == searchNumber).ToList();
                    }
                }

                vehicleResults = vehicleResults.Union(typedVehicles.Where(m => m.ModelName.ToLower().Contains(parameters.QuickSearch.ToLower()))).ToList();
                vehicleResults = vehicleResults.Union(typedVehicles.Where(m => m.MakeName.ToLower().Contains(parameters.QuickSearch.ToLower()))).ToList();
            }
            else
            {
                vehicleResults = typedVehicles;
            }

            List<VehicleSearchItem> searchResults = new List<VehicleSearchItem>();

            foreach (var vehicle in vehicleResults)
            {
                VehicleSearchItem item = new VehicleSearchItem();
                item.VINNumber = vehicle.VINNumber;
                item.BodyStyleType = vehicle.BodyStyleType;
                item.ColorName = vehicle.ColorName;
                item.InteriorName = vehicle.InteriorName;
                item.MakeName = vehicle.MakeName;
                item.ModelName = vehicle.ModelName;
                item.TransmissionType = vehicle.TransmissionType;
                item.VehicleTypeName = vehicle.VehicleTypeName;
                item.ImageFilePath = vehicle.ImageFilePath;
                item.Mileage = vehicle.Mileage;
                item.MSRP = vehicle.MSRP;
                item.SalePrice = vehicle.SalePrice;
                item.Year = vehicle.Year;

                searchResults.Add(item);
            }

            return searchResults.OrderByDescending(i => i.SalePrice).Take(20); // Can be any order, I just thought price was ~car dealershippy~.
        }

        public void Update(Vehicle updatedVehicle, string oldVIN)
        {
            var found = _vehicles.FirstOrDefault(v => v.VINNumber == oldVIN);

            if (found != null)
            {
                _vehicles.RemoveAll(v => v.VINNumber == oldVIN);
                _vehicles.Add(updatedVehicle);
            }
        }
    }
}
