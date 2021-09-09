using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadManager.Models;

namespace BreadManager.View
{
    public class UserInputValidation
    {
        public bool ReadBool(string prompt)
        {
            string userInput = "", lowerInput = "";
            bool leavened = false;

            while (userInput == "")
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();
                lowerInput = userInput.ToLower();

                if (lowerInput == "yes" || lowerInput == "y")
                {
                    leavened = true;
                }
                else if (lowerInput == "no" || lowerInput == "n")
                {
                    leavened = false;
                }
                else
                {
                    Console.WriteLine("That input wasn't valid, please enter yes or no.");
                    userInput = "";
                }
            }
            return leavened;
        }

        public string ReadString(string prompt)
        {
            string userInput = "";

            while (userInput == "")
            {
                Console.WriteLine(prompt);

                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That input wasn't valid, please try again.");
                }
            }

            return userInput;
        }

        public int ReadInt(string prompt, int min, int max) 
        {
            int output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
                    {
                        break; // valid input, successfully parsed
                    }
                    else
                    {
                        Console.WriteLine($"That number was not between {min} and {max}.  Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input.  Please enter a number and try again.");
                }
            }
            return output;
        }

        public BreadType ReadEnum(string prompt, int min, int max)
        {
            BreadType breadType = BreadType.Unavailable;

            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (Enum.TryParse(userInput, out breadType))
                {
                    switch (breadType)
                    {
                        case BreadType.Baguette:
                            return BreadType.Baguette;
                        case BreadType.Brioche:
                            return BreadType.Brioche;
                        case BreadType.Challah:
                            return BreadType.Challah;
                        case BreadType.Ciabatta:
                            return BreadType.Ciabatta;
                        case BreadType.Cornbread:
                            return BreadType.Cornbread;
                        case BreadType.Pita:
                            return BreadType.Pita;
                        case BreadType.Pumpernickel:
                            return BreadType.Pumpernickel;
                        case BreadType.Rye:
                            return BreadType.Rye;
                        case BreadType.Sourdough:
                            return BreadType.Sourdough;
                        case BreadType.White:
                            return BreadType.White;
                        default:
                            breadType = BreadType.Unavailable;
                            break;
                    }
                }
                if (breadType == BreadType.Unavailable)
                {
                    Console.WriteLine("That wasn't a valid type of bread, please re-enter your choice.");
                    Console.WriteLine($"Bread may be chosen by number ({min} - {max}) or by name.");
                }
            } while (breadType == BreadType.Unavailable);

            return breadType;
        }

        public BreadType ReadEnum(string choice) // for Unit Test
        {
            BreadType breadType = BreadType.Unavailable;

            do
            {
                if (Enum.TryParse(choice, out breadType))
                {
                    switch (breadType)
                    {
                        case BreadType.Baguette:
                            return BreadType.Baguette;
                        case BreadType.Brioche:
                            return BreadType.Brioche;
                        case BreadType.Challah:
                            return BreadType.Challah;
                        case BreadType.Ciabatta:
                            return BreadType.Ciabatta;
                        case BreadType.Cornbread:
                            return BreadType.Cornbread;
                        case BreadType.Pita:
                            return BreadType.Pita;
                        case BreadType.Pumpernickel:
                            return BreadType.Pumpernickel;
                        case BreadType.Rye:
                            return BreadType.Rye;
                        case BreadType.Sourdough:
                            return BreadType.Sourdough;
                        case BreadType.White:
                            return BreadType.White;
                        default:
                            breadType = BreadType.Unavailable;
                            break;
                    }
                }
            } while (breadType == BreadType.Unavailable);

            return breadType;
        }
    }
}
