using CalculatorEX.App;

namespace CalculatorTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void EvalTest()
        {
            var calc = new Calc(new MenuResources());
            Assert.IsNotNull(calc.EvalExpression("XI + IV"));
            Assert.AreEqual(new RomanNumber(10), calc.EvalExpression("XI - I"));
            Assert.ThrowsException<ArgumentException>(() => calc.EvalExpression("2 + 3"));
        }
    }
}
