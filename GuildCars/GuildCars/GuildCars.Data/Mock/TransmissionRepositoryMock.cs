using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class TransmissionRepositoryMock : ITransmissionRepository
    {
        private static List<Transmission> _transmissions = new List<Transmission>
        {
            new Transmission
            { TransmissionId = 1, TransmissionType = "Automatic" },
            new Transmission
            { TransmissionId = 2, TransmissionType = "Manual" }
        };

        public List<Transmission> GetAll()
        {
            return _transmissions;
        }
    }
}
