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
        // do we want to add a room reference to simplifiy cooling target or pass the room around 

        // FOR JORDAN: ADD A ROOM REFERENCE

        // Constructor for fire engine
        public FireEngine(int engineID)
        {
            EngineID = engineID; // Initialize the engine ID
            CoolantLevel = Constants.COOLANT_CAPACITY;   // Initialize the coolant level          
            CurrentFireEngineStatus = FireEngineStatus.STATIONED; // Initialize the fire engine status as STATIONED
        }

        
    }
}
