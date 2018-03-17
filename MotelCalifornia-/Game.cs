using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Game
    {
        public int RefreshRate = Constants.FAST_GAME_SPEED;
        Motel motel = new Motel();
        int tick = 0;


        //  method called per tick as assigned by enum
        public void TickTock(Object data)
        {
            // called to resolve and allocate to room delegate
                motel.DelegateOperrations();
                if (motel.MotelRoomDelegate != null)
                {
                // calling delegate to call methods and call room iterator for testing
                    motel.MotelRoomDelegate();
                    motel.GetRoomTemperatures();
                     Console.WriteLine("--------------------------------   " + tick + "  ---------------------------");
                    tick++;
                }      
        }
    }
}
