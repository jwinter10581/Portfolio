using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
        Special GetById(int specialId);
        void Insert(Special newSpecial);
        void Delete(int specialId);
    }
}
