using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class SpecialRepositoryMock : ISpecialRepository
    {
        private static List<Special> _specials = new List<Special>
        {
            new Special
            { SpecialId = 1, Title = "Special Title 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." },
            new Special
            { SpecialId = 2, Title = "Special Title 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." },
            new Special
            { SpecialId = 3, Title = "Special Title 3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." }
        };

        public static void Initialize()
        {
            _specials = new List<Special>
            {
                new Special
                { SpecialId = 1, Title = "Special Title 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." },
                new Special
                { SpecialId = 2, Title = "Special Title 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." },
                new Special
                { SpecialId = 3, Title = "Special Title 3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat." }
            };
        }

        public void Delete(int specialId)
        {
            _specials.RemoveAll(s => s.SpecialId == specialId);
        }

        public List<Special> GetAll()
        {
            return _specials;
        }

        public Special GetById(int specialId)
        {
            return _specials.FirstOrDefault(s => s.SpecialId == specialId);
        }

        public void Insert(Special newSpecial)
        {
            if (_specials.Any())
            {
                newSpecial.SpecialId = _specials.Max(s => s.SpecialId) + 1;
            }
            else
            {
                newSpecial.SpecialId = 1;
            }
            _specials.Add(newSpecial);
        }
    }
}
