using System;
using System.Linq;


namespace MotelCalifornia
{
    class Parser
    {
        public Command GetCommand()
        {
            // Take input and split on space or new line
            string inputLine = ""; 
            inputLine = Console.ReadLine().ToLower(); // lower case to reduce typing errors
            String[] values = inputLine.Split(' ', '\n');

            // Test up to 4 words in the array formed
            if (CommandWords.IsCommand(values[0]))
            {
                if (values.Count() == 1) // If user input is equal to 1 word...
                {
                    return new Command { CommandWord = values[0], SecondWord = null, ThirdWord = null, FourthWord = null }; // Return CommandWord array
                }
                else if (values.Count() == 2) // If user input is equal to 2 words...
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = null, FourthWord = null }; // Return CommandWord, SecondWord array 
                }
                else if (values.Count() == 3) // If user input is equal to 3 words...
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = null }; // Return CommandWord, SecondWord, ThirdWord array
                }
                else if (values.Count() == 4) // If user input is equal to 4 words...
                {
                    return new Command { CommandWord = values[0], SecondWord = values[1], ThirdWord = values[2], FourthWord = values[3] }; // Return CommandWord, SecondWord, ThirdWord, FourthWord array
                }                
            }
            return new Command(); // Return the command input by user
        }
    }
}
