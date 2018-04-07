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
        public Boolean isGameFinished;
        // public 
        public InputHandler(Game g)
        {
            isGameFinished = false;
            this.g = g;
        }
            
        // Get input from command line and parse into a command
        public void GetInput()
        {
            while (!isGameFinished) // If parser is still waiting for command
            {
                Console.Write("Command:  "); // Print the following line
                Command command = parser.GetCommand(); // Waits to receive input from user
                isGameFinished = ProcessCommand(command); // Calls the following method using the user's input
                if (g.IsCheckGameEnd())
                {
                    FinishGame();
                }
            }

            if (isGameFinished)
            {
                g.QuitGame();
                Console.WriteLine("Press enter to quit.");
                Console.ReadKey();
            }
        }


        public void FinishGame()
        {
            isGameFinished = true;
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
                return false; // continue waiting for command
            }
            if(c.CommandWord == "room") // if command word == room...
            {
                if(c.SecondWord == "list")
                {
                    g.CheckRooms();
                }
                else if(c.SecondWord == "report")
                {
                    g.ReportRooms();
                }
                else
                {
                    Console.WriteLine("room command not recognised: please use list or report");
                }
            }
            else if (c.CommandWord == "quit") // if command word == quit
            {
                g.QuitGame();
                return true;
            }
            else if (c.CommandWord == "clear") // if command word == clear
            {
                Console.Clear();
            }

            else if (c.CommandWord == "engine") // if command word == engine
            {
                if (c.SecondWord == "report")
                {
                    g.GetEngineReport();
                }
                else if (c.SecondWord == "recall")
                {
                    g.SendEngineToStation();
                }
                else if (c.SecondWord == "refill")
                {
                    g.RefillEngine();
                }
                else if (c.SecondWord == "goto")
                {
                    // try to parse entered string 
                    int roomToGo;
                    if(Int32.TryParse(c.ThirdWord, out roomToGo))
                    {
                        if(roomToGo > 0 && roomToGo <= Constants.MAX_NBR_ROOMS) //if room numer possible
                        {
                            g.SendEngineToRoom(roomToGo - 1); //dispatch command
                        }
                        else
                        {
                            Console.WriteLine("please enter a room number between 1 and {0}", Constants.MAX_NBR_ROOMS);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Room number needs to be a integer");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Engine command not recognised: please use goto, refill, recall or report");
                }
                
            }
                return false; // Else return false
        }

    }
}
