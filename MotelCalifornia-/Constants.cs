using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Constants
    {
        //config settings 
        public static readonly int MAX_NBR_ROOMS = 16;
        public static readonly int TEMPERATURE_THRESHOLD = 150;
        public static readonly int TEMPERATURE_INCREMENT = 20;



        //temperature assignments of room states
        public static readonly int ROOM_STATE_SAFE = 0;
        public static readonly int ROOM_STATE_DANGER = 150;
        public static readonly int ROOM_STATE_SMOULDER = 300;
        public static readonly int ROOM_STATE_FIRE = 600;
        public static readonly int ROOM_STATE_BURNEDOUT = 700;


        //game speeds
        public static readonly int SLOW_GAME_SPEED = 10000;
        public static readonly int FAST_GAME_SPEED = 2000;

        //fire-truck constants 
        public static readonly int COOLANT_CAPACITY = 600;

    }
}
