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
        public void RomanNumberParse1Digits()
        {
            Assert.AreEqual(RomanNumber.Parse("I"), 1);
            Assert.AreEqual(RomanNumber.Parse("V"), 5);
            Assert.AreEqual(RomanNumber.Parse("X"), 10);
            Assert.AreEqual(RomanNumber.Parse("L"), 50);
            Assert.AreEqual(RomanNumber.Parse("C"), 100);
            Assert.AreEqual(RomanNumber.Parse("D"), 500);
            Assert.AreEqual(RomanNumber.Parse("M"), 1000);
        }


        [TestMethod]
        public void RomanNumberParse2Digits()
        {
            Assert.AreEqual(RomanNumber.Parse("IV"), 4);
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
            Assert.AreEqual(RomanNumber.Parse("LV"), 55);
            Assert.AreEqual(RomanNumber.Parse("XL"), 40);
            Assert.AreEqual(RomanNumber.Parse("XLCM"), 40);
        }

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
        }

        [TestMethod]
        public void RomanNumberParseInvalid()
        {
            var exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("AXX"));
            var exp = new ArgumentException("Invalid char A");

            Assert.AreEqual(exp.Message, exp.Message);

            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XAX"));
            Assert.AreEqual(exp.Message, exp.Message);

            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XXA"));
            Assert.AreEqual(exp.Message, exp.Message);

            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("X X"));
            Assert.IsTrue(exp.Message.StartsWith("Invalid char"));
        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            var exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(""));
            var exp = new ArgumentException("Empty string not allowed");

            Assert.AreEqual(exc.Message, exp.Message);

            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }
    }
}