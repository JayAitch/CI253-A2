using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotelCalifornia;
using System;

namespace MotelCaliforniaTest
{
    [TestClass]
    public class CoolRoomTest
    {
        //testing room temperature change
        private int Temperature;
        private bool CanHeatUp;
        private int coolantUsed;
        private int expectedDrop;
        private int temperatureChange;

        [TestMethod]
        public void Test_Cool_Room_Method()
        {
            // settup
            int StartTemperature = 10000;
            Temperature = StartTemperature;
            coolantUsed = 10;
            CanHeatUp = true;
            expectedDrop = coolantUsed * Constants.COOLANT_REDUCE_EFFECT;
            int previouse_temperature = Temperature;

            //action
            DecreaseRoomTemp(coolantUsed);
            temperatureChange = previouse_temperature - Temperature;            
           
            //assert
            Assert.AreEqual(expectedDrop, temperatureChange, 0.001, "Temperature change not correct");
            Assert.AreEqual(Temperature, StartTemperature - expectedDrop, 0.001, "Temperature result not expexted");
        }

        [TestMethod]
        public void Test_Can_Heat_Up_Bool()
        {
            // check bool against temperature range
            if (Temperature < (int)Constants.ROOM_STATES.DANGER)
            {
                Assert.IsFalse(CanHeatUp);
            }
            else { Assert.IsFalse(!CanHeatUp); }
        }

        public bool DecreaseRoomTemp(int coolantUsed)
        {
            // If room state leaves danger threshold, set 'canheatup' to false
            if (Temperature < (int)Constants.ROOM_STATES.DANGER)
            {
                Console.WriteLine("Room was Quenched");
                CanHeatUp = false;
            }
            else
            {

                // Generalised method so that less coolant can be emitted than the max per tick
                Temperature -= coolantUsed * Constants.COOLANT_REDUCE_EFFECT;
                if (Temperature < (int)Constants.ROOM_STATES.DANGER)
                {
                    CanHeatUp = false;
                }
            }
            return CanHeatUp;
        }









        // testing coolant methods on fire engine
        private int CoolantLevel;
        private int ExpectedCoolant;
        private int CoolantPerTick;

        [TestMethod]
        public void Test_Coolant_Reduces_By_Amount_Emmited()
        {
            //settup
            CoolantLevel = 150;
            CoolantPerTick = 20;
            ExpectedCoolant = CoolantLevel - CoolantPerTick;

            //action
            UseCoolant();

            Assert.AreEqual(CoolantLevel, ExpectedCoolant, 0.001, "Coolant maount not expected");

        }

        [TestMethod]
        public void Test_Coolant_Emitting_Final_Amount()
        {
            //settup
            CoolantLevel = 150;
            CoolantPerTick = 100;
            ExpectedCoolant = CoolantLevel - CoolantPerTick;

            //action
            UseCoolant();
            UseCoolant();

            Assert.AreEqual(CoolantLevel, 0, 0.001, "Coolant maount not expected");
        }

        // Cool down room if on call
        public void UseCoolant()
        {
            // If room 'canheatup' bool is true
            //  if (RoomToCoolDown.CanHeatUp)
            // {
            if ((CoolantLevel - CoolantPerTick) >= 0) // If current coolant is more than the coolant per tick...
            {
                CoolantLevel -= CoolantPerTick; // Reduce by coolant & temp per tick
                TestCoolantAmount(CoolantPerTick);

            }
            else if (CoolantLevel > 0) // If coolant level is not empty...
            {              
                // this is throwing the error
                TestCoolantAmount(CoolantLevel);
                CoolantLevel -= CoolantLevel; // Reduce coolant and temp by remaining coolant
            }
            else
            {
                //  CurrentFireEngineStatus = FireEngineStatus.FREE; // Engine has no water. Set status to FREE breaks out of loop
                Console.WriteLine("Engine out of water!");
            }

            //}

        }
        private void TestCoolantAmount(int coolantUsed)
        {
            if(coolantUsed < CoolantPerTick)
            {
                // used when coolant goes from 50 to 0
                Assert.AreEqual(coolantUsed, 50, 0.001, "Not using the remainder of coolant");
            }
        }
        
        
    }
}
