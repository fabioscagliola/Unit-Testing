/*

## Unit testing example 5 

In the "UnitTesting05.cs" file, the **GoHome** method of the **PressController** 
class depends on some piece of hardware; the dependency is now simulated by 
throwing an exception; in such a scenario, unless we somehow get rid of the 
dependency, the unit test can only verify that the exception is thrown 

*/

using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTesting05
{
    public class PressController
    {
        protected uint position;

        public uint Position { get { return position; } }

        public async Task GoHome()
        {
            await Task.Run(() =>
            {
                throw new ApplicationException("The press did not respond!");
            });
        }

    }

    public class Extraction
    {
        protected PressController pressController;

        public Extraction(PressController pressController)
        {
            this.pressController = pressController;
        }

        public async Task Begin()
        {
            await pressController.GoHome();

            if (pressController.Position != 0)
            {
                throw new ApplicationException("The press did not go home!");
            }

            // TODO: Continue with the extraction 
        }

    }

    [TestFixture]
    public class OpticalSensorTest
    {
        [Test]
        public void Extraction_Begin_ThrowsException()
        {
            PressController pressController = new PressController();
            Extraction extraction = new Extraction(pressController);
            ApplicationException ex = Assert.ThrowsAsync<ApplicationException>(async () => { await extraction.Begin(); });
            Assert.AreEqual("The press did not respond!", ex.Message);
        }

    }

}

