<<<<<<< Updated upstream
﻿using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            Random computerRng = new Random();

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            while (keepPlaying)
            {
                int roundsToPlay = 0, computerChoice,
                    playerScore = 0, computerScore = 0, tie = 0;
                int? playerChoice; // needs to be nullable for PlayerInput method
                string playAgain = "";

                Console.Write("\nHow many rounds would you like to play? Please choose between (1-10): ");

                while (!int.TryParse(Console.ReadLine(), out roundsToPlay))
                {
                    Console.Write("Please enter a number between (1-10): ");
                }

                if (roundsToPlay > 10 || roundsToPlay < 1)
                {
                    Console.WriteLine("I'm sorry, that was an invalid input.  Goodbye.");
                    break;
                }

                for (int p = 1; p <= roundsToPlay; p++)
                {
                    Console.Write("Please enter 1 = Rock, 2 = Paper, 3 = Scissors : ");
                   
                    do
                    {
                        playerChoice = PlayerInput(Console.ReadLine());
                        if (playerChoice == null)
                        {
                            Console.WriteLine("That was not a valid input.  Try again.");
                            Console.Write("Please enter 1 = Rock, 2 = Paper, 3 = Scissors : ");
                        }
                    } while (playerChoice == null);

                    computerChoice = computerRng.Next(1, 4);

                    if (playerChoice == computerChoice)
                    {
                        Console.WriteLine("We both chose the same, tie! ");
                        tie++;
                    }
                    else if (playerChoice == 1 && computerChoice == 3)
                    {
                        Console.WriteLine("Your rock beats my scissors, darn.");
                        playerScore++;
                    }
                    else if (playerChoice == 2 && computerChoice == 1)
                    {
                        Console.WriteLine("Your paper beats my rock. Oof.");
                        playerScore++;
                    }
                    else if (playerChoice == 3 && computerChoice == 2)
                    {
                        Console.WriteLine("Your scissors shreds my paper, drats.");
                        playerScore++;
                    }
                    else if (playerChoice == 1 && computerChoice == 2)
                    {
                        Console.WriteLine("Hah, I've covered your rock with my paper.  Gotcha!");
                        computerScore++;
                    }
                    else if (playerChoice == 2 && computerChoice == 3)
                    {
                        Console.WriteLine("Looks like I've cut your paper with my scissors. Snip snip!");
                        computerScore++;
                    }
                    else if (playerChoice == 3 && computerChoice == 1)
                    {
                        Console.WriteLine("Crunch! My rock destroys your scissors!");
                        computerScore++;
                    }
                }

                Console.WriteLine("That was a good game!  Let's check the results...");
                Console.WriteLine($"You won {playerScore}.");
                Console.WriteLine($"The computer won {computerScore}.");
                Console.WriteLine($"We tied {tie}.");
                
                if (playerScore > computerScore)
                {
                    Console.WriteLine("Congrats player! You won!");
                }
                else if(computerScore > playerScore)
                {
                    Console.WriteLine("Oh man, the computer won!  Better luck next time.");
                }
                else
                {
                    Console.WriteLine("Looks like a draw, well.  You win some and lose the same I guess?");
                }

                Console.Write("Would you like to play again? (yes/no): ");

                while(true)
                {
                    playAgain = Console.ReadLine();
                    
                    if (playAgain == "yes")
                    {
                        Console.WriteLine("Great, that sounds super fun!");
                        break;
                    }
                    else if (playAgain == "no")
                    {
                        Console.WriteLine("Oh okay, well lets call it a day here then.");
                        keepPlaying = false;
                        break;
                    }
                    else
                    {
                        Console.Write("Did you mean to enter yes or no?  Please choose one of those two please: ");
                    }
                }
            }
        }

        public static int? PlayerInput (string input) // ? on int to allow it to be nullable
        {
            int playerChoice; // This doesn't need to be the same as in the main method.
            bool choiceSuccess;

            if (input == null)
            {
                return null;
            }
            choiceSuccess = int.TryParse(input, out playerChoice);
            if (!choiceSuccess)
            {
                return null;
            }
            if (playerChoice < 1)
            {
                return null;
            }
            if (playerChoice > 3)
            {
                return null;
            }
            return playerChoice;
        }
    }
}
=======
﻿using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            Random computerRng = new Random();

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            while (keepPlaying)
            {
                int roundsToPlay = 0, computerChoice,
                    playerScore = 0, computerScore = 0, tie = 0;
                int? playerChoice; // needs to be nullable for PlayerInput method
                string playAgain = "";

                Console.Write("\nHow many rounds would you like to play? Please choose between (1-10): ");

                while (!int.TryParse(Console.ReadLine(), out roundsToPlay))
                {
                    Console.Write("Please enter a number between (1-10): ");
                }

                if (roundsToPlay > 10 || roundsToPlay < 1)
                {
                    Console.WriteLine("I'm sorry, that was an invalid input.  Goodbye.");
                    break;
                }

                for (int p = 1; p <= roundsToPlay; p++)
                {
                    Console.Write("Please enter 1 = Rock, 2 = Paper, 3 = Scissors : ");
                   
                    do
                    {
                        playerChoice = PlayerInput(Console.ReadLine());
                        if (playerChoice == null)
                        {
                            Console.WriteLine("That was not a valid input.  Try again.");
                            Console.Write("Please enter 1 = Rock, 2 = Paper, 3 = Scissors : ");
                        }
                    } while (playerChoice == null);

                    computerChoice = computerRng.Next(1, 4);

                    if (playerChoice == computerChoice)
                    {
                        Console.WriteLine("We both chose the same, tie! ");
                        tie++;
                    }
                    else if (playerChoice == 1 && computerChoice == 3)
                    {
                        Console.WriteLine("Your rock beats my scissors, darn.");
                        playerScore++;
                    }
                    else if (playerChoice == 2 && computerChoice == 1)
                    {
                        Console.WriteLine("Your paper beats my rock. Oof.");
                        playerScore++;
                    }
                    else if (playerChoice == 3 && computerChoice == 2)
                    {
                        Console.WriteLine("Your scissors shreds my paper, drats.");
                        playerScore++;
                    }
                    else if (playerChoice == 1 && computerChoice == 2)
                    {
                        Console.WriteLine("Hah, I've covered your rock with my paper.  Gotcha!");
                        computerScore++;
                    }
                    else if (playerChoice == 2 && computerChoice == 3)
                    {
                        Console.WriteLine("Looks like I've cut your paper with my scissors. Snip snip!");
                        computerScore++;
                    }
                    else if (playerChoice == 3 && computerChoice == 1)
                    {
                        Console.WriteLine("Crunch! My rock destroys your scissors!");
                        computerScore++;
                    }
                }

                Console.WriteLine("That was a good game!  Let's check the results...");
                Console.WriteLine($"You won {playerScore}.");
                Console.WriteLine($"The computer won {computerScore}.");
                Console.WriteLine($"We tied {tie}.");
                
                if (playerScore > computerScore)
                {
                    Console.WriteLine("Congrats player! You won!");
                }
                else if(computerScore > playerScore)
                {
                    Console.WriteLine("Oh man, the computer won!  Better luck next time.");
                }
                else
                {
                    Console.WriteLine("Looks like a draw, well.  You win some and lose the same I guess?");
                }

                Console.Write("Would you like to play again? (yes/no): ");

                while(true)
                {
                    playAgain = Console.ReadLine();
                    
                    if (playAgain == "yes")
                    {
                        Console.WriteLine("Great, that sounds super fun!");
                        break;
                    }
                    else if (playAgain == "no")
                    {
                        Console.WriteLine("Oh okay, well lets call it a day here then.");
                        keepPlaying = false;
                        break;
                    }
                    else
                    {
                        Console.Write("Did you mean to enter yes or no?  Please choose one of those two please: ");
                    }
                }
            }
        }

        public static int? PlayerInput (string input) // ? on int to allow it to be nullable
        {
            int playerChoice; // This doesn't need to be the same as in the main method.
            bool choiceSuccess;

            if (input == null)
            {
                return null;
            }
            choiceSuccess = int.TryParse(input, out playerChoice);
            if (!choiceSuccess)
            {
                return null;
            }
            if (playerChoice < 1)
            {
                return null;
            }
            if (playerChoice > 3)
            {
                return null;
            }
            return playerChoice;
        }
    }
}
>>>>>>> Stashed changes
