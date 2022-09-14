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
            Assert.AreEqual(1,RomanNumber.Parse("I"));
            Assert.AreEqual(5, RomanNumber.Parse("V"));
            Assert.AreEqual(10, RomanNumber.Parse("X"));
            Assert.AreEqual(50, RomanNumber.Parse("L"));
            Assert.AreEqual(100, RomanNumber.Parse("C"));
            Assert.AreEqual(500, RomanNumber.Parse("D"));
            Assert.AreEqual(1000, RomanNumber.Parse("M"));
        }


        [TestMethod]
        public void RomanNumberParse2Digits()
        {
            // Check if RomanNumber.Parse works with 2 simbols
            Assert.AreEqual(4, RomanNumber.Parse("IV"));
            Assert.AreEqual(15, RomanNumber.Parse("XV"));
            Assert.AreEqual(900, RomanNumber.Parse("CM"));
            Assert.AreEqual(400, RomanNumber.Parse("CD"));
            Assert.AreEqual(55, RomanNumber.Parse("LV"));
            Assert.AreEqual(40, RomanNumber.Parse("XL"));
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
            var exp = new ArgumentException(ExceptionResources.GetMisplacedNMessage());
            Assert.AreEqual(exp.Message, exc.Message);
            // проверка на запрет N
        }

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            // Check if RomanNumber.Parse works with 3+ simbols 
            Assert.AreEqual(30, RomanNumber.Parse("XXX"));
            Assert.AreEqual(401, RomanNumber.Parse("CDI"));
            Assert.AreEqual(1999, RomanNumber.Parse("MCMXCIX"));
        }

        [TestMethod]
        public void RomanNumberParseInvalid()
        {
            // Check if invalid simbol at first place in argument of RomanNumber.Parse throws ArgumentException
            var exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("AXX"));

            // Check if invalid simbol at first place in argument of RomanNumber.Parse throws exception with "Invalid char A" message
            var exp = new ArgumentException(ExceptionResources.GetInvalidCharMessage('A'));
            Assert.AreEqual(exp.Message, exc.Message);

            // Same for invalid simbol in the middle
            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XAX"));
            Assert.AreEqual(exp.Message, exc.Message);

            // Same for invalid simbol at last place
            exc = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XXA"));
            Assert.AreEqual(exp.Message, exc.Message);

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
            var exp = new ArgumentException(ExceptionResources.GetEmptyStringMessage());
            Assert.AreEqual(exp.Message, exc.Message);

            // Check if RomanNumber.Parse with null argument throws ArgumentNullException
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }

        [TestMethod]
        public void RomanNumberCtor()
        {
            // Check if constructor of RomanNumber works
            RomanNumber romanNumber = new RomanNumber();
            Assert.IsNotNull(romanNumber);

            // Check if constructor with string argument of RomanNumber works 
            romanNumber = new(10);
            Assert.IsNotNull(romanNumber);

            romanNumber = new(0);
            Assert.IsNotNull(romanNumber);
        }

        [TestMethod]
        public void RomanNumberToString()
        {
            // Check RomanNumber.ToString method
            RomanNumber romanNumber = new RomanNumber();
            Assert.AreEqual("N", romanNumber.ToString());

            romanNumber = new RomanNumber(10);
            Assert.AreEqual("X", romanNumber.ToString());

            romanNumber = new RomanNumber(90);
            Assert.AreEqual("XC", romanNumber.ToString());

            romanNumber = new RomanNumber(20);
            Assert.AreEqual("XX", romanNumber.ToString());

            romanNumber = new RomanNumber(1999);
            Assert.AreEqual("MCMXCIX", romanNumber.ToString());
        }

        [TestMethod]
        public void RomanNumberToStringParseCrossTest()
        {
            // Check if RomanNumber.Parse and RomanNumber.ToString works opposite to each other
            RomanNumber num = new();
            for(int n = 0; n< 2022; n++)
            {
                num.Value = n;
                Assert.AreEqual(n, RomanNumber.Parse(num.ToString()));
            }
        }

        [TestMethod]
        public void RomanNumberTypeTest()
        {
            // Check if RomanNumber is reference type
            Assert.IsFalse(typeof(RomanNumber).IsValueType);

            // Check if RomanNumbers with different values are same, but with diferent refferences
            RomanNumber a = new RomanNumber(10);
            RomanNumber b = a with { };
            Assert.AreNotSame(a, b);
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);

            // Check if RomanNumbers with different values are not the same and with diferent refferences
            RomanNumber c = a with { Value = 20 };
            Assert.AreNotSame(a, c);
            Assert.AreNotEqual(a, c);
            Assert.IsFalse(a == c);
        }

        [TestMethod]
        public void RomanNumberNegativeParsing()
        {
            Assert.AreEqual(-10, RomanNumber.Parse("-X"));
            Assert.AreEqual(-1999, RomanNumber.Parse("-MCMXCIX"));
            Assert.AreEqual(-900, RomanNumber.Parse("-CM"));
            Assert.AreEqual(-400, RomanNumber.Parse("-CD"));
            // testing of negative parsing
        }

        [TestMethod]
        public void RomanNumberNegativeToString()
        {
            RomanNumber romanNumber = new RomanNumber();
            Assert.AreEqual("N", romanNumber.ToString());

            romanNumber = new RomanNumber(-10);
            Assert.AreEqual("-X", romanNumber.ToString());

            romanNumber = new RomanNumber(-90);
            Assert.AreEqual("-XC", romanNumber.ToString());

            romanNumber = new RomanNumber(-20);
            Assert.AreEqual("-XX", romanNumber.ToString());

            romanNumber = new RomanNumber(-1999);
            Assert.AreEqual("-MCMXCIX", romanNumber.ToString());
            // testing of negative numbers to string
        }

        // Check if RomanNumber.Parse throws Exception with - in argument not at first place
        [TestMethod]
        public void RomanNumberNegativeException()
        {
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("M-CM"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("M-"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("-"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("-N"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("--X"));
        }
    }
}