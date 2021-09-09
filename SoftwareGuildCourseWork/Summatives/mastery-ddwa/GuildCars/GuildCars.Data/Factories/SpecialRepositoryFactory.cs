﻿using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public static class SpecialRepositoryFactory
    {
        public static ISpecialRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "Prod":
                    return new SpecialRepositoryADO();
                case "QA":
                    return new SpecialRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
