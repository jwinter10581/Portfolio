using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public static class EmployeeRepositoryFactory
    {
        public static IEmployeeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Prod":
                    return new EmployeeRepositoryADO();
                case "QA":
                    return new EmployeeRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
