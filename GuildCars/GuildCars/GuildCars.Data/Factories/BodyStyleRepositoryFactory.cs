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
    public static class BodyStyleRepositoryFactory
    {
        public static IBodyStyleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Prod":
                    return new BodyStyleRepositoryADO();
                case "QA":
                    return new BodyStyleRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
