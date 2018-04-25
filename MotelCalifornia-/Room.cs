using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Room
    {
        // State to switch based on temp
        //public enum RoomState { SAFE, DANGER, SMOULDER, FIRE, BURNEDOUT };

        //public RoomState CurrentRoomState { get; private set; }

        // Temporarily changed the set accessibility for testing
        public int Temperature { get; private set; } // Used to get and set temperature
        public int RoomNumber { get; private set; } // Used to get and set room number
        public Boolean CanHeatUp { get; private set; } // Used to prevent the room being added to the list if it is burnedout or quenched 


        // Constructor to allow rooms to have room numbers + initial 'canheatup' set
        public Room(int roomNumber)
        {
            RoomNumber = roomNumber + 1; // 1 is added to generate room numbers starting at 1 instead of 0
            CanHeatUp = true;
        }

        //private method to start the room on fire randomly
        public void StartAsDanger()
        {
            Temperature = 150;
        }

        // Increase the temperature controlled by delegate
        public void IncreaseRoomTemp()
        {
            if (CanHeatUp) // If the room can heat up...
            {
                if (Temperature >= (int)Constants.ROOM_STATES.BURNEDOUT)  // If the room is in 'BURNEDOUT' state...
                {
                    // Do nothing
                    CanHeatUp = false;
                }
                else // Else...
                {
                    Temperature += Constants.TEMPERATURE_INCREMENT; // Increment the temperature of the room
                }
            }
            // else room is quenched or burnedout
           // Console.WriteLine("Increment called for room " + RoomNumber + " current temperature " + Temperature);
        }

      // Reduces temperature per coolant used
        public bool DecreaseRoomTemp(int coolantUsed)
        {
            // If room state leaves danger threshold, set 'canheatup' to false
            if (Temperature < (int)Constants.ROOM_STATES.DANGER)
            {
                Console.WriteLine("Room was Quenched");
                CanHeatUp = false;
            }
            else
            {

                // Generalised method so that less coolant can be emitted than the max per tick
                Temperature -= coolantUsed * Constants.COOLANT_REDUCE_EFFECT;
                if (Temperature < (int)Constants.ROOM_STATES.DANGER)
                {
                    CanHeatUp = false;
                }
            }
            return CanHeatUp;
        }
    }
}
