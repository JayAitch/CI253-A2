using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler inputHandler = new InputHandler();
            inputHandler.GetInput();
            Room room = new Room();
            while (room.Temperature < 1000)
            {
                room.IncrementTemp();
                room.ReturnState();
                Console.WriteLine(room.CurrentRoomState);
            }
        }
    }
}
