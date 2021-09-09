using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    public class GameManager2
    {
        [Inject]
        public IChoiceGetter ChoiceBehavior { get; set; }

        public PlayRoundResponse PlayRound(Choice player1Choice)
        {
            PlayRoundResponse response = new PlayRoundResponse();
            response.Player1Choice = player1Choice;
            response.Player2Choice = ChoiceBehavior.GetChoice();

            // Tie?
            if (response.Player1Choice == response.Player2Choice)
            {
                response.Player1Result = GameResult.Tie;
                return response;
            }

            // Player 1 wins?
            if (response.Player1Choice == Choice.Rock &&
                    response.Player2Choice == Choice.Scissors || 
                response.Player1Choice == Choice.Scissors && 
                    response.Player2Choice == Choice.Paper || 
                response.Player1Choice == Choice.Paper && 
                    response.Player2Choice == Choice.Rock)
            {
                response.Player1Result = GameResult.Win;
                return response;
            }

            // otherwise loss
            response.Player1Result = GameResult.Loss;
            return response;
        }
    }
}
