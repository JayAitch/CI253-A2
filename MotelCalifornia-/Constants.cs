using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Constants
    {
        // Config Settings
        public static readonly int MAX_NBR_ROOMS = 16; // Maximum number of rooms in the motel
        public static readonly int TEMPERATURE_THRESHOLD = 150; // Temperature threshold before room begins heating up
        public static readonly int TEMPERATURE_INCREMENT = 20; // Temperature increment per tick



        // Room State Temperatures
        //public static readonly int ROOM_STATE_SAFE = 0; // Safe state of room = 0 degrees
        //public static readonly int ROOM_STATE_DANGER = 150; // Danger state of room =  150 degrees. Anything above this value sets the room to start heating up
        //public static readonly int ROOM_STATE_SMOULDER = 300; // Smoulder state of room = 300 degrees
        //public static readonly int ROOM_STATE_FIRE = 600; // Fire state of room = 600 degrees. By this point, the room is set on fire
        //public static readonly int ROOM_STATE_BURNEDOUT = 700; // Burnedout state of room = 700 degrees. By this point, the room cannot be salvaged by coolant
        public enum ROOM_STATES { SAFE = 0, DANGER = 150, SMOULDER = 300, FIRE = 600, BURNEDOUT = 700 };

        // Game Speeds. Currently only two settings, but more can be added
        public static readonly int SLOW_GAME_SPEED = 3000000; // Slow game speed is set to 10 seconds per tick
        public static readonly int FAST_GAME_SPEED = 600; // Fast game speed is set to 2 seconds per tick

        // Constants for Fire Engine
        public static readonly int COOLANT_CAPACITY = 600; // Fire engine max coolant capacity is set to 600
        public static readonly int COOLANT_EMIT_PER_TICK = 40; // Every tick, 40 coolant is subtracted from the current capacity
        public static readonly int COOLANT_REDUCE_EFFECT = 1; // Used to reduce temperature of rooms

    }
}
