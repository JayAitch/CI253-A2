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

            Game g = new Game();
            TimerCallback timerCallBack = g.TickTock;
            Timer tmr = new Timer(timerCallBack, null, 1000, g.RefreshRate);

            InputHandler inputHandler = new InputHandler();
            inputHandler.GetInput();

        }
    }
}
