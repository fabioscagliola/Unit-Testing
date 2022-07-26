using NUnit.Framework;
using System;

namespace UnitTesting07
{
    public enum ClampStatus { Closed = 0, Open = 1, }

    public class ClampController
    {
        protected ClampStatus status;

        public ClampStatus Status { get { return status; } }

        public void Close()
        {
            throw new ApplicationException("The clamp did not respond!");
        }

        public void Open()
        {
            throw new ApplicationException("The clamp did not respond!");
        }

    }

    public class Extraction
    {
        protected ClampController clampController;

        public ClampController ClampController { get { return clampController; } }

        public Extraction(ClampController clampController)
        {
            this.clampController = clampController;
        }

        public void Begin()
        {
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
            ClampController clampController = new ClampController();
            Extraction extraction = new Extraction(clampController);
            ApplicationException ex = Assert.Throws<ApplicationException>(() => { extraction.Begin(); });
            Assert.AreEqual("The clamp did not respond!", ex.Message);
        }

    }

}

