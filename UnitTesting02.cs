using NUnit.Framework;

namespace UnitTesting02
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
        [TestCase(675u, false)]
        [TestCase(1050u, true)]
        public void OpticalSensor_IsRedBloodCell_Works(uint measuredValue, bool expected)
        {
            OpticalSensor opticalSensor = new OpticalSensor();
            bool actual = opticalSensor.IsRedBloodCell(measuredValue);
            Assert.AreEqual(expected, actual);
        }

    }

}

