using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class FireEngine
    {
        // Coolant Level of fire engine
        public int CoolantLevel { get; private set; }

        // Different states of the fire engine: FREE enables deployment, ONCALL means it's out of the station, and STATIONED means it can be refilled
        public enum FireEngineStatus { FREE, ONCALL, STATIONED }; 

        // Used to check the current status of the fire engine
        public FireEngineStatus CurrentFireEngineStatus;

        // Engine ID of fire engine
        public int EngineID { get; private set; }

        // Used to target a specified room to cool down
        public Room RoomToCoolDown { get; set; }
        

        // Constructor for fire engine
        public FireEngine(int engineID)
        {
            EngineID = engineID; // Initialize the engine ID
            CoolantLevel = Constants.COOLANT_CAPACITY;   // Initialize the coolant level          
            CurrentFireEngineStatus = FireEngineStatus.STATIONED; // Initialize the fire engine status as STATIONED
        }

        // refill fire engine coolant if already stationed
        public void RefillEngine()
        {
            if(CurrentFireEngineStatus == FireEngineStatus.STATIONED)
            {
                CoolantLevel = Constants.COOLANT_CAPACITY;
            }
            else
            {
                Console.WriteLine("Fire Engine Not Stationed!");
            }
        }
        
        // station the engine for refueling
        public void StationEngine()
        {
            CurrentFireEngineStatus = FireEngineStatus.STATIONED;
            Console.WriteLine("Stationed Engine");
        }

        // assign room and fire engine state via room identified in command
        public void SendEngineToRoom(Room coolingRoom)
        {
            RoomToCoolDown = coolingRoom;
            CurrentFireEngineStatus = FireEngineStatus.ONCALL;
            Console.WriteLine("Sending The boys out to room " + RoomToCoolDown.RoomNumber);
        }

        // cooldown room if on call
        public void UseCoolant()
        {
            // if room canheatup bool is true
            if (RoomToCoolDown.CanHeatUp)
            {             
                if ((CoolantLevel - Constants.COOLANT_EMIT_PER_TICK) >= 0) //if current coolant is more than the coolant per tick
                {
                    CoolantLevel -= Constants.COOLANT_EMIT_PER_TICK; //reduce by coolant & temp per tick
                    RoomToCoolDown.DecreaseRoomTemp(Constants.COOLANT_EMIT_PER_TICK);

                }
                else if (CoolantLevel > 0) // if coolant level is not empty
                {
                    CoolantLevel -= CoolantLevel; // reduce coolant and temp by remaining coolant
                    RoomToCoolDown.DecreaseRoomTemp(CoolantLevel);
                }
                else
                {
                    CurrentFireEngineStatus = FireEngineStatus.FREE; // engine has no water set status to FREE breaks out of loop
                    Console.WriteLine("engine out of water");
                }

            }                
                        
        }
        // method for engine report
        public void EngineReport()
        {
            string QuenchedOrBurndeout; // string to disply status of rooms to show if they can heatup
            Console.WriteLine("");
            Console.WriteLine("Fire Engine report.");
            Console.WriteLine("EngineID:   {0}", EngineID);
            Console.WriteLine("Engine Status:   {0}", CurrentFireEngineStatus);
            Console.WriteLine("Coolant:   {0}", CoolantLevel);
            if(CurrentFireEngineStatus == FireEngineStatus.ONCALL)
            {
                Console.WriteLine("Room Cooling:    {0}", RoomToCoolDown.RoomNumber);
                Console.WriteLine("Temperature of room:    {0}", RoomToCoolDown.Temperature);
                
                if(!RoomToCoolDown.CanHeatUp)
                {
                    if(RoomToCoolDown.Temperature >= (int)Constants.ROOM_STATES.BURNEDOUT)
                    {
                        QuenchedOrBurndeout = "Room is Burnedout";
                    }
                    else
                    {
                        QuenchedOrBurndeout = "Room is Quenched";
                    }
                }
                else
                {
                    QuenchedOrBurndeout = "Room can heat up!";
                }
                Console.WriteLine(QuenchedOrBurndeout);
            }

        }
    }
}
