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
        public Boolean CanHeatUp { get; set; }
        // boolean to prevent the room being added to the list if it is burnout or quenched 
      
        //  constructor to allow rooms to have room numbers + initial canheatup set
        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
            CanHeatUp = true;
        }

        //  increase the temperature controlled by delegate
        public void IncrementTemp()
        {
            if(Temperature >= 700)
            {

            }
            else
            {
                Temperature += Constants.TEMPERATURE_INCREMENT;//per event
            }
             
           // Console.WriteLine("Increment called for room " + RoomNumber + " current temperature " + Temperature);
        }
    }
}
