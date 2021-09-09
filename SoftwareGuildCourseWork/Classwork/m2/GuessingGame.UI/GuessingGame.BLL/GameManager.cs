using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    public class GameManager
    {
        public const int MinimumGuess = 1;
        public const int MaximumGuess = 20;

        private int _answer;

        private bool isValidGuess(int guess)
        {
            return (MinimumGuess <= guess && guess <= MaximumGuess);
        }

        private void CreateRandomAnswer()
        {
            Random rng = new Random();
            _answer = rng.Next(MinimumGuess, MaximumGuess + 1);
        }

        public GuessResult ProcessGuess(int guess)
        {
            GuessResult guessResult = GuessResult.Invalid;

            if (isValidGuess(guess))
            {
                if (guess < _answer)
                {
                    guessResult = GuessResult.Higher;
                }
                else if (guess > _answer)
                {
                    guessResult = GuessResult.Lower;
                }
                else
                {
                    guessResult = GuessResult.Victory;
                }
            }           
            
            return guessResult; // Good practice to have a single exit point            
        }

        public void Start()
        {
            CreateRandomAnswer();
        }

        public void Start(int answer) // overloaded to allow for unit testing
        {
            _answer = answer; // Save the answer to our field
        }
    }
}
