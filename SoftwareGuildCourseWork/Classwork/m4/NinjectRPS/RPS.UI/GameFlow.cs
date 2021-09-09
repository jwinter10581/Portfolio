using Ninject;
using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI
{
    public class GameFlow
    {
        public void Start()
        {
            Choice player1Choice;
            GameManager gm = DIContainer.Kernel.Get<GameManager>();

            while(true)
            {
                Console.Clear();
                player1Choice = ConsoleInput.GetChoiceFromUser();
                PlayRoundResponse response = gm.PlayRound(player1Choice);

                ConsoleOutput.DisplayResult(response);

                if (!ConsoleInput.QueryPlayAgain())
                    return;
            }
        }
        
    }
}
