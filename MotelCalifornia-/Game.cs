using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Game
    {
        public bool IsPlaying { get;  set; }
        public int RefreshRate = Constants.FAST_GAME_SPEED; // Sets the game speed to FAST
        Motel motel = new Motel(); // Intializes the motel
        FireEngine fireEngine = new FireEngine(1);

        
        // Game constructor is set to playing
        public Game()
        {
            IsPlaying = true;            
        }

        // Method called per tick as assigned by enum
        public void GameTickMethod(Object data)
        {
            IsPlaying = !IsCheckGameEnd();
            if (IsPlaying)
            {

               
                    // Tick fire engine coolant if it is cooling a room (ONCALL)
                    if (fireEngine.CurrentFireEngineStatus == FireEngine.FireEngineStatus.ONCALL)
                    {
                        fireEngine.UseCoolant();
                    }

                    motel.DelegateOperrations(); // Called to resolve and allocate to room delegate
                    if (motel.MotelRoomDelegate != null) // If the room delegate is not null...
                    {

                        motel.MotelRoomDelegate(); // Call the following function                   
                    }
                              
            }
        }
        // Private method to check for game end everytick using method inside motel
        private bool IsCheckGameEnd()
        {
            return  motel.CheckGameEnd();
        }

        // This section dispatches command messages
        // Command room list
        public void CheckRooms()
        {
            motel.ListRoomTemperatures();
        }
        // Command room report
        public void ReportRooms()
        {
            motel.CalculateStates();
        }
        // Command quit
        public void QuitGame()
        {
            IsPlaying = false;
            Console.Clear();
            Console.WriteLine("The Game Is Over! Your final score is:");
            motel.CalculateStates();
        }
        // Fire Engine Commands
        // Command engine goto #
        public void SendEngineToRoom(int roomToSendTo)
        {
            fireEngine.SendEngineToRoom(motel.roomList[roomToSendTo]);
        }
        public void SendEngineToStation()
        {
            fireEngine.StationEngine();
        }
        public void RefillEngine()
        {
            fireEngine.RefillEngine();
        }
        public void GetEngineReport()
        {
            fireEngine.EngineReport();
        }
    }
}
