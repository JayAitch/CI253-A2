using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MotelCalifornia
{
    class Motel
    {
        public List<Room> roomList;
        public delegate void RoomThemostatDelegate();
        public RoomThemostatDelegate MotelRoomDelegate { get; set; }

        // this value is only for testing
        int testIncrementor;
        //  Constructor to generate rooms
        public Motel()
        {           
            roomList = new List<Room>();
            for ( int i = 0; i < Constants.MAX_NBR_ROOMS; i++)
            {
                Room room = new Room(i+1);
                roomList.Add(room);
            }
            roomList[5].Temperature = 180;
        }

        // deciding whether to assign or remove rooms from delegate
        public void DelegateOperrations()
        {
            for(int currentRoom = 0; currentRoom < roomList.Count; currentRoom++)
            {
                                   
                    if (CheckAdjacentRooms(currentRoom))
                    {
                        //allocate to delegate
                        AddToDelegate(roomList[currentRoom]);
                    }
            }                
        }


        // checking adjacent rooms temperature if room is hot enough to spread will return true otherwise returns false
        public bool CheckAdjacentRooms(int currentRoom)
        {
            int previouseRoom = currentRoom - 1;
            int nextRoom = currentRoom + 1;
            return ((previouseRoom > 0 && roomList[previouseRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD)
                         || (nextRoom < 15 && roomList[nextRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD));
      
        }
        // adding rooms to delegate room is removed first to prevent duplicates
        public void AddToDelegate(Room room)
        {
            MotelRoomDelegate -= room.IncreaseRoomTemp;
            MotelRoomDelegate += room.IncreaseRoomTemp;            
        }

        // simple testing method to print out room conditions will be deprocated
        public void GetRoomTemperatures()
        {
            for(int i = 0; i < roomList.Count; i++)
            {
                
                Console.WriteLine("   Room Number: " + roomList[i].RoomNumber + "  Temperature: " + roomList[i].Temperature
                    + " increment test: " + testIncrementor + " Delegate Length: " + MotelRoomDelegate.GetInvocationList().Count());
                
            }
            testIncrementor++;
        }
    }
}
