using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadManager.Models;

namespace BreadManager.View
{
    public class BreadView
    {
        private UserInputValidation userIV;

        public BreadView() // create a user input validation object in constructor to be used in other methods
        {
            userIV = new UserInputValidation();
        }

        public int ShowMenuAndGetChoice()
        {
            Console.WriteLine("\nEnter a choice from the menu below:");
            Console.WriteLine("1. Add a loaf of bread");
            Console.WriteLine("2. Show all loaves of bread");
            Console.WriteLine("3. Look at a loaf of bread");
            Console.WriteLine("4. Modify a loaf of bread");
            Console.WriteLine("5. Throw away a loaf of bread");
            Console.WriteLine("6. View eligible bread types");
            Console.WriteLine("7. Exit Program");

            int userChoice = userIV.ReadInt("Enter your choice: ", 1, 7);

            return userChoice;
        }

        public Bread GetFreshBreadInformation()
        {
            Bread bread = new Bread();

            bread.BreadType = userIV.ReadEnum("\nWhat kind of bread is it? Please enter number between 1-10 or the kind of bread.", 1, 10);
            bread.Origin = userIV.ReadString("Where is the bread originally from? ");
            bread.Leavened = userIV.ReadBool("Does the bread contain baking yeast, baking powder, or baking soda? (y/n)");
            bread.ShelfLife = userIV.ReadInt("How long is the shelf life in days? ", 1, 365);  // Most breads don't last more than a month, so a year should cover most loaves.

            return bread;
        }

        public void PerceiveBread(Bread bread)
        {
            Console.WriteLine($"\nBread ID:          {bread.BreadID}");
            Console.WriteLine($"Bread Type:        {bread.BreadType}");
            Console.WriteLine($"Bread Origin:      {bread.Origin}");
            Console.WriteLine($"Bread Leavened:    {bread.Leavened}");
            Console.WriteLine($"Bread Shelf Life:  {bread.ShelfLife}");
        }

        public void DisplayEligibleBreadTypes()
        {
            Console.WriteLine("\nHere is a list of all of the available types of bread.");

            BreadType[] breadArray = Enum.GetValues(typeof(BreadType)).Cast<BreadType>().ToArray();

            for (int b = 1; b < breadArray.Length; b++)
            {
                Console.WriteLine($"{b}. {breadArray[b]}");
            }
        }

        public void ShowSuccess (string actionName)
        {
            Console.WriteLine($"\n{actionName} was a success!");
        }

        public void ShowFailure (string actionName)
        {
            Console.WriteLine($"\n{actionName} did not succeed.");
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the kitchen, we're making bread today!");
            Console.WriteLine("I only have space for 10 loaves, but feel free to bake as many as you'd like.");
        }
    }
}
