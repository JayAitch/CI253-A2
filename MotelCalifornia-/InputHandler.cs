using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class InputHandler
    {
        //own parser
        private Parser parser = new Parser();

        //get input from command line and parse into a command
        public void GetInput()
        {
            Boolean finished = false;
            while (!finished)
            {
                Console.Write("Command:  ");
                Command command = parser.GetCommand();
                finished = ProcessCommand(command);
            }
        }

        //qualify command input of first word
        private Boolean ProcessCommand(Command c)
        {
            if (c.IsUnknown)
            {
                Console.WriteLine("Command not recognised");
                return true;
            }
            
            return false;
        }
    }
}
