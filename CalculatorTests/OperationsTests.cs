﻿using CalculatorEX.App;

namespace CalculatorTests
{
    [TestClass]
    public class OperationsTests
    {

        [TestMethod]
        public void AddRomanNumber()
        {
            var rn7 = new RomanNumber(7);
            var rn2 = new RomanNumber(2);
            var rn4 = new RomanNumber(4);
            var rn9 = new RomanNumber(9);
            var rn11 = new RomanNumber(11);
            var rn20 = new RomanNumber(20);
            var rn_2 = new RomanNumber(-2);
            var rn_4 = new RomanNumber(-4);
            var rn_9 = new RomanNumber(-9);

            // Positive
            Assert.AreEqual(9, rn7.Add(rn2).Value);
            Assert.AreEqual(11, rn7.Add(rn4).Value);

            // Negative
            Assert.AreEqual(5, rn7.Add(rn_2).Value);
            Assert.AreEqual(3, rn7.Add(rn_4).Value);

            // Negative at first
            Assert.AreEqual(-7, rn_9.Add(rn2).Value);
            Assert.AreEqual(-13, rn_9.Add(rn_4).Value);
            Assert.AreEqual(2, rn_9.Add(rn11).Value);
            Assert.AreEqual(2, rn_9.Add(rn11).Value);

            // Zero and new
            Assert.AreEqual(7, rn7.Add(new RomanNumber()).Value);
            Assert.AreEqual(7, rn7.Add(new RomanNumber(0)).Value);
            Assert.AreEqual(17, rn7.Add(new RomanNumber(10)).Value);

            // With self
            Assert.AreEqual(14, rn7.Add(rn7).Value);

            // Compare to RomanNumber
            Assert.AreEqual(rn9, rn7.Add(rn2));
            Assert.AreEqual(rn20, rn9.Add(rn11));

            // Compare to string
            Assert.AreEqual("XV", rn11.Add(rn4).ToString());
            Assert.AreEqual("VII", rn11.Add(rn_4).ToString());
            Assert.AreEqual("-II", rn7.Add(rn_9).ToString());
        }

        [TestMethod]
        public void AddThrowException()
        {
            var exc = Assert.ThrowsException<ArgumentNullException>(() => new RomanNumber(10).Add((RomanNumber)null!));

            // Test if exception.Message is "Null attribute is not possible"
            var exp = new ArgumentNullException("Null attribute is not possible");
            Assert.AreEqual(exp.Message, exc.Message);
        }

        [TestMethod]
        public void AddInteger()
        {
            var rn = new RomanNumber(10);

            Assert.AreEqual(20, rn.Add(10).Value);
            Assert.AreEqual("V", rn.Add(-5).ToString());
            Assert.AreEqual(rn, rn.Add(0));
        }

        [TestMethod]
        public void AddString()
        {
            var rn = new RomanNumber(10);

            Assert.AreEqual(30, rn.Add("XX").Value);
            Assert.AreEqual("-XL", rn.Add("-L").ToString());

            // Test invalid arguments
            Assert.ThrowsException<ArgumentException>(() => rn.Add(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("-"));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("10"));
            Assert.ThrowsException<ArgumentNullException>(() => rn.Add((String) null!));
        }

        [TestMethod]
        public void AddStatic()
        {
            RomanNumber rn5 = RomanNumber.Add(2, 3);
            RomanNumber rn8 = RomanNumber.Add(rn5, 3);
            RomanNumber rn10 = RomanNumber.Add("I", "IX");
            RomanNumber rn9 = RomanNumber.Add(rn5, "IV");
            RomanNumber rn13 = RomanNumber.Add(rn5, rn8);

            // test static RomanNumber.Add
            Assert.AreEqual(5, rn5.Value);
            Assert.AreEqual(8, rn8.Value);
            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(9, rn9.Value);
            Assert.AreEqual(13, rn13.Value);
        }

        [TestMethod]
        public void AddStaticThrowException()
        {
            var rn = new RomanNumber(10);

            // ArgumentNullException

            // int + int
            Assert.IsNotNull(RomanNumber.Add(2, 3));

            // RomanNumber + int
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add(null!, 3));

            // RomanNumber + RomanNumber
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add(null!, rn));

            //string + string
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((string)null!, null!));

            // RomanNumber + string
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add(rn, (string) null!));
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((RomanNumber) null!, "IX"));
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((RomanNumber)null!, (string)null!));

            // ArgumentException 

            // string + string
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("", ""));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("A", "X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("XA", "A"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("X", "A"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("X", "XA"));

            // RomanNumber + string
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add(rn, ""));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add(rn, "A"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add(rn, "XXA"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add(rn, "XAX"));

        }
    }
}
