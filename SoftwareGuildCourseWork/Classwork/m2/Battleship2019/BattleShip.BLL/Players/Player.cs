using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Players
{
    public class Player
    {
        private string _name;

        public int playerID;

        public int initiative;

        public bool first = false;

        public string Name
        {
            get { return _name; } set { }
        }
    }
}
