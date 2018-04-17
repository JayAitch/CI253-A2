using System;
using System.Linq;
using System.Collections.Generic;

namespace MotelCalifornia
{
    class CommandWords
    {
        // Array of valid command words. Any other string input by the player will return an invalid input response
        private static String[] validCommands = { "quit", "help", "room", "clear", "engine" };
        public String[] ValidCommands { get { return validCommands; } }
        // Concidered using dictionary to store second and third words but resolution inside InputHandler was overly verbose
        // Test string from input against valid words
        public static Boolean IsCommand(String command)
        {
            if (validCommands.Contains(command)) // If the command input is one of the commands stated in 'validCommands'...
                return true; // Return true
            return false; // Else return false
        }
    }
}
