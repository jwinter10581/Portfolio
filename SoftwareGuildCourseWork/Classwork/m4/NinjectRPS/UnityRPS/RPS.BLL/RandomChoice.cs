using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    public class RandomChoice : IChoiceGetter
    {
        private Random _rng = new Random();
        public Choice GetChoice()
        {
            return (Choice)_rng.Next(1, 4);
        }
    }
}
