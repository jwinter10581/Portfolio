using System;

namespace BattleShip.BLL.Requests
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == this.XCoordinate &&
                   otherCoordinate.YCoordinate == this.YCoordinate;
        }
		
		public override int GetHashCode() 
        { 
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00"; 
            return (Convert.ToInt32(uniqueHash)); 
        }

        // ===================================================================================================================================
        // Everything above here was in the class before I started.  I've added the methods below to prompt, validate, and return user input. 
        // ===================================================================================================================================

        public Coordinate AcquireCoordinateFromUser()
        {
            string input, valid;
            int xCoordinate, yCoordinate;
            do
            {
                input = PromptCoordinate();
                valid = ValidateCoordinate(input);
            } while (valid == null);

            xCoordinate = Int32.Parse(valid.Substring(0, 1)) + 1;
            yCoordinate = Int32.Parse(valid.Substring(1));

            Coordinate coordinate = new Coordinate(xCoordinate, yCoordinate);

            return coordinate;
        }

        public Coordinate AcquireCoordinateFromUser(string input)  // overloaded for unit testing
        {
            string valid;
            int xCoordinate, yCoordinate;
            do
            {
                valid = ValidateCoordinate(input);
            } while (valid == null);

            xCoordinate = Int32.Parse(valid.Substring(0, 1)) + 1;
            yCoordinate = Int32.Parse(valid.Substring(1));

            Coordinate coordinate = new Coordinate(xCoordinate, yCoordinate);

            return coordinate;
        }

        private string PromptCoordinate()
        {
            string coordinateInput = "";

            do
            {
                coordinateInput = Console.ReadLine();

                if (coordinateInput.Length < 2 || coordinateInput.Length > 3)
                {
                    Console.WriteLine("That was not a valid input, please enter a letter (a - j) followed by a number (1-10)");
                    coordinateInput = "";
                }
            } while (coordinateInput == "");

            return coordinateInput;
        }

        private string ValidateCoordinate(string coordinateInput)
        {
            bool legitCoordinate = true;
            string coordinateConverted = coordinateInput.ToLower();

            string xAxis = coordinateConverted.Substring(0, 1);

            switch (xAxis)
            {
                case "a":
                    xAxis = "0";
                    break;
                case "b":
                    xAxis = "1";
                    break;
                case "c":
                    xAxis = "2";
                    break;
                case "d":
                    xAxis = "3";
                    break;
                case "e":
                    xAxis = "4";
                    break;
                case "f":
                    xAxis = "5";
                    break;
                case "g":
                    xAxis = "6";
                    break;
                case "h":
                    xAxis = "7";
                    break;
                case "i":
                    xAxis = "8";
                    break;
                case "j":
                    xAxis = "9";
                    break;
                default:
                    legitCoordinate = false;
                    break;
            }

            string yAxis = coordinateConverted.Substring(1);
            Int32.TryParse(yAxis, out int yNumber);

            if (yNumber < 1 || yNumber > 10)
            {
                legitCoordinate = false;
            }

            if (legitCoordinate)
            {
                string coordinateFinal = xAxis + yAxis;
                return coordinateFinal;
            }

            else
            {
                return null;
            }
        }
    }
}
