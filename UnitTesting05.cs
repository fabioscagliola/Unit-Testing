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

