using NUnit.Framework;
using System;

namespace UnitTesting09
{
    public enum ClampStatus { Closed = 0, Open = 1, }

    public interface IClampController
    {
        ClampStatus Status { get; }
        void Close();
        void Open();
    }

    public class ClampControllerMock : IClampController
    {
        protected ClampStatus status;

        public ClampStatus Status { get { return status; } }

        public void Close()
        {
            status = ClampStatus.Closed;
        }

        public void Open()
        {
            status = ClampStatus.Open;
        }

    }

    public class Extraction
    {
        protected IClampController clampController;

        public IClampController ClampController { get { return clampController; } }

        public void SetClamp(IClampController clampController)
        {
            this.clampController = clampController;
        }

        public void Begin()
        {
            if (clampController == null)
            {
                throw new ApplicationException("The clamp controller was not specified!");
            }

            clampController.Open();

            // TODO: Continue with the extraction 
        }

    }

    [TestFixture]
    public class ExtractionTest
    {
        [Test]
        public void Extraction_Begin_ThrowsException()
        {
            Extraction extraction = new Extraction();
            ApplicationException ex = Assert.Throws<ApplicationException>(() => { extraction.Begin(); });
            Assert.AreEqual("The clamp controller was not specified!", ex.Message);
        }

        [Test]
        public void Extraction_Begin_OpensClamp()
        {
            IClampController clampControllerMock = new ClampControllerMock();
            Extraction extraction = new Extraction();
            extraction.SetClamp(clampControllerMock);  // Inject the mock using a method 
            extraction.Begin();
            Assert.AreEqual(ClampStatus.Open, clampControllerMock.Status);
        }

    }

}

