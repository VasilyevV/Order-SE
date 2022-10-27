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
            var number = 156.256;
            var expected_result = "сто пятьдесят шесть";

            string result = NumberToWords.ToWords(number);

            Assert.That(result, Is.EqualTo(expected_result));
        }

    }
}