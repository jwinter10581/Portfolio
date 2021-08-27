using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class InteriorRepositoryMock : IInteriorRepository
    {
        private static List<Interior> _interiors = new List<Interior>
        {
            new Interior
            {InteriorId = 1, InteriorName = "White"},
            new Interior
            {InteriorId = 2, InteriorName = "Black"},
            new Interior
            {InteriorId = 3, InteriorName = "Grey"},
            new Interior
            {InteriorId = 4, InteriorName = "Red"},
            new Interior
            {InteriorId = 5, InteriorName = "Yellow"},
            new Interior
            {InteriorId = 6, InteriorName = "Blue"}
        };

        public List<Interior> GetAll()
        {
            return _interiors;
        }
    }
}
