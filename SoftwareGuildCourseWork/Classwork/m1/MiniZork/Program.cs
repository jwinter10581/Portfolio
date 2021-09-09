using System;

namespace Minizork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are standing in an open field west of a white house,");
            Console.WriteLine("With a boarded front door.");
            Console.WriteLine("There is a small mailbox here.");
            Console.Write("Do you (Go to the house), or (open the mailbox)? ");

            String action = Console.ReadLine();

            if (action.Equals("open the mailbox"))
            {
                Console.WriteLine("You open the mailbox.");
                Console.WriteLine("It's really dark in there.");
                Console.Write("Do you (look inside) or (stick your hand in)? ");
                action = Console.ReadLine();

                if (action.Equals("look inside"))
                {
                    Console.WriteLine("You peer inside the mailbox.");
                    Console.WriteLine("It's really very dark. So ... so very dark.");
                    Console.Write("Do you (run away) or (keep looking)? ");
                    action = Console.ReadLine();

                    if (action.Equals("keep looking"))
                    {
                        Console.WriteLine("Turns out, hanging out around dark places isn't a good idea.");
                        Console.WriteLine("You've been eaten by a grue.");
                    }
                    else if (action.Equals("run away"))
                    {
                        Console.WriteLine("You run away screaming across the fields - looking very foolish.");
                        Console.WriteLine("But you're alive. Possibly a wise choice.");
                    }
                }
                else if (action.Equals("stick your hand in")) 
                {
                    Console.WriteLine("You hear a crunch and feel a sharp sensation on your hand.");
                    Console.WriteLine("You realize that it's jam-packed full of leaves.");
                    Console.WriteLine("A little weird, but hey you should probably go home and bandage your hand.");
                }
            }
            
            else if (action.Equals("go to the house")) 
            {
                Console.WriteLine("As you approach the house, the wind howls and the shutters slam against the windows.");
                Console.WriteLine("You warily creep up to the front door and open it revealing a dissaray interior.");
                Console.WriteLine("You hear noises coming from the kitchen, but also see a light upstairs.");
                Console.Write("Do you go to the (kitchen), or (upstairs)? ");
                action = Console.ReadLine();

                if (action.Equals("kitchen"))
                {
                    Console.WriteLine("You are greeted by a elderly woman baking cookies.");
                    Console.WriteLine("She turns around, cackles wildly, and flashes a sinister grin.");
                    Console.WriteLine("She shouts \"You will make an excellent addition to my cookies!\"");
                    Console.WriteLine("She chops you up and now you're part of the cookie dough.  Somehow.");
                }
                else if (action.Equals("upstairs"))
                {
                    Console.WriteLine("You quietly walk up the stairs and hear a voice from the kitchen.");
                    Console.WriteLine("\"Gerald, is that you?!\" an elderly woman cries out.  You ignore her and continue upwards.");
                    Console.WriteLine("You see a door that is cracked open and reveals what appears to be a bedroom.");
                    Console.WriteLine("You also see a door with a placard on it that says \"Susie\", presumably a child's room.");
                    Console.Write("Do you enter the (bedroom) or the room that says (susie)? ");
                    action = Console.ReadLine();

                    if (action.Equals("bedroom"))
                    {
                        Console.WriteLine("You enter the room and see an elderly man sleeping in bed.");
                        Console.WriteLine("He startles awake and yells out \"INTRUDER\".");
                        Console.WriteLine("With lightning agility, he throws a hatchet and hits you in the side.");
                        Console.WriteLine("He shouts out, \"Looks like meats back on the menu boys!\".");
                        Console.WriteLine("You are chopped up and turned into exquisite orc cuisine.");
                    }

                    else if (action.Equals("susie"))
                    {
                        Console.WriteLine("You enter the child's room tentatively, expecting something creepy.");
                        Console.WriteLine("But you are surprised to see a small child in overalls playing with some dolls.");
                        Console.WriteLine("She invites you to a tea party with her and you have a pleasant time.");
                        Console.WriteLine("The tea was over-steeped and bitter, but honestly you had fun.");
                        Console.WriteLine("And survived...");
                    }
                }
            }
        }
    }
}
