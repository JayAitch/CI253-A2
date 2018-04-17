﻿using System;
using System.Collections.Generic;
using System.Linq;



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
            int fireStart = random.Next(0 , Constants.MAX_NBR_ROOMS - 1);
            roomList[fireStart].StartAsDanger();
            AddToDelegate(roomList[fireStart]);
        }

        // returning a bool based on rooms if any of the rooms are still able to heat up or the delegate is empty
        // will return true if the delegate empty or all the rooms canheatup bools are false
        public bool CheckGameEnd()
        {
            bool isGameEndBool = true;
            for (int i = 0; i < roomList.Count(); i++)
            {
                if(roomList[i].CanHeatUp == true && MotelRoomDelegate != null) // if all rooms !canheatup or delegate is empty
                {
                    isGameEndBool = false;
                }
                else
                {
                    isGameEndBool = true;
                }
            }
            return isGameEndBool;
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
                if(roomList[currentRoom].CanHeatUp == false)
                {
                    RemoveFromDelegate(roomList[currentRoom]); // remove rooms that have had canheatup switched to empty delgate in order to end the game
                }

            }                
        }


        // Checks adjacent rooms' temperature if room is hot enough to spread. If it is, return true. Otherwise, return false
        private bool CheckAdjacentRooms(int currentRoom)
        {
            int previouseRoom = currentRoom - 1; // selects the previous room in the array
            int nextRoom = currentRoom + 1; // selects the next room in the array

            // Checks if the temperature of the previous/next room exceeds the temperature threshold
            return ((previouseRoom >= 0 && roomList[previouseRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD)
                         || (nextRoom < Constants.MAX_NBR_ROOMS && roomList[nextRoom].Temperature >= Constants.TEMPERATURE_THRESHOLD)); 
      
        }

        // Adding rooms to delegate room is removed first to prevent duplicates
        private void AddToDelegate(Room room)
        {
            MotelRoomDelegate -= room.IncreaseRoomTemp;
            MotelRoomDelegate += room.IncreaseRoomTemp;            
        }
        // removes the room in the param from the delegate
        private void RemoveFromDelegate(Room room)
        {
            MotelRoomDelegate -= room.IncreaseRoomTemp;
        }

        // Lists rooms used in room list command
        public void ListRoomTemperatures()
        {
            Console.WriteLine("");
            for (int i = 0; i < roomList.Count; i++) // Iterates through all rooms giving their number and temperature
            {
                string roomState;                

                if (roomList[i].Temperature < (int)Constants.ROOM_STATES.DANGER)
                {
                    roomState = "Safe";
                }
                else if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.DANGER && roomList[i].Temperature < (int)Constants.ROOM_STATES.SMOULDER)
                {
                    roomState = "Danger";
                }
                else if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.SMOULDER && roomList[i].Temperature < (int)Constants.ROOM_STATES.FIRE)
                {
                    roomState = "Smoulder";
                }
                else if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.FIRE && roomList[i].Temperature < (int)Constants.ROOM_STATES.BURNEDOUT)
                {
                    roomState = "Fire";
                }
                else if (roomList[i].Temperature >= (int)Constants.ROOM_STATES.BURNEDOUT)
                {
                    roomState = "Burndeout";
                }
                else
                {
                    roomState = "None";
                }
                Console.WriteLine("   Room Number: " + roomList[i].RoomNumber + "  Temperature: " + roomList[i].Temperature + "   State:  " + roomState);
            }
        }


        // Potentially move some of this logic. This is checking the rooms against the enum constants and makes a call to print the results
        public void CalculateStates()
        {
            // Values to increment 
            int safeCount = 0;
            int dangerCount = 0;
            int smoulderCount = 0;
            int fireCount = 0;
            int burnedoutCount = 0;
            for (int i = 0; i < roomList.Count; i++) // Check room states and increment values
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

        // Prints 'State Count' results for the game over screen
        private void PrintState(int safeCount, int dangerCount, int smoulderCount, int fireCount, int burnedoutCount)
        {
            Console.WriteLine("");
            Console.WriteLine("   State       |       Count   ");
            Console.WriteLine("   Safe        |       {0}   ", safeCount);
            Console.WriteLine("   Danger      |       {0}   ", dangerCount);
            Console.WriteLine("   Smoulder    |       {0}   ", smoulderCount);
            Console.WriteLine("   Fire        |       {0}   ", fireCount);
            Console.WriteLine("   Burnedout   |       {0}   ", burnedoutCount);
        }


    }
}
