using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class InputHandler
    {
        private Game g;
        private Parser parser = new Parser(); // Initializes the parser

        public InputHandler(Game g)
        {           
            this.g = g;
        }
            
        // Get input from command line and parse into a command
        public void GetUserInput()
        {
            bool IsCommand = false;
            while (g.IsPlaying) // If parser is still waiting for command
            {

                    Console.Write("Command:  "); // Print the following line
                    Command command = parser.GetCommand(); // Waits to receive input from user
                    IsCommand = ProcessCommand(command); // Calls the following method using the user's input

            }

            if (!g.IsPlaying)
            {
                g.QuitGame();
                Console.WriteLine("\nPress enter to quit.");
                Console.ReadKey();
            }
        }



        private void PrintNoCommandText()
        {
            Console.WriteLine("Command not recognised");
        }


        // Checks command input of first word
        private Boolean ProcessCommand(Command c)
        {
            if (c.IsUnknown) // If the command input by the user is unknown...
            {
                PrintNoCommandText(); // Print the following line
                return false; // Continue waiting for command
            }
            if(c.CommandWord == "room") // If command word == room...
            {
                if(c.SecondWord == "list") // If second command word == list...
                {
                    g.CheckRooms(); // Check room states and display
                    return true;
                }
                else if(c.SecondWord == "report") // If second command word == report...
                {

                    g.ReportRooms(); // Count the different room states and display
                    return true;
                }
                else
                {
                    Console.WriteLine("\nRoom command not recognised: please use list or report\n");
                }
            }
            else if (c.CommandWord == "quit") // If command word == quit...
            {
                g.QuitGame(); // Quit the game
                return true;
            }
            else if (c.CommandWord == "clear") // If command word == clear...
            {
                Console.Clear(); // Clear the screen
                return true;
            }

            else if (c.CommandWord == "engine") // If command word == engine...
            {
                if (c.SecondWord == "report") // If second command word == report...
                {
                    g.GetEngineReport(); // Get engine ID, current coolant level and engine status
                    return true;
                }
                else if (c.SecondWord == "recall") // If second command word == recall...
                {
                    g.SendEngineToStation(); // Return engine to station
                    return true;
                }
                else if (c.SecondWord == "refill") // If second command word == refill...
                {
                    g.RefillEngine(); // Replenish engine coolant levels
                    return true;
                }
                else if (c.SecondWord == "goto") // If second command word == goto...
                {
                    // Try to parse entered string 
                    int roomToGo;
                    if(Int32.TryParse(c.ThirdWord, out roomToGo))
                    {
                        if(roomToGo > 0 && roomToGo <= Constants.MAX_NBR_ROOMS) // If room number is possible
                        {
                            g.SendEngineToRoom(roomToGo - 1); // Send the engine to the specified room
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter a room number between 1 and {0}\n", Constants.MAX_NBR_ROOMS);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Room number needs to be a integer");
                        return false;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Engine command not recognised: please use goto, refill, recall or report");
                    return false;
                }
                
            }
                return false; // Else return false
        }

    }
}
