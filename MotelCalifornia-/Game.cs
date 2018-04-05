using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Game
    {
        public int RefreshRate = Constants.FAST_GAME_SPEED; // Sets the game speed to FAST
        Motel motel = new Motel(); // Intializes the motel
        int tick = 0; // Test tick is set to 0


        // Method called per tick as assigned by enum
        public void TickTock(Object data)
        {
                // Called to resolve and allocate to room delegate
                motel.DelegateOperrations();
                if (motel.MotelRoomDelegate != null) // If the room delegate is not null...
                {
                    // Calls delegate to call methods/room iterator for testing
                    motel.MotelRoomDelegate(); // Call the following function                   
                }      
        }
        public void CheckRooms()
        {
            motel.ListRoomTemperatures();
        }
        public void ReportRooms()
        {
            motel.CalculateStates();
        }
    }
}
