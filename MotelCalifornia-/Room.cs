using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Room
    {
        // state to switch based on temp
        public enum RoomState { SAFE, DANGER, SMOULDER, FIRE, BURNEDOUT };

        public RoomState CurrentRoomState { get; private set; }
        public int Temperature { get; private set; }

        // simply for testing method should work simularly for with timers
        public void IncrementTemp()
        {
            Temperature++;
            // Temperature += 20 //per event
        }

        //setting room state based on temp
        //discuss either returning the state from this method or getting it outside of the class, probably the later
        public void ReturnState()
        {
            if (Temperature < 150)
            {
                CurrentRoomState = RoomState.SAFE;
            }

            else if (Temperature >= 150 && Temperature < 300)
            {
                CurrentRoomState = RoomState.DANGER;
            }

            else if (Temperature >= 300 && Temperature < 600)
            {
                CurrentRoomState = RoomState.SMOULDER;
            }

            else if (Temperature >= 600 && Temperature < 700)
            {
                CurrentRoomState = RoomState.FIRE;
            }

            else if (Temperature >= 700)
            {
                CurrentRoomState = RoomState.BURNEDOUT;
            }
            // testing the states inside the method potential move to another class for tests
            else
            {
                Console.WriteLine("state return failed.");
            }
        }
    }
}
