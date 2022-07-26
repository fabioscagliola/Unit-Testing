using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTesting06
{
    public interface IPressController
    {
        uint Position { get; }
        Task GoHome();

    }

    public class PressController : IPressController  // This class in not being tested anymore 
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

    public class PressControllerStub : IPressController
    {
        protected virtual uint HomePosition { get { return 0; } }

        protected uint position;

        public uint Position { get { return position; } }

        public async Task GoHome()
        {
            await Task.Run(() =>
            {
                Task.Delay(3000);
                position = HomePosition;
            });
        }

    }

    public class PressControllerStubNotGoingHome : PressControllerStub
    {
        protected override uint HomePosition { get { return 1050; } }
    }

    public class Extraction
    {
        protected IPressController pressController;

        public Extraction(IPressController pressController)
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
            IPressController pressControllerStub = new PressControllerStubNotGoingHome();
            Extraction extraction = new Extraction(pressControllerStub);
            ApplicationException ex = Assert.ThrowsAsync<ApplicationException>(async () => { await extraction.Begin(); });
            Assert.AreEqual("The press did not go home!", ex.Message);
        }

        [Test]
        public void Extraction_Begin_Works()
        {
            IPressController pressControllerStub = new PressControllerStub();
            Extraction extraction = new Extraction(pressControllerStub);
            Assert.DoesNotThrowAsync(async () => { await extraction.Begin(); });
        }

    }

}

