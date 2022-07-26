using NUnit.Framework;

namespace UnitTesting01
{
    public class OpticalSensor
    {
        public bool IsRedBloodCell(uint measuredValue)
        {
            bool result = false;

            if (measuredValue > 1000)
            {
                result = true;
            }

            return result;
        }
    }

    [TestFixture]
    public class OpticalSensorTest
    {
        [Test]
        public void OpticalSensor_IsRedBloodCell_ReturnsFalse()
        {
            OpticalSensor opticalSensor = new OpticalSensor();
            bool result = opticalSensor.IsRedBloodCell(675);
            Assert.IsFalse(result);
        }

        [Test]
        public void OpticalSensor_IsRedBloodCell_ReturnsTrue()
        {
            OpticalSensor opticalSensor = new OpticalSensor();
            bool result = opticalSensor.IsRedBloodCell(1050);
            Assert.IsTrue(result);
        }

    }

}

