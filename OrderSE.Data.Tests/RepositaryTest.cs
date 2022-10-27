using NUnit.Framework;
using OrderSE.Data;

namespace OrderSE.Data.Test
{
    [TestFixture]
    public class RepositaryTest
    {
        [Test]
        public void NumberToWordsTest()
        {
            var number = 156;
            var expected_result = "סעמ ןÿעüהוסÿע רוסעü";

            string result = NumberToWords.ToWords(number);

            Assert.That(result, Is.EqualTo(expected_result));
        }

    }
}