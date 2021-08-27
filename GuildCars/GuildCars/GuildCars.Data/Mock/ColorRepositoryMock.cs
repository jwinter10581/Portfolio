using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ColorRepositoryMock : IColorRepository
    {
        private static List<Color> _colors = new List<Color>
        {
            new Color
            {ColorId = 1, ColorName = "White"},
            new Color
            {ColorId = 2, ColorName = "Black"},
            new Color
            {ColorId = 3, ColorName = "Grey"},
            new Color
            {ColorId = 4, ColorName = "Red"},
            new Color
            {ColorId = 5, ColorName = "Yellow"},
            new Color
            {ColorId = 6, ColorName = "Blue"}
        };

        public List<Color> GetAll()
        {
            return _colors;
        }
    }
}
