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
            // Check if RomanNumber.Parse works with 1 simbols
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
            // Check if RomanNumber.Parse works with 2 simbols
            Assert.AreEqual(RomanNumber.Parse("IV"), 4);
            Assert.AreEqual(RomanNumber.Parse("XV"), 15);
            Assert.AreEqual(RomanNumber.Parse("CM"), 900);
            Assert.AreEqual(RomanNumber.Parse("CD"), 400);
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

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            // Check if RomanNumber.Parse works with 3+ simbols 
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30);
            Assert.AreEqual(RomanNumber.Parse("CDI"), 401);
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999);
        }

        [TestMethod]
        public void RomanNumberParseInvalid()
        {
            // Check if invalid simbol at first place in argument of RomanNumber.Parse throws ArgumentException
            var exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("AXX"));

            // Check if invalid simbol at first place in argument of RomanNumber.Parse throws exception with "Invalid char A" message
            var exp = new ArgumentException("Invalid char A");
            Assert.AreEqual(exp.Message, exp.Message);

            // Same for invalid simbol in the middle
            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XAX"));
            Assert.AreEqual(exp.Message, exp.Message);

            // Same for invalid simbol at last place
            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XXA"));
            Assert.AreEqual(exp.Message, exp.Message);

            // Check if exception message starts with "Invalid char"
            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("X X"));
            Assert.IsTrue(exp.Message.StartsWith("Invalid char"));
        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            // Check if RomanNumber.Parse with empty string argument throws an ArgumentException 
            var exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(""));

            // Check if RomanNumber.Parse with empty string argument exception message is equal "Empty string not allowed"
            var exp = new ArgumentException("Empty string not allowed");
            Assert.AreEqual(exc.Message, exp.Message);

            // Check if RomanNumber.Parse with null argument throws ArgumentNullException
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }
    }
}