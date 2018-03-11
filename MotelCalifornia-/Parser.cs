using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Parser
    {
        public Command GetCommand()
        {
            // take input and split on space or new line
            string inputLine = "";
            inputLine = Console.ReadLine();
            String[] values = inputLine.Split(' ', '\n');

            // test up to 4 words in the array formed
            if (CommandWords.IsCommand(values[0]))
            {
                if (values.Count() == 1)
                {
                    return new Command { CommandWord = values[0], SecondWord = null, ThirdWord = null, FourthWord = null };
                }
                else if (values.Count() == 2)
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = null, FourthWord = null };
                }
                else if (values.Count() == 3)
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = null };
                }
                else if (values.Count() == 4)
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = values[3] };
                }                
            }
            return new Command();
        }
    }
}
