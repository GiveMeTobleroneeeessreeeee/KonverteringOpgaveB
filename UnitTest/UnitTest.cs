using KonverteringModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestSvenskeTilDanske()
        {
            var konvertdkresult = Konvertering.TilDanskeKroner(100, 0.8);
            Assert.AreEqual(125, konvertdkresult);
        }

        [TestMethod]
        public void TestDanskeTilSvenske()
        {
            var konvertdkresult = Konvertering.TilSvenskeKroner(100, 0.8);
            Assert.AreEqual(80, konvertdkresult);
        }

    }
}
