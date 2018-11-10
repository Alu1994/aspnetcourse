using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreOfBuild.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NaoConsigoLerNada()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void NaoConsigoLerNada2()
        {
            Assert.IsTrue(true);
        }
    }
}
