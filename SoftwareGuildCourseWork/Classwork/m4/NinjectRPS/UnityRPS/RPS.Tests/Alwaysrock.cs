using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Tests
{
    public class AlwaysRock : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Rock;
        }
    }
}
