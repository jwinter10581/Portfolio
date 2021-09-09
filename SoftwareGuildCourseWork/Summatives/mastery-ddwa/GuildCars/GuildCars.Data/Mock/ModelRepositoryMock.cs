using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ModelRepositoryMock : IModelRepository
    {
        private static List<Model> _models = new List<Model>
        {
            new Model
            { ModelId = 1, ModelName = "Soul", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com" },
            new Model
            { ModelId = 2, ModelName = "Sportage", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 3, ModelName = "Sorento", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 4, ModelName = "Rio", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 5, ModelName = "Carnival", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 6, ModelName = "3", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 7, ModelName = "6", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 8, ModelName = "CX-5", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 9, ModelName = "CX-9", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 10, ModelName = "BT-50", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
            new Model
            { ModelId = 11, ModelName = "Q5", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com"},
            new Model
            { ModelId = 12, ModelName = "A3", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 13, ModelName = "A6", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 14, ModelName = "R8 V10", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 15, ModelName = "Q7", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 16, ModelName = "Outback", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 17, ModelName = "Forester", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 18, ModelName = "Impreza", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 19, ModelName = "Crosstrek", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 20, ModelName = "Baja", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
            new Model
            { ModelId = 21, ModelName = "Atlas", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
            new Model
            { ModelId = 22, ModelName = "Jetta", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
            new Model
            { ModelId = 23, ModelName = "Golf", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
            new Model
            { ModelId = 24, ModelName = "Amarok", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
            new Model
            { ModelId = 25, ModelName = "Bus", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" }
        };

        public static void Initialize()
        {
            _models = new List<Model>
            {
                new Model
                { ModelId = 1, ModelName = "Soul", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com" },
                new Model
                { ModelId = 2, ModelName = "Sportage", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 3, ModelName = "Sorento", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 4, ModelName = "Rio", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 5, ModelName = "Carnival", DateAdded = new DateTime(2021, 7, 22), MakeName = "Kia", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 6, ModelName = "3", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 7, ModelName = "6", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 8, ModelName = "CX-5", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 9, ModelName = "CX-9", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 10, ModelName = "BT-50", DateAdded = new DateTime(2021, 7, 22), MakeName = "Mazda", EmployeeId = 1, EmployeeEmail= "admin@guildcars.com"  },
                new Model
                { ModelId = 11, ModelName = "Q5", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com"},
                new Model
                { ModelId = 12, ModelName = "A3", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 13, ModelName = "A6", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 14, ModelName = "R8 V10", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 15, ModelName = "Q7", DateAdded = new DateTime(2021, 7, 22), MakeName = "Audi", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 16, ModelName = "Outback", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 17, ModelName = "Forester", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 18, ModelName = "Impreza", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 19, ModelName = "Crosstrek", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 20, ModelName = "Baja", DateAdded = new DateTime(2021, 7, 22), MakeName = "Subaru", EmployeeId = 2, EmployeeEmail = "sales@guildcars.com" },
                new Model
                { ModelId = 21, ModelName = "Atlas", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
                new Model
                { ModelId = 22, ModelName = "Jetta", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
                new Model
                { ModelId = 23, ModelName = "Golf", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
                new Model
                { ModelId = 24, ModelName = "Amarok", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" },
                new Model
                { ModelId = 25, ModelName = "Bus", DateAdded = new DateTime(2021, 7, 22), MakeName = "Volkswagen", EmployeeId = 3, EmployeeEmail = "disabled@guildcars.com" }
            };
        }

        public List<Model> GetAll()
        {
            return _models;
        }

        public Model GetById(int modelId)
        {
            return _models.FirstOrDefault(m => m.ModelId == modelId);
        }

        public void Insert(Model newModel)
        {
            if (_models.Any())
            {
                newModel.ModelId = _models.Max(m => m.ModelId) + 1;
            }
            else
            {
                newModel.ModelId = 1;
            }
            newModel.DateAdded = DateTime.Today;
            _models.Add(newModel);
        }
    }
}
