using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class PurchaseTypeRepositoryMock : IPurchaseTypeRepository
    {
        private static List<PurchaseType> _purchaseTypes = new List<PurchaseType>
        {
            new PurchaseType
            { PurchaseTypeId = 1, PurchaseTypeName = "Bank Finance"},
            new PurchaseType
            { PurchaseTypeId = 2, PurchaseTypeName = "Cash"},
            new PurchaseType
            { PurchaseTypeId = 3, PurchaseTypeName = "Dealer Finance"}
        };

        public List<PurchaseType> GetAll()
        {
            return _purchaseTypes;
        }
    }
}
