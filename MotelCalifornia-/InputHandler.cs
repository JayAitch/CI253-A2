﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class InputHandler
    {
        private Game gameRef;
        private Parser parser = new Parser(); // Initializes the parser
        public InputHandler(Game g)
        {
            gameRef = g;
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

        // Checks command input of first word
        private Boolean ProcessCommand(Command c)
        {
            if (c.IsUnknown) // If the command input by the user is unknown...
            {
                Console.WriteLine("Command not recognised"); // Print the following line
                return false; // Return true
            }
            if(c.CommandWord == "room") // if command word == room...
            {
                if(c.SecondWord == "list")
                {
                    gameRef.CheckRooms();
                }
            }
            if (c.CommandWord == "quit") // if command word == quit
            {

            }
            if (c.CommandWord == "clear") // if command word == clear
            {

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
            }
                return false; // Else return false
        }

    }
}
