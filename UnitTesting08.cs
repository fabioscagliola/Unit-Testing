/*

## Unit testing example 8 

In the "UnitTesting08.cs" file, the **IClampController** interface is extracted 
from the **ClampController** class, and the **ClampControllerMock** class is 
introduced as a mock, implementing the **IClampController** interface; with 
minor adjustments to the **Extraction** class and to the unit test, the code is 
now covered: we got rid of the dependency using the mock; please note that we do 
make assertions against the mock 

In this example the the mock is injected using a constructor 

*/

using NUnit.Framework;
using System;

namespace UnitTesting08
{
    public enum ClampStatus { Closed = 0, Open = 1, }

    public interface IClampController
    {
        ClampStatus Status { get; }
        void Close();
        void Open();
    }

    public class ClampController : IClampController  // This class in not being tested anymore 
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

        public Extraction(IClampController clampController)
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
        public void Extraction_Begin_OpensClamp()
        {
            IClampController clampControllerMock = new ClampControllerMock();
            Extraction extraction = new Extraction(clampControllerMock);  // Inject the mock using a constructor 
            extraction.Begin();
            Assert.AreEqual(ClampStatus.Open, clampControllerMock.Status);
        }

    }

}

