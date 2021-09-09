using System;

namespace FruitSalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "Kiwi Fruit", "Gala Apple", "Granny Smith Apple",
                "Cherry Tomato", "Gooseberry", "Beefsteak Tomato", "Braeburn Apple",
                "Blueberry", "Strawberry", "Navel Orange", "Pink Pearl Apple",
                "Raspberry", "Blood Orange", "Sungold Tomato", "Fuji Apple",
                "Blackberry", "Banana", "Pineapple", "Florida Orange", "Kiku Apple",
                "Mango", "Satsuma Orange", "Watermelon", "Snozzberry" };

            string[] fruitSalad = new string[12];

            int newPosition = 0, appleCounter = 0, orangeCounter = 0, fruitCounter = 0;

            // As many berries as possible -- IsBerry method
            // No more than three kinds of apples -- IsApple method
            // No more than two kinds of orange -- IsOrange method
            // Definitely no tomatoes -- IsTomato method
            // No more than twelve kinds of fruit

            for (int i = 0; i < fruit.Length; i++)
            {
                if (fruitCounter == 12)
                {
                    break;
                }

                if (IsBerry(fruit[i]) == true)
                {
                    fruitSalad[newPosition] = fruit[i];
                    newPosition++;
                    fruitCounter++;
                }

                else if (IsApple(fruit[i]))
                {
                    if (appleCounter == 3)
                    {
                        // do nothing
                    }
                    else
                    {
                        fruitSalad[newPosition] = fruit[i];
                        newPosition++;
                        fruitCounter++;
                        appleCounter++;
                    }
                }

                else if (IsOrange(fruit[i]))
                {
                    if (orangeCounter == 2)
                    {
                        // do nothing
                    }
                    else 
                    {
                        fruitSalad[newPosition] = fruit[i];
                        newPosition++;
                        fruitCounter++;
                        orangeCounter++;
                    }
                }

                else if (IsTomato(fruit[i]) == true)
                {
                    // do nothing
                }

                else
                {
                    fruitSalad[newPosition] = fruit[i];
                    newPosition++;
                    fruitCounter++;
                }
            }

            Console.WriteLine("Hey guys, I put the salad together... It has: ");
            for (int f = 0; f < fruitSalad.Length; f++)
            {
                Console.WriteLine(fruitSalad[f]);
            }
            Console.WriteLine("Yum yum!");
        }

        static bool IsBerry(string str)
        {
            if (str.Length < 5)
            {
                return false;
            }

            if (str[str.Length - 5] == 'b' &&
                str[str.Length - 4] == 'e' &&
                str[str.Length - 3] == 'r' &&
                str[str.Length - 2] == 'r' &&
                str[str.Length - 1] == 'y')
            {
                return true;
            }

            return false;
        }

        static bool IsApple(string str)
        // I would also copnsidition a condition that if the string 
        // starts with "pine", to ignore it, but casing is okay here
        {
            if (str.Length < 5)
            {
                return false;
            }

            if (str[str.Length - 5] == 'A' &&
                str[str.Length - 4] == 'p' &&
                str[str.Length - 3] == 'p' &&
                str[str.Length - 2] == 'l' &&
                str[str.Length - 1] == 'e')
            {
                return true;
            }

            return false;
        }

        static bool IsOrange(string str)
        {
            if (str.Length < 6)
            {
                return false;
            }

            if (str[str.Length - 6] == 'O' &&
                str[str.Length - 5] == 'r' &&
                str[str.Length - 4] == 'a' &&
                str[str.Length - 3] == 'n' &&
                str[str.Length - 2] == 'g' &&
                str[str.Length - 1] == 'e')
            {
                return true;
            }

            return false;
        }

        static bool IsTomato(string str)
        {
            if (str.Length < 6)
            {
                return false;
            }

            if (str[str.Length - 6] == 'T' &&
                str[str.Length - 5] == 'o' &&
                str[str.Length - 4] == 'm' &&
                str[str.Length - 3] == 'a' &&
                str[str.Length - 2] == 't' &&
                str[str.Length - 1] == 'o')
            {
                return true;
            }

            return false;
        }


    }
}


