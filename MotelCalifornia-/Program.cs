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

            Game g = new Game(); // Initialize the game
            TimerCallback timerCallBack = g.TickTock; // Initialize the timer callback
            Timer tmr = new Timer(timerCallBack, null, 1000, g.RefreshRate); // Intialize the timer (uses callback and game speed)

            InputHandler inputHandler = new InputHandler(g); // Initialize the input handler
            
            if (g.IsPlaying)
            {
                inputHandler.GetInput(); // Call the following method for user input
            }
            else
            {
                inputHandler.isGameFinished = true;

            }
        }
    }
}
