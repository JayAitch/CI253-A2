using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotelCalifornia;
using System;

namespace MotelCaliforniaTest
{
    [TestClass]
    public class CoolRoomTest
    {
        private int Temperature;
        private bool CanHeatUp;
        private int coolantUsed;
        private int expectedDrop;
        private int temperatureChange;

        [TestMethod]
        public void CoolRoomTestMethod()
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
            TestCanHeatBool();
        }

        [TestMethod]
        public void TestCanHeatBool()
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
    }
}
