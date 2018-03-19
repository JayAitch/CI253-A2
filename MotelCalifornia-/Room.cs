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
        //public enum RoomState { SAFE, DANGER, SMOULDER, FIRE, BURNEDOUT };

        //public RoomState CurrentRoomState { get; private set; }

            // temperariliy changed the set accessibility for testing
        public int Temperature { get; set; }
        public int RoomNumber { get; private set; }
        public Boolean CanHeatUp { get; private set; }
        // boolean to prevent the room being added to the list if it is burnout or quenched 
      
        //  constructor to allow rooms to have room numbers + initial canheatup set
        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
            CanHeatUp = true;
        }

        //  increase the temperature controlled by delegate
        public void IncreaseRoomTemp()
        {
            if (CanHeatUp)
            {
                if (Temperature >= Constants.ROOM_STATE_BURNEDOUT)
                {

                }
                else
                {
                    Temperature += Constants.TEMPERATURE_INCREMENT;//per event
                }
            }
            // else room is quenched or burnedout
           // Console.WriteLine("Increment called for room " + RoomNumber + " current temperature " + Temperature);
        }

        //currently unusused thoughts on how to fire engine will reduce temp
        // do we want each coolant to reduce by the amount stated in the brief or just the result per tick
        public void DecreaseRoomTemp()
        {
            if(Temperature <= Constants.ROOM_STATE_SAFE)
            {
                CanHeatUp = false;
            }
            else
            {
                // used this instead of just coolant per tick to make changes easier
                Temperature -= Constants.COOLANT_EMIT_PER_TICK * Constants.COOLANT_REDUCE_EFFECT;
            }
        }
    }
}
