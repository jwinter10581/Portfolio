using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class BodyStyleRepositoryMock : IBodyStyleRepository
    {
        private static List<BodyStyle> _bodyStyles = new List<BodyStyle>
        {
            new BodyStyle
            {BodyStyleId = 1, BodyStyleType = "Car" },            
            new BodyStyle
            {BodyStyleId = 2, BodyStyleType = "SUV" },            
            new BodyStyle
            {BodyStyleId = 3, BodyStyleType = "Truck" },            
            new BodyStyle
            {BodyStyleId = 4, BodyStyleType = "Van" }
        };

        public List<BodyStyle> GetAll()
        {
            return _bodyStyles;
        }
    }
}
