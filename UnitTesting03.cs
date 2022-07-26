using NUnit.Framework;
using System;

namespace UnitTesting03
{
    public class OpticalSensor
    {
        public bool IsRedBloodCell(uint measuredValue)
        {
            if (measuredValue > 2000)
            {
                throw new ApplicationException("The measured value must be lower than 2000!");
            }

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

        [Test]
        public void OpticalSensor_IsRedBloodCell_ThrowsExcwption()
        {
            OpticalSensor opticalSensor = new OpticalSensor();
            ApplicationException ex = Assert.Throws<ApplicationException>(() => { opticalSensor.IsRedBloodCell(2001); });
            Assert.AreEqual("The measured value must be lower than 2000!", ex.Message);
        }

    }

}

