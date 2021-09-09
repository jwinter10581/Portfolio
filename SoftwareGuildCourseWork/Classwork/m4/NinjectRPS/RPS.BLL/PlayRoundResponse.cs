using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    public class PlayRoundResponse
    {
        public Choice Player1Choice { get; set; }
        public Choice Player2Choice { get; set; }
        public GameResult Player1Result { get; set; }
    }
}
