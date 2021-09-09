using GuildCars.Data.Mock;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.RepositoryTests
{
    [TestFixture]
    public class MockTests
    {
        [SetUp]
        public void Initialize()
        {
            ContactRepositoryMock.Initialize();
            EmployeeRepositoryMock.Initialize();
            MakeRepositoryMock.Initialize();
            ModelRepositoryMock.Initialize();
            PurchaseRepositoryMock.Initialize();
            SpecialRepositoryMock.Initialize();
            VehicleRepositoryMock.Initialize();
        }

        [Test]
        public void CanGetAllBodyStyles()
        {
            var repo = new BodyStyleRepositoryMock();
            var bodyStyles = repo.GetAll();

            Assert.AreEqual(4, bodyStyles.Count());
            Assert.AreEqual("Car", bodyStyles[0].BodyStyleType);
            Assert.AreEqual("SUV", bodyStyles[1].BodyStyleType);
            Assert.AreEqual("Truck", bodyStyles[2].BodyStyleType);
            Assert.AreEqual("Van", bodyStyles[3].BodyStyleType);
        }

        [Test]
        public void CanGetAllColors()
        {
            var repo = new ColorRepositoryMock();
            var colors = repo.GetAll();

            Assert.AreEqual(6, colors.Count());
            Assert.AreEqual("White", colors[0].ColorName);
            Assert.AreEqual("Black", colors[1].ColorName);
            Assert.AreEqual("Grey", colors[2].ColorName);
            Assert.AreEqual("Red", colors[3].ColorName);
            Assert.AreEqual("Yellow", colors[4].ColorName);
            Assert.AreEqual("Blue", colors[5].ColorName);
        }

        [Test]
        public void CanGetAllContacts()
        {
            var repo = new ContactRepositoryMock();
            var contacts = repo.GetAll();

            Assert.AreEqual(1, contacts.Count());
            Assert.AreEqual("John Smith", contacts[0].Name);
            Assert.AreEqual("johnsmith@email.com", contacts[0].Email);
            Assert.AreEqual("555-555-5555", contacts[0].Phone);
            Assert.AreEqual("Hello, I would like one car please!", contacts[0].Message);
            Assert.AreEqual("3MZBM1U76FM220997", contacts[0].VINNumber);
        }

        [Test]
        public void CanAddContacts()
        {
            var repo = new ContactRepositoryMock();
            var contacts = repo.GetAll();
            Assert.AreEqual(1, contacts.Count());

            var newContact = new Contact();
            newContact.Name = "Test";
            newContact.Email = "test@test.com";
            newContact.Phone = "123-456-7890";
            newContact.Message = "Test message";
            newContact.VINNumber = "1234567890abcdefg";

            repo.Insert(newContact);

            Assert.AreEqual(2, contacts.Count());
            Assert.AreEqual(2, contacts[1].ContactId);
            Assert.AreEqual("Test", contacts[1].Name);
            Assert.AreEqual("test@test.com", contacts[1].Email);
            Assert.AreEqual("123-456-7890", contacts[1].Phone);
            Assert.AreEqual("Test message", contacts[1].Message);
            Assert.AreEqual("1234567890abcdefg", contacts[1].VINNumber);
        }

        [Test]
        public void CanGetAllEmployees()
        {
            var repo = new EmployeeRepositoryMock();
            var employees = repo.GetAll();

            Assert.AreEqual(3, employees.Count());
            Assert.AreEqual("System", employees[0].EmployeeFirstName);
            Assert.AreEqual("Administrator", employees[0].EmployeeLastName);
            Assert.AreEqual("admin@guildcars.com", employees[0].EmployeeEmail);
            Assert.AreEqual("Admin", employees[0].RoleName);
        }

        [Test]
        public void CanGetEmployeeById()
        {
            var repo = new EmployeeRepositoryMock();
            var employee = repo.GetByEmployeeId(2);

            Assert.AreEqual(2, employee.EmployeeId);
            Assert.AreEqual("Sales", employee.EmployeeFirstName);
            Assert.AreEqual("Person", employee.EmployeeLastName);
            Assert.AreEqual("sales@guildcars.com", employee.EmployeeEmail);
            Assert.AreEqual("Sales", employee.RoleName);
        }

        [Test]
        public void CanGetEmployeeByEmail()
        {
            var repo = new EmployeeRepositoryMock();

            var employee = repo.GetByEmployeeEmail("disabled@guildcars.com");
            Assert.AreEqual(3, employee.EmployeeId);
            Assert.AreEqual("Disabled", employee.EmployeeFirstName);
            Assert.AreEqual("User", employee.EmployeeLastName);
            Assert.AreEqual("disabled@guildcars.com", employee.EmployeeEmail);
            Assert.AreEqual("Disabled", employee.RoleName);
        }

        [Test]
        public void CanAddEmployee()
        {
            var repo = new EmployeeRepositoryMock();
            var employees = repo.GetAll();
            Assert.AreEqual(3, employees.Count());

            var newEmployee = new Employee();
            newEmployee.EmployeeFirstName = "Testy";
            newEmployee.EmployeeLastName = "McTestface";
            newEmployee.EmployeeEmail = "test@guildcars.com";
            newEmployee.RoleName = "tester";
            repo.Insert(newEmployee);

            employees = repo.GetAll();
            Assert.AreEqual(4, employees.Count());
            Assert.AreEqual("Testy", employees[3].EmployeeFirstName);
            Assert.AreEqual("McTestface", employees[3].EmployeeLastName);
            Assert.AreEqual("test@guildcars.com", employees[3].EmployeeEmail);
            Assert.AreEqual("tester", employees[3].RoleName);
        }

        [Test]
        public void CanUpdateEmployee()
        {
            var repo = new EmployeeRepositoryMock();
            var employees = repo.GetAll();
            Assert.AreEqual(3, employees.Count());

            var updatedEmployee = repo.GetByEmployeeId(2);
            updatedEmployee.EmployeeFirstName = "Testy";
            updatedEmployee.EmployeeLastName = "McTestface";
            updatedEmployee.EmployeeEmail = "test@guildcars.com";
            repo.Update(updatedEmployee);

            employees = repo.GetAll();
            Assert.AreEqual(3, employees.Count());
            Assert.AreEqual("Testy", employees[2].EmployeeFirstName);
            Assert.AreEqual("McTestface", employees[2].EmployeeLastName);
            Assert.AreEqual("test@guildcars.com", employees[2].EmployeeEmail);
        }

        [Test]
        public void CanGetAllInteriors()
        {
            var repo = new InteriorRepositoryMock();
            var interiors = repo.GetAll();

            Assert.AreEqual(6, interiors.Count());
            Assert.AreEqual("White", interiors[0].InteriorName);
            Assert.AreEqual("Black", interiors[1].InteriorName);
            Assert.AreEqual("Grey", interiors[2].InteriorName);
            Assert.AreEqual("Red", interiors[3].InteriorName);
            Assert.AreEqual("Yellow", interiors[4].InteriorName);
            Assert.AreEqual("Blue", interiors[5].InteriorName);
        }

        [Test]
        public void CanGetAllMakes()
        {
            var repo = new MakeRepositoryMock();
            var makes = repo.GetAll();

            Assert.AreEqual(5, makes.Count());
            Assert.AreEqual("Kia", makes[0].MakeName);
            Assert.AreEqual("Mazda", makes[1].MakeName);
            Assert.AreEqual("Audi", makes[2].MakeName);
            Assert.AreEqual("Subaru", makes[3].MakeName);
            Assert.AreEqual("Volkswagen", makes[4].MakeName);
        }

        [Test]
        public void CanGetMakeById()
        {
            var repo = new MakeRepositoryMock();
            var make = repo.GetById(3);

            Assert.AreEqual(3, make.MakeId);
            Assert.AreEqual("Audi", make.MakeName);
            Assert.AreEqual(new DateTime(2021, 7, 22), make.DateAdded);
            Assert.AreEqual(2, make.EmployeeId);
        }

        [Test]
        public void CanAddMakes()
        {
            var repo = new MakeRepositoryMock();
            var makes = repo.GetAll();
            Assert.AreEqual(5, makes.Count());

            var newMake = new Make();
            newMake.MakeName = "Rolls-Royce";
            newMake.DateAdded = DateTime.Today;
            newMake.EmployeeId = 1;

            repo.Insert(newMake);
            makes = repo.GetAll();
            Assert.AreEqual(6, makes.Count());
            Assert.AreEqual(6, makes[5].MakeId);
            Assert.AreEqual("Rolls-Royce", makes[5].MakeName);
            Assert.AreEqual(DateTime.Today, makes[5].DateAdded);
            Assert.AreEqual(1, makes[5].EmployeeId);
        }

        [Test]
        public void CanGetAllModels()
        {
            var repo = new ModelRepositoryMock();
            var models = repo.GetAll();

            Assert.AreEqual(25, models.Count());
            Assert.AreEqual("Soul", models[0].ModelName);
            Assert.AreEqual("3", models[5].ModelName);
            Assert.AreEqual("Q5", models[10].ModelName);
            Assert.AreEqual("Outback", models[15].ModelName);
            Assert.AreEqual("Golf", models[22].ModelName);
        }

        [Test]
        public void CanGetModelById()
        {
            var repo = new ModelRepositoryMock();
            var model = repo.GetById(25);

            Assert.AreEqual(25, model.ModelId); 
            Assert.AreEqual("Bus", model.ModelName); 
            Assert.AreEqual(new DateTime(2021, 7, 22), model.DateAdded); 
            Assert.AreEqual("Volkswagen", model.MakeName); 
            Assert.AreEqual(3, model.EmployeeId);
        }

        [Test]
        public void CanAddModels()
        {
            var repo = new ModelRepositoryMock();
            var models = repo.GetAll();
            Assert.AreEqual(25, models.Count());

            var newModel = new Model();
            newModel.ModelName = "Crosstrek";
            newModel.DateAdded = DateTime.Today;
            newModel.MakeName = "Subaru";
            newModel.EmployeeId = 1;

            repo.Insert(newModel);
            models = repo.GetAll();
            Assert.AreEqual(26, models.Count());
            Assert.AreEqual(26, models[25].ModelId);
            Assert.AreEqual("Crosstrek", models[25].ModelName);
            Assert.AreEqual(DateTime.Today, models[25].DateAdded);
            Assert.AreEqual("Subaru", models[25].MakeName);
            Assert.AreEqual(1, models[25].EmployeeId);
        }

        [Test]
        public void CanGetAllPurchases()
        {
            var repo = new PurchaseRepositoryMock();
            var purchases = repo.GetAll();

            Assert.AreEqual(2, purchases.Count());
        }

        [Test]
        public void CanGetPurchaseById()
        {
            var repo = new PurchaseRepositoryMock();
            var purchase = repo.GetById(1);

            Assert.AreEqual(1, purchase.PurchaseId);
            Assert.AreEqual(1, purchase.EmployeeId);
            Assert.AreEqual("System Administrator", purchase.EmployeeName);
            Assert.AreEqual(1, purchase.PurchaseTypeId);
            Assert.AreEqual("MN", purchase.StateAbbreviation);
            Assert.AreEqual("4S4BSACC2J3216989", purchase.VINNumber);
            Assert.AreEqual("Stephen", purchase.Name);
            Assert.AreEqual("stephen@email.com", purchase.Email);
            Assert.AreEqual("111-111-1111", purchase.Phone);
            Assert.AreEqual("100 Main Street", purchase.Street1);
            Assert.AreEqual(null, purchase.Street2);
            Assert.AreEqual("Minneapolis", purchase.City);
            Assert.AreEqual("55111", purchase.ZipCode);
            Assert.AreEqual(19000M, purchase.PurchasePrice);
            Assert.AreEqual(new DateTime(2021, 8, 2), purchase.PurchaseDate);
        }

        [Test]
        public void CanAddPurchase()
        {
            var repo = new PurchaseRepositoryMock();
            var purchases = repo.GetAll();
            Assert.AreEqual(2, purchases.Count());

            var newpurchase = new Purchase();
            newpurchase.EmployeeId = 2;
            newpurchase.EmployeeName = "Sales Person";
            newpurchase.PurchaseTypeId = 2;
            newpurchase.StateAbbreviation = "KY";
            newpurchase.VINNumber = "WA1LHAF73JD022711";
            newpurchase.Name = "Mariah";
            newpurchase.Email = "mariah@email.com";
            newpurchase.Phone = "222-222-2222";
            newpurchase.Street1 = "200 Secondary Street";
            newpurchase.Street2 = "Apt 222";
            newpurchase.City = "Frankfort";
            newpurchase.ZipCode = "60423";
            newpurchase.PurchasePrice = 38499M;
            newpurchase.PurchaseDate = DateTime.Today;

            repo.Insert(newpurchase);
            purchases = repo.GetAll();
            Assert.AreEqual(3, purchases[2].PurchaseId);
            Assert.AreEqual(2, purchases[2].EmployeeId);
            Assert.AreEqual(2, purchases[2].PurchaseTypeId);
            Assert.AreEqual("KY", purchases[2].StateAbbreviation);
            Assert.AreEqual("WA1LHAF73JD022711", purchases[2].VINNumber);
            Assert.AreEqual("Mariah", purchases[2].Name);
            Assert.AreEqual("mariah@email.com", purchases[2].Email);
            Assert.AreEqual("222-222-2222", purchases[2].Phone);
            Assert.AreEqual("200 Secondary Street", purchases[2].Street1);
            Assert.AreEqual("Apt 222", purchases[2].Street2);
            Assert.AreEqual("Frankfort", purchases[2].City);
            Assert.AreEqual("60423", purchases[2].ZipCode);
            Assert.AreEqual(38499M, purchases[2].PurchasePrice);
            Assert.AreEqual(DateTime.Today, purchases[2].PurchaseDate);
        }

        [Test]
        public void CanSearchPurchasesByEmployee()
        {
            var repo = new PurchaseRepositoryMock();
            var parameters = new PurchaseSearchParameters();
            parameters.EmployeeId = 1;

            var reportItems = repo.Search(parameters).ToList();
            
            Assert.AreEqual(1, reportItems.Count());
            Assert.AreEqual(1, reportItems[0].EmployeeId);
            Assert.AreEqual("System Administrator", reportItems[0].EmployeeName);
            Assert.AreEqual(19000M, reportItems[0].TotalSales);
            Assert.AreEqual(1, reportItems[0].TotalVehicles);
        }

        [Test]
        public void CanGetAllPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryMock();
            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(3, purchaseTypes.Count());
            Assert.AreEqual(1, purchaseTypes[0].PurchaseTypeId);
            Assert.AreEqual("Bank Finance", purchaseTypes[0].PurchaseTypeName);
            Assert.AreEqual(2, purchaseTypes[1].PurchaseTypeId);
            Assert.AreEqual("Cash", purchaseTypes[1].PurchaseTypeName);
            Assert.AreEqual(3, purchaseTypes[2].PurchaseTypeId);
            Assert.AreEqual("Dealer Finance", purchaseTypes[2].PurchaseTypeName);
        }

        [Test]
        public void CanGetAllRoles()
        {
            var repo = new RoleRepositoryMock();
            var roles = repo.GetAll();

            Assert.AreEqual(3, roles.Count());
            Assert.AreEqual(1, roles[0].RoleId);
            Assert.AreEqual("Admin", roles[0].RoleName);
            Assert.AreEqual(2, roles[1].RoleId);
            Assert.AreEqual("Sales", roles[1].RoleName);
            Assert.AreEqual(3, roles[2].RoleId);
            Assert.AreEqual("Disabled", roles[2].RoleName);
        }

        [Test]
        public void CanGetAllSpecials()
        {
            var repo = new SpecialRepositoryMock();
            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count());
            Assert.AreEqual("Special Title 1", specials[0].Title);
        }

        [Test]
        public void CanGetSpecialById()
        {
            var repo = new SpecialRepositoryMock();

            var special = repo.GetById(1);
            Assert.AreEqual("Special Title 1", special.Title);
        }

        [Test]
        public void CanAddSpecials()
        {
            var repo = new SpecialRepositoryMock();
            var specials = repo.GetAll();
            Assert.AreEqual(3, specials.Count());

            var newSpecial = new Special();
            newSpecial.Title = "Title 4";
            newSpecial.Description = "New description";

            repo.Insert(newSpecial);
            specials = repo.GetAll();
            Assert.AreEqual(4, specials.Count());
            Assert.AreEqual("Title 4", specials[3].Title);
            Assert.AreEqual("New description", specials[3].Description);
        }

        [Test]
        public void CanDeleteSpecials()
        {
            var repo = new SpecialRepositoryMock();
            var specials = repo.GetAll();
            Assert.AreEqual(3, specials.Count());

            repo.Delete(1);
            specials = repo.GetAll();
            Assert.AreEqual(2, specials.Count());
        }

        [Test]
        public void CanGetAllStates()
        {
            var repo = new StateRepositoryMock();
            var states = repo.GetAll();

            Assert.AreEqual(50, states.Count());
        }

        [Test]
        public void CanGetAllTransmissions()
        {
            var repo = new TransmissionRepositoryMock();
            var transmissions = repo.GetAll();

            Assert.AreEqual(2, transmissions.Count());
            Assert.AreEqual(1, transmissions[0].TransmissionId);
            Assert.AreEqual("Automatic", transmissions[0].TransmissionType);
            Assert.AreEqual(2, transmissions[1].TransmissionId);
            Assert.AreEqual("Manual", transmissions[1].TransmissionType);
        }

        [Test]
        public void CanGetAllVehicles()
        {
            var repo = new VehicleRepositoryMock();
            var vehicles = repo.GetAll();

            Assert.AreEqual(10, vehicles.Count());
            Assert.AreEqual("3MZBM1U76FM220997", vehicles[0].VINNumber);
            Assert.AreEqual("Car", vehicles[0].BodyStyleType);
            Assert.AreEqual("Blue", vehicles[0].ColorName);
            Assert.AreEqual("Black", vehicles[0].InteriorName);
            Assert.AreEqual("Mazda", vehicles[0].MakeName);
            Assert.AreEqual("3", vehicles[0].ModelName);
            Assert.AreEqual("Automatic", vehicles[0].TransmissionType);
            Assert.AreEqual("Used", vehicles[0].VehicleTypeName);
            Assert.AreEqual(new DateTime(2021, 7, 22), vehicles[0].DateAdded);
            Assert.AreEqual(null, vehicles[0].DateSold);
            Assert.AreEqual("It's my car!", vehicles[0].Description);
            Assert.AreEqual(true, vehicles[0].FeaturedStatus);
            Assert.AreEqual("inventory-3MZBM1U76FM220997.jpg", vehicles[0].ImageFilePath);
            Assert.AreEqual(50000, vehicles[0].Mileage);
            Assert.AreEqual(12000M, vehicles[0].MSRP);
            Assert.AreEqual(11400M, vehicles[0].SalePrice);
            Assert.AreEqual(false, vehicles[0].SoldStatus);
            Assert.AreEqual(2015, vehicles[0].Year);
        }

        [Test]
        public void CanGetVehicleByVIN()
        {
            var repo = new VehicleRepositoryMock();
            var vehicle = repo.GetById("3VW6T7AU7MM007118");

            Assert.AreEqual("3VW6T7AU7MM007118", vehicle.VINNumber);
            Assert.AreEqual("Car", vehicle.BodyStyleType);
            Assert.AreEqual("White", vehicle.ColorName);
            Assert.AreEqual("Black", vehicle.InteriorName);
            Assert.AreEqual("Volkswagen", vehicle.MakeName);
            Assert.AreEqual("Golf", vehicle.ModelName);
            Assert.AreEqual("Manual", vehicle.TransmissionType);
            Assert.AreEqual("New", vehicle.VehicleTypeName);
            Assert.AreEqual(new DateTime(2021, 7, 22), vehicle.DateAdded);
            Assert.AreEqual(null, vehicle.DateSold);
            Assert.AreEqual("It's got a bunch of super new nice features!", vehicle.Description);
            Assert.AreEqual(true, vehicle.FeaturedStatus);
            Assert.AreEqual("inventory-3VW6T7AU7MM007118.jpg", vehicle.ImageFilePath);
            Assert.AreEqual(150, vehicle.Mileage);
            Assert.AreEqual(35135M, vehicle.MSRP);
            Assert.AreEqual(34000M, vehicle.SalePrice);
            Assert.AreEqual(false, vehicle.SoldStatus);
            Assert.AreEqual(2021, vehicle.Year);
        }

        [Test]
        public void CanGetVehicleDetails()
        {
            var repo = new VehicleRepositoryMock();
            var vehicleDetails = repo.GetDetails("WA1AJAF71MD040415");

            Assert.AreEqual("WA1AJAF71MD040415", vehicleDetails.VINNumber);
            Assert.AreEqual("SUV", vehicleDetails.BodyStyleType);
            Assert.AreEqual("White", vehicleDetails.ColorName);
            Assert.AreEqual("White", vehicleDetails.InteriorName);
            Assert.AreEqual("Q7", vehicleDetails.ModelName);
            Assert.AreEqual("Audi", vehicleDetails.MakeName);
            Assert.AreEqual("Automatic", vehicleDetails.TransmissionType);
            Assert.AreEqual("New", vehicleDetails.VehicleTypeName);
            Assert.AreEqual("inventory-WA1AJAF71MD040415.jpg", vehicleDetails.ImageFilePath);
            Assert.AreEqual(333, vehicleDetails.Mileage);
            Assert.AreEqual(60000M, vehicleDetails.MSRP);
            Assert.AreEqual(57499M, vehicleDetails.SalePrice);
            Assert.AreEqual(2021, vehicleDetails.Year);
            Assert.AreEqual("Bigger, better, and more premium than all other SUVs!", vehicleDetails.Description);
        }

        [Test]
        public void CanGetFeaturedVehicles()
        {
            var repo = new VehicleRepositoryMock();
            var featuredVehicles = repo.GetFeatured();

            Assert.AreEqual(8, featuredVehicles.Count());
        }

        [Test]
        public void CanSearchOnQuickSearch()
        {
            var repo = new VehicleRepositoryMock();
            var parameters = new VehicleSearchParameters();
           
            parameters.VehicleTypeName = "New";
            parameters.QuickSearch = "Audi";
            var searchResults = repo.Search(parameters);
            Assert.AreEqual(2, searchResults.Count());

            parameters.VehicleTypeName = "Used";
            parameters.QuickSearch = "ou";
            searchResults = repo.Search(parameters);
            Assert.AreEqual(2, searchResults.Count());

            parameters.VehicleTypeName = "All";
            parameters.QuickSearch = "k";
            searchResults = repo.Search(parameters);
            Assert.AreEqual(3, searchResults.Count());

            parameters.VehicleTypeName = "All";
            parameters.QuickSearch = "2021";
            searchResults = repo.Search(parameters);
            Assert.AreEqual(4, searchResults.Count());
        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = new VehicleRepositoryMock();
            var parameters = new VehicleSearchParameters();
            parameters.VehicleTypeName = "New";
            parameters.MinPrice = 10000M;

            var searchResults = repo.Search(parameters);

            Assert.AreEqual(4, searchResults.Count());
        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = new VehicleRepositoryMock();
            var parameters = new VehicleSearchParameters();
            parameters.VehicleTypeName = "New";
            parameters.MaxPrice = 50000M;

            var searchResults = repo.Search(parameters);

            Assert.AreEqual(3, searchResults.Count());
        }

        [Test]
        public void CanSearchOnMinYear()
        {
            var repo = new VehicleRepositoryMock();
            var parameters = new VehicleSearchParameters();
            parameters.VehicleTypeName = "Used";
            parameters.MinYear = 2010;

            var searchResults = repo.Search(parameters);

            Assert.AreEqual(6, searchResults.Count());
        }

        [Test]
        public void CanSearchOnMaxYear()
        {
            var repo = new VehicleRepositoryMock();
            var parameters = new VehicleSearchParameters();
            parameters.VehicleTypeName = "Used";
            parameters.MaxYear = 2015;

            var searchResults = repo.Search(parameters);

            Assert.AreEqual(2, searchResults.Count());
        }

        [Test]
        public void CanAddVehicle()
        {
            var repo = new VehicleRepositoryMock();
            var vehicles = repo.GetAll();
            Assert.AreEqual(10, vehicles.Count());

            var newVehicle = new Vehicle();
            newVehicle.VINNumber = "4S4BT61C736109709";
            newVehicle.BodyStyleType = "Truck";
            newVehicle.ColorName = "Yellow";
            newVehicle.InteriorName = "Black";
            newVehicle.MakeName = "Subaru";
            newVehicle.ModelName = "Baja";
            newVehicle.TransmissionType = "Manual";
            newVehicle.VehicleTypeName = "Used";
            newVehicle.DateAdded = DateTime.Today;
            newVehicle.DateSold = null;
            newVehicle.Description = "It's a 2003 Subaru Baja!";
            newVehicle.FeaturedStatus = true;
            newVehicle.ImageFilePath = "inventory-2003SubaruBaja.jpg";
            newVehicle.Mileage = 175948;
            newVehicle.MSRP = 8000M;
            newVehicle.SalePrice = 7250M;
            newVehicle.SoldStatus = false;
            newVehicle.Year = 2003;

            repo.Insert(newVehicle);
            vehicles = repo.GetAll();

            Assert.AreEqual(11, vehicles.Count());
            Assert.AreEqual("4S4BT61C736109709", vehicles[10].VINNumber);
            Assert.AreEqual("Truck", vehicles[10].BodyStyleType);
            Assert.AreEqual("Yellow", vehicles[10].ColorName);
            Assert.AreEqual("Black", vehicles[10].InteriorName);
            Assert.AreEqual("Subaru", vehicles[10].MakeName);
            Assert.AreEqual("Baja", vehicles[10].ModelName);
            Assert.AreEqual("Manual", vehicles[10].TransmissionType);
            Assert.AreEqual("Used", vehicles[10].VehicleTypeName);
            Assert.AreEqual(DateTime.Today, vehicles[10].DateAdded);
            Assert.AreEqual(null, vehicles[10].DateSold);
            Assert.AreEqual("It's a 2003 Subaru Baja!", vehicles[10].Description);
            Assert.AreEqual(true, vehicles[10].FeaturedStatus);
            Assert.AreEqual("inventory-2003SubaruBaja.jpg", vehicles[10].ImageFilePath);
            Assert.AreEqual(175948, vehicles[10].Mileage);
            Assert.AreEqual(8000M, vehicles[10].MSRP);
            Assert.AreEqual(7250M, vehicles[10].SalePrice);
            Assert.AreEqual(false, vehicles[10].SoldStatus);
            Assert.AreEqual(2003, vehicles[10].Year);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            var repo = new VehicleRepositoryMock();
            var vehicles = repo.GetAll();
            Assert.AreEqual(10, vehicles.Count());

            var updatedVehicle = repo.GetById("KNDJT2A59C7444605");
            updatedVehicle.BodyStyleType = "Car";
            updatedVehicle.ColorName = "Black";
            updatedVehicle.InteriorName = "White";
            updatedVehicle.MakeName = "Kia";
            updatedVehicle.ModelName = "Soul";
            updatedVehicle.TransmissionType = "Manual";
            updatedVehicle.VehicleTypeName = "Used";
            updatedVehicle.DateAdded = DateTime.Today;
            updatedVehicle.Description = "Test";
            updatedVehicle.FeaturedStatus = false;
            updatedVehicle.ImageFilePath = "inventory-test.jpg";
            updatedVehicle.Mileage = 150000;
            updatedVehicle.MSRP = 5000M;
            updatedVehicle.SalePrice = 4000M;
            updatedVehicle.Year = 2021;
            repo.Update(updatedVehicle, updatedVehicle.VINNumber);

            vehicles = repo.GetAll();
            Assert.AreEqual(10, vehicles.Count());
            Assert.AreEqual("KNDJT2A59C7444605", vehicles[9].VINNumber);
            Assert.AreEqual("Car", vehicles[9].BodyStyleType);
            Assert.AreEqual("Black", vehicles[9].ColorName);
            Assert.AreEqual("White", vehicles[9].InteriorName);
            Assert.AreEqual("Kia", vehicles[9].MakeName);
            Assert.AreEqual("Soul", vehicles[9].ModelName);
            Assert.AreEqual("Manual", vehicles[9].TransmissionType);
            Assert.AreEqual("Used", vehicles[9].VehicleTypeName);
            Assert.AreEqual(DateTime.Today, vehicles[9].DateAdded);
            Assert.AreEqual(null, vehicles[9].DateSold);
            Assert.AreEqual("Test", vehicles[9].Description);
            Assert.AreEqual(false, vehicles[9].FeaturedStatus);
            Assert.AreEqual("inventory-test.jpg", vehicles[9].ImageFilePath);
            Assert.AreEqual(150000, vehicles[9].Mileage);
            Assert.AreEqual(5000M, vehicles[9].MSRP);
            Assert.AreEqual(4000M, vehicles[9].SalePrice);
            Assert.AreEqual(false, vehicles[9].SoldStatus);
            Assert.AreEqual(2021, vehicles[9].Year);
        }

        [Test]
        public void CanDeleteVehicle()
        {
            var repo = new VehicleRepositoryMock();
            var vehicles = repo.GetAll();
            Assert.AreEqual(10, vehicles.Count());

            repo.Delete("KNDJT2A59C7444605");
            vehicles = repo.GetAll();
            Assert.AreEqual(9, vehicles.Count());
        }
        
        [Test]
        public void CanGetInventoryReport()
        {
            var repo = new VehicleRepositoryMock();

            var reportItems = repo.InventoryReport("New");
            Assert.AreEqual(4, reportItems.Count());

            reportItems = repo.InventoryReport("Used");
            Assert.AreEqual(4, reportItems.Count());
        }

        [Test]
        public void CanPurchaseVehicle()
        {
            var repo = new VehicleRepositoryMock();

            var purchasedVIN = "KNDJT2A59C7444605";
            var purchasedVehicle = repo.GetById(purchasedVIN);
            Assert.AreEqual(false, purchasedVehicle.SoldStatus);

            repo.Purchase(purchasedVIN);
            purchasedVehicle = repo.GetById(purchasedVIN);
            Assert.AreEqual(true, purchasedVehicle.SoldStatus);
        }

        [Test]
        public void CanGetAllVehicleTypes()
        {
            var repo = new VehicleTypeRepositoryMock();
            var vehicleTypes = repo.GetAll();

            Assert.AreEqual(2, vehicleTypes.Count());
            Assert.AreEqual(1, vehicleTypes[0].VehicleTypeId);
            Assert.AreEqual("New", vehicleTypes[0].VehicleTypeName);
            Assert.AreEqual(2, vehicleTypes[1].VehicleTypeId);
            Assert.AreEqual("Used", vehicleTypes[1].VehicleTypeName);
        }
    }
}
