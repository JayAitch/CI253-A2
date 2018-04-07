using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Game
    {
        public bool IsPlaying { get; private set; }
        public int RefreshRate = Constants.SLOW_GAME_SPEED; // Sets the game speed to FAST
        Motel motel = new Motel(); // Intializes the motel
        FireEngine fireEngine = new FireEngine(1);

        
        // game constructor to set is playing
        public Game()
        {
            IsPlaying = true;            
        }

        // Method called per tick as assigned by enum
        public void TickTock(Object data)
        {

            if (IsPlaying)
            {
                IsPlaying = !IsCheckGameEnd(); 
                    // tick fire engine coolant if it i cooling a room (ONCALL)
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

        public bool IsCheckGameEnd()
        {
            return  motel.CheckGameEnd();
        }

        // This section dispatches command messages
        // command room list
        public void CheckRooms()
        {
            motel.ListRoomTemperatures();
        }
        // command room report
        public void ReportRooms()
        {
            motel.CalculateStates();
        }
        // comand quit
        public void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("The Game Is Over your final score is:");
            motel.CalculateStates();
        }
        //fire engine commands
        // command engine goto #
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
