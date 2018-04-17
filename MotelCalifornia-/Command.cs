using System;


namespace MotelCalifornia
{
    class Command
    {
        // Command words class wrapper. Used by the player to input commands
        public String CommandWord { get; set; } // First word command
        public String SecondWord { get; set; } // Second word command
        public String ThirdWord { get; set; } // Third word command
        public String FourthWord { get; set; } // Fourth word command

        // Used to return an invalid command response
        public Boolean IsUnknown { get { return (CommandWord == null); } }
    }
}
