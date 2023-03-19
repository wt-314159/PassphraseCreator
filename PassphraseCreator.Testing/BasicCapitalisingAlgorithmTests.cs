using PassphraseCreator.Capitalisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator.Testing
{
    [TestClass]
    public class BasicCapitalisingAlgorithmTests
    {
        [TestMethod]
        public void RandomlyCapitaliseTest()
        {
            var testString = "ThIsAtEsT";
            var lower = testString.ToLower();
            var upper = testString.ToUpper();
            var camel = char.ToUpper(testString.First()) + testString.Substring(1).ToLower();

            var capAlgo = BasicCapitalisingAlgorithm.Instance;
            var lowerRandom = capAlgo.RandomlyCapitalise(testString, x => 0);
            var upperRandom = capAlgo.RandomlyCapitalise(testString, x => 1);
            var camelRandom = capAlgo.RandomlyCapitalise(testString, x => 2);

            Assert.AreEqual(lower, lowerRandom);
            Assert.AreEqual(upper, upperRandom);
            Assert.AreEqual(camel, camelRandom);
        }
    }
}
