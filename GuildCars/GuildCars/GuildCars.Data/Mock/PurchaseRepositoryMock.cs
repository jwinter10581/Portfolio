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
    public class PurchaseRepositoryMock : IPurchaseRepository
    {
        private static List<Purchase> _purchases = new List<Purchase>
        {
            new Purchase
            { PurchaseId = 1, EmployeeId = 1, EmployeeName = "System Administrator", PurchaseTypeId = 1, StateAbbreviation = "MN", VINNumber = "4S4BSACC2J3216989", Name = "Stephen", Email = "stephen@email.com", Phone = "111-111-1111", Street1 = "100 Main Street",
                Street2 = null, City = "Minneapolis", ZipCode = "55111", PurchasePrice = 19000M, PurchaseDate = new DateTime(2021, 8, 2)},
            new Purchase
            { PurchaseId = 2, EmployeeId = 2, EmployeeName = "Sales Person", PurchaseTypeId = 2, StateAbbreviation = "KY", VINNumber = "WV1ZZZ2HZHH018327", Name = "Mark", Email = "mark@email.com", Phone = "222-222-2222", Street1 = "2000 Big Road",
                Street2 = "Apt 234", City = "Louisville", ZipCode = "40018", PurchasePrice = 44800M, PurchaseDate = new DateTime(2021, 8, 3)}
        };

        public static void Initialize()
        {
            _purchases = new List<Purchase>
            {
                new Purchase
                { PurchaseId = 1, EmployeeId = 1, EmployeeName = "System Administrator", PurchaseTypeId = 1, StateAbbreviation = "MN", VINNumber = "4S4BSACC2J3216989", Name = "Stephen", Email = "stephen@email.com", Phone = "111-111-1111", Street1 = "100 Main Street",
                    Street2 = null, City = "Minneapolis", ZipCode = "55111", PurchasePrice = 19000M, PurchaseDate = new DateTime(2021, 8, 2)},
                new Purchase
                { PurchaseId = 2, EmployeeId = 2, EmployeeName = "Sales Person", PurchaseTypeId = 2, StateAbbreviation = "KY", VINNumber = "WV1ZZZ2HZHH018327", Name = "Mark", Email = "mark@email.com", Phone = "222-222-2222", Street1 = "2000 Big Road",
                    Street2 = "Apt 234", City = "Louisville", ZipCode = "40018", PurchasePrice = 44800M, PurchaseDate = new DateTime(2021, 8, 3)}
            };
        }

        public List<Purchase> GetAll()
        {
            return _purchases;
        }

        public Purchase GetById(int purchaseId)
        {
            return _purchases.FirstOrDefault(s => s.PurchaseId == purchaseId);
        }

        public void Insert(Purchase newPurchase)
        {
            if (_purchases.Any())
            {
                newPurchase.PurchaseId = _purchases.Max(m => m.PurchaseId) + 1;
            }
            else
            {
                newPurchase.PurchaseId = 1;
            }

            newPurchase.PurchaseDate = DateTime.Today;

            _purchases.Add(newPurchase);
        }

        public IEnumerable<SalesReportItem> Search(PurchaseSearchParameters parameters)
        {
            List<Purchase> purchases = null;

            if(parameters.EmployeeId == null)
            {
                purchases = _purchases;
            }
            else
            {
                purchases = _purchases.Where(e => e.EmployeeId == parameters.EmployeeId).ToList();
            }

            if (DateTime.TryParse(parameters.FromText, out DateTime searchFrom))
            {
                parameters.FromDate = searchFrom;
                purchases = purchases.Where(fd => fd.PurchaseDate >= parameters.FromDate).ToList();
            }
            else
            {
                parameters.FromDate = new DateTime(2000, 1, 1);
                purchases = purchases.Where(fd => fd.PurchaseDate >= parameters.FromDate).ToList();
            }

            if (DateTime.TryParse(parameters.ToText, out DateTime searchTo))
            {
                parameters.ToDate = searchTo;
                purchases = purchases.Where(fd => fd.PurchaseDate <= parameters.ToDate).ToList();
            }
            else
            {
                parameters.ToDate = DateTime.Now;
                purchases = purchases.Where(fd => fd.PurchaseDate <= parameters.ToDate).ToList();
            }

            List<SalesReportItem> sales = new List<SalesReportItem>();

            foreach (var purchase in purchases)
            {
                var found = sales.FirstOrDefault(v => v.EmployeeId == purchase.EmployeeId);

                if (found == null)
                {
                    SalesReportItem addedSale = new SalesReportItem();
                    addedSale.EmployeeId = purchase.EmployeeId;
                    addedSale.EmployeeName = purchase.EmployeeName;
                    addedSale.TotalSales = purchase.PurchasePrice;
                    addedSale.TotalVehicles = 1;
                    sales.Add(addedSale);
                }
                else
                {
                    var updatedSale = sales.FirstOrDefault(s => s.EmployeeId == purchase.EmployeeId);
                    updatedSale.TotalVehicles++;
                    updatedSale.TotalSales += purchase.PurchasePrice;
                    sales.RemoveAll(s => s.EmployeeId == purchase.EmployeeId);
                    sales.Add(updatedSale);
                }
            }

            return sales;
        }
    }
}

