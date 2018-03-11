using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class CommandWords
    {
        // array of valid command words
        private static String[] validCommands = { "quit", "help", "room", "clear", "engine" };
        public String[] ValidCommands { get { return validCommands; } }

        // test string from input against valid words
        public static Boolean IsCommand(String command)
        {
            if (validCommands.Contains(command))
                return true;
            return false;
        }
    }
}
