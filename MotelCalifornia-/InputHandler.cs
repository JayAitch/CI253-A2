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
        public void GetInput()
        {
            Boolean finished = false; // Game state 'finished' is intially set to false
            while (!finished) // While the game is still playing...
            {
                Console.Write("Command:  "); // Print the following line
                Command command = parser.GetCommand(); // Waits to receive input from user
                finished = ProcessCommand(command); // Calls the following method using the user's input
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
                return false; // Return true
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
                    PrintNoCommandText();
                }
            }
            if (c.CommandWord == "quit") // if command word == quit
            {
                g.QuitGame();
                return true;
            }
            if (c.CommandWord == "clear") // if command word == clear
            {
                Console.Clear();
            }
            if (c.CommandWord == "engine") // if command word == engine
            {
                if (c.SecondWord == "report")
                {
                    
                }
                if (c.SecondWord == "recall")
                {
                    
                }
                if (c.SecondWord == "refill")
                {

                }
                if (c.SecondWord == "goto")
                {

                }
                else
                {
                    PrintNoCommandText();
                }
            }
                return false; // Else return false
        }

    }
}
