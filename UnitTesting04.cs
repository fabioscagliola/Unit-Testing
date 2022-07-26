using NUnit.Framework;

namespace UnitTesting04
{
    public enum ClampStatus { Closed = 0, Open = 1, }

    public class Clamp
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

    [TestFixture]
    public class ClampTest
    {
        [Test]
        public void Clamp_Close_Works()
        {
            Clamp clamp = new Clamp();
            clamp.Close();
            Assert.AreEqual(ClampStatus.Closed, clamp.Status);  // State-based testing (also called state verification) 
        }

        [Test]
        public void Clamp_Open_Works()
        {
            Clamp clamp = new Clamp();
            clamp.Open();
            Assert.AreEqual(ClampStatus.Open, clamp.Status);
        }
    }

}

