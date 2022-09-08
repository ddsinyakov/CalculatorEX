using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class Calc
    {
        public void Run()
        {
            Console.WriteLine("Calculator is running");

            var n = new RomanNumber(90);
            Console.WriteLine(n);
            if (n.ToString() == "XC") Console.WriteLine("Hello");
        }
    }
}
