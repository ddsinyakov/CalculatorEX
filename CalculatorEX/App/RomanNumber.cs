using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class RomanNumber
    {
        static public int Parse(String str)
        {
            if (str is null)
                throw new ArgumentNullException();

            if (str == String.Empty)
                throw new ArithmeticException("Empty string not allowed");

            if (str == "N")
                return 0;

            if (str.Contains("N") && str.Length > 1)
            {
                throw new ArgumentException("N is not allowed in context");
            }

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitsValues = { 1, 5, 10, 50, 100, 500, 1000 };

            char digit = str[str.Length - 1];
            int index = Array.IndexOf(digits, digit);

            if(index == -1)
            {
                throw new ArgumentException($"Invalid char {digit}");
            }

            int val = digitsValues[index];
            int res = val;
 
            for (int i = str.Length - 2; i>= 0; i--)
            {
                digit = str[i];
                index = Array.IndexOf(digits, digit);

                if (index == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }

                if(digitsValues[index] < val)
                {
                    res -= digitsValues[index];
                }
                else
                {
                    val = digitsValues[index];
                    res += val;
                }
            }

            return res;
        }
    }
}
