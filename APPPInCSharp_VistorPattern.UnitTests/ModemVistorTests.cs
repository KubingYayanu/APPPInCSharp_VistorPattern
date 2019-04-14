using NUnit.Framework;

namespace APPPInCSharp_VistorPattern.UnitTests
{
    [TestFixture]
    public class ModemVistorTests
    {
        private UnixModemConfigurator v;
        private HayesModem h;
        private ZoomModem z;
        private ErnieModem e;

        [SetUp]
        public void SetUp()
        {
            v = new UnixModemConfigurator();
            h = new HayesModem();
            z = new ZoomModem();
            e = new ErnieModem();
        }

        [Test]
        public void HayesForUnix()
        {
            h.Accept(v);
            Assert.AreEqual("&s1=4&D=3", h.ConfigurationString);
        }

        [Test]
        public void ZoomForUnix()
        {
            z.Accept(v);
            Assert.AreEqual(42, z.ConfigurationValue);
        }

        [Test]
        public void ErnieForUnix()
        {
            e.Accept(v);
            Assert.AreEqual("C is too slow", e.InternalPattern);
        }
    }
}