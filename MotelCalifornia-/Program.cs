using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MotelCalifornia
{
    class Program
    {
        static void Main(string[] args)
        {
            StartScreen();
        }

        static void StartScreen()
        {
            Game g = new Game(); // Initialize the game

            Console.WriteLine("This is a start screen");
            Console.WriteLine("Press Enter to start");
            Console.ReadKey();
            Console.Clear();
            if (g.IsPlaying)
            {
                
                TimerCallback timerCallBack = g.TickTock; // Initialize the timer callback
                Timer tmr = new Timer(timerCallBack, null, 1000, g.RefreshRate); // Intialize the timer (uses callback and game speed)

                InputHandler inputHandler = new InputHandler(g); // Initialize the input handler
                inputHandler.GetInput(); // Call the following method for user input
            }
        }
    }
}
