using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private static List<Make> _makes = new List<Make>
        {
            new Make
            { MakeId = 1, MakeName = "Kia", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 1, EmployeeEmail = "admin@guildcars.com" },            
            new Make
            { MakeId = 2, MakeName = "Mazda", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 1, EmployeeEmail = "admin@guildcars.com" },            
            new Make
            { MakeId = 3, MakeName = "Audi", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },            
            new Make
            { MakeId = 4, MakeName = "Subaru", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },            
            new Make
            { MakeId = 5, MakeName = "Volkswagen", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" }
        };

        public static void Initialize()
        {
            _makes = new List<Make>
            {
                new Make
                { MakeId = 1, MakeName = "Kia", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 1, EmployeeEmail = "admin@guildcars.com" },
                new Make
                { MakeId = 2, MakeName = "Mazda", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 1, EmployeeEmail = "admin@guildcars.com" },
                new Make
                { MakeId = 3, MakeName = "Audi", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Make
                { MakeId = 4, MakeName = "Subaru", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Make
                { MakeId = 5, MakeName = "Volkswagen", DateAdded = new DateTime(2021, 7, 22), EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" }
            };
        }

        public List<Make> GetAll()
        {
            return _makes;
        }

        public Make GetById(int makeId)
        {
            return _makes.FirstOrDefault(m => m.MakeId == makeId);
        }

        public void Insert(Make newMake)
        {
            if (_makes.Any())
            {
                newMake.MakeId = _makes.Max(m => m.MakeId) + 1;
            }
            else
            {
                newMake.MakeId = 1;
            }
            newMake.DateAdded = DateTime.Today;
            _makes.Add(newMake);
        }
    }
}
