﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MotelCalifornia
{
    class Motel
    {
        public List<Room> roomList; // Array of rooms
        public delegate void RoomThemostatDelegate(); // Delegate for the room temperature
        public RoomThemostatDelegate MotelRoomDelegate { get; set; } // Variable for getting and setting the room delegate

        // Constructor to generate rooms
        public Motel()
        {           
            roomList = new List<Room>(); // Intializes the room array
            for ( int i = 0; i < Constants.MAX_NBR_ROOMS; i++) // For each room in the array...
            {
                Room room = new Room(i); // Intialize the room.
                roomList.Add(room); // Add the room to the array
            }
            InitFireStart();
           // roomList[5].Temperature = 180; // Set a designated room at a set temperature
        }

        // using public method on rooms to start a fire in a random room
        private void InitFireStart()
        {
            Random random = new Random();
            int fireStart = 15;// random.Next(0 , Constants.MAX_NBR_ROOMS - 1);
            roomList[fireStart].StartAsDanger();
            AddToDelegate(roomList[fireStart]);
        }

        // Decides whether to assign or remove rooms from delegate
        public void DelegateOperrations()
        {
            for(int currentRoom = 0; currentRoom < roomList.Count; currentRoom++) // For each room in the array...
            {
                                   
                    if (CheckAdjacentRooms(currentRoom)) // Calls the following method
                    {
                        // Allocate to delegate
                        AddToDelegate(roomList[currentRoom]); // Adds the current room to the delegate
                    }
            }                
        }


        // Checks adjacent rooms' temperature if room is hot enough to spread. If it is, return true. Otherwise, return false
        public bool CheckAdjacentRooms(int currentRoom)
        {
            int previouseRoom = currentRoom - 1; // selects the previous room in the array
            int nextRoom = currentRoom + 1; // selects the next room in the array

            // Checks if the temperature of the previous/next room exceeds the temperature threshold
            return ((previouseRoom >= 0 && roomList[previouseRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD)
                         || (nextRoom < Constants.MAX_NBR_ROOMS && roomList[nextRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD)); 
      
        }

        // Adding rooms to delegate room is removed first to prevent duplicates
        public void AddToDelegate(Room room)
        {
            MotelRoomDelegate -= room.IncreaseRoomTemp;
            MotelRoomDelegate += room.IncreaseRoomTemp;            
        }

        // TESTING METHOD. Used to print out room conditions. Will be deprocated
        public void ListRoomTemperatures()
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                
                Console.WriteLine("   Room Number: " + roomList[i].RoomNumber + "  Temperature: " + roomList[i].Temperature
                     + " Delegate Length: " + MotelRoomDelegate.GetInvocationList().Count());
                
            }
        }

        public void CalculateStates()
        {
            int safeCount = 0;
            int dangerCount = 0;
            int smoulderCount = 0;
            int fireCount = 0;
            int burnedoutCount = 0;
            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].Temperature < (int)Constants.ROOM_STATES.DANGER)
                {
                    safeCount++;
                }
                if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.DANGER && roomList[i].Temperature < (int)Constants.ROOM_STATES.SMOULDER)
                {
                    dangerCount++;
                }
                if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.SMOULDER && roomList[i].Temperature < (int)Constants.ROOM_STATES.FIRE)
                {
                    smoulderCount++;
                }
                if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.FIRE && roomList[i].Temperature < (int)Constants.ROOM_STATES.BURNEDOUT)
                {
                    fireCount++;
                }
                if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.BURNEDOUT)
                {
                    burnedoutCount++;
                }               
            }
            PrintState(safeCount, dangerCount, smoulderCount, fireCount, burnedoutCount);
        }

        private void PrintState(int safeCount, int dangerCount, int smoulderCount, int fireCount, int burnedoutCount)
        {
            Console.WriteLine("   State       |       Count   ");
            Console.WriteLine("   Safe        |       {0}   ", safeCount);
            Console.WriteLine("   Danger      |       {0}   ", dangerCount);
            Console.WriteLine("   Smoulder    |       {0}   ", smoulderCount);
            Console.WriteLine("   Fire        |       {0}   ", fireCount);
            Console.WriteLine("   Burnedout   |       {0}   ", burnedoutCount);
        }


    }
}
