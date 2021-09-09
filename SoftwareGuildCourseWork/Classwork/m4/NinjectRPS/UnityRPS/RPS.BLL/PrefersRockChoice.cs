using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    public class PrefersRockChoice : IChoiceGetter
    {
        Random _rng = new Random();

        public Choice GetChoice()
        {
            int num = _rng.Next(1, 101);

            if (num > 40)
                return Choice.Rock;
            if (num > 20)
                return Choice.Paper;
            else
                return Choice.Scissors;
        }
    }
}
