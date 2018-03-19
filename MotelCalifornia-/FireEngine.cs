using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class FireEngine
    {
        public int CoolantLevel { get; private set; }
        public enum FireEngineStatus { FREE, ONCALL, STATIONED };
        public FireEngineStatus CurrentFireEngineStatus;
        public int EngineID { get; private set; }
        public Room RoomToCoolDown { get; set; }
        // do we want to add a room reference to simplifiy cooling target or pass the room around 


        // constructor as per brief
        public FireEngine(int engineID)
        {
            EngineID = engineID;
            CoolantLevel = Constants.COOLANT_CAPACITY;            
            CurrentFireEngineStatus = FireEngineStatus.STATIONED;
        }

        
    }
}
