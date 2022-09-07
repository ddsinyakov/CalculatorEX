using CalculatorEX.App;

namespace CalculatorTests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void TestCalc()
        {
            var calc = new Calc();

            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.Parse("I"), 1, "I == 1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV == 4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("LV"), 55);
            Assert.AreEqual(RomanNumber.Parse("XL"), 40);
            //Assert.AreEqual(RomanNumber.Parse("XLCM"), 40);
        }

        [TestMethod]
        public void RomanNumberParseAllowN()
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));
            // проверка на N
        }

        [TestMethod]
        public void RomanNumberParseNotAllowN()
        {
            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XNX"); });
            var exp = new ArgumentException("N is not allowed in context");
            Assert.AreEqual(exp.Message, exp.Message);
            // проверка на запрет N
        }
    }
}