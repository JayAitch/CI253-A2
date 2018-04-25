using System;
using System.Threading;

namespace MotelCalifornia
{
    class Program
    {
        private static int RefreshRate = Constants.FAST_GAME_SPEED; // Sets the game speed to FAST
        static void Main(string[] args)
        {
            StartScreen();
        }

        static void StartScreen()
        {
            Game g = new Game(); // Initialize the game

            Console.WriteLine("Welcome to FATES MOTEL (although we prefer 'Motel California')\n");
            Console.WriteLine("SYNOPSIS\n");
            Console.WriteLine("Fates Motel consists of 16 rooms. The motel has always had a good reputation for being safe and secure, and that's how\nmanagement like it. However, the motel has somehow managed to spontaneously combust and the fires are starting to\nspread! It's up to you to guide the fire department and tackle the blaze before the entire motel crumbles!\n\n\n");
            Console.WriteLine("INSTRUCTIONS\n");
            Console.WriteLine("The current state of a room is designated by the following descriptors:\n");
            Console.WriteLine("SAFE = 0c to 149c\nDANGER = 150c to 299c\nSMOULDER = 300c to 599c\nFIRE = 600c to 699c\nBURNEDOUT = 700c and above\n");
            Console.WriteLine("1. At the beginning of the game, one room is randomly selected to start heating up");
            Console.WriteLine("2. Once a room reaches {0} degrees, the rooms adjacent to it will rise in temperature by {1} degrees every interval", Constants.TEMPERATURE_THRESHOLD, Constants.TEMPERATURE_INCREMENT);
            Console.WriteLine("3. The player may instruct a fire engine to douse the rooms that are heating up by {0} degrees each time", Constants.COOLANT_EMIT_PER_TICK);
            Console.WriteLine("4. If the fire engine manages to lower the room temperature below {0} degrees, it's safe from harm", Constants.TEMPERATURE_THRESHOLD);
            Console.WriteLine("5. However, if a room reaches the BURNEDOUT stage, it has crumbled and can no longer be doused");
            Console.WriteLine("6. The fire engine contains {0} litres of coolant. If you run out, you'll have to return to the station to refill!\n\n\n", Constants.COOLANT_CAPACITY);
            Console.WriteLine("COMMANDS\n");
            Console.WriteLine("The following commands will help you throughout the game. Make sure you memorize them before playing!\n");
            Console.WriteLine("ROOM\n");
            Console.WriteLine("- room list: Lists all the rooms with their current status");
            Console.WriteLine("- room report: Displays the current status of the motel i.e. how many rooms are safe/burnedout\n\n");
            Console.WriteLine("ENGINE\n");
            Console.WriteLine("- engine report: Returns engine ID, current coolant level and engine status");
            Console.WriteLine("- engine recall: Orders the engine to return to the fire station");
            Console.WriteLine("- engine refill: If stationed, the fire engine's coolant level will be replenished");
            Console.WriteLine("- engine goto roomID (example 4): The fire engine will attempt to douse the specified room\n\n");
            Console.WriteLine("EXTRA\n");
            Console.WriteLine("- clear: Clears the screen of all current text, displaying the 'Command:' line only");
            Console.WriteLine("- quit: Displays the final state of the motel and allows you to quit the game\n");
            Console.WriteLine("Press Enter to start");
            Console.ReadKey();
            Console.Clear();
            if (g.IsPlaying)
            {
                
                TimerCallback timerCallBack = g.GameTickMethod; // Initialize the timer callback
                Timer tmr = new Timer(timerCallBack, null, 1000, RefreshRate); // Intialize the timer (uses callback and game speed)

                InputHandler inputHandler = new InputHandler(g); // Initialize the input handler
                inputHandler.GetUserInput(); // Call the following method for user input
            }
        }
    }
}
