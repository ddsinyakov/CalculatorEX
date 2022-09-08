using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public record RomanNumber
    {
        public int Value { get; set; } = 0;

        public RomanNumber()
        {

        }

        public RomanNumber(int num)
        {
            Value = num;
        }


        static public int Parse(String str)
        {
            if (str is null)
                throw new ArgumentNullException();

            if (str.Length < 1)
                throw new ArgumentException("Empty string not allowed");

            if (str == "N")
                return 0;

            // if str contains N and it is not the only character throws exception
            if (str.Contains("N") && str.Length > 1)
                throw new ArgumentException("N is not allowed in context");

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitsValues = { 1, 5, 10, 50, 100, 500, 1000 };

            // get last char
            //char digit = str[str.Length - 1];
            //int index = Array.IndexOf(digits, digit);

            //if(index == -1)
            //    throw new ArgumentException($"Invalid char {digit}");

            //int val = digitsValues[index];
            //int res = val;

            int val = 0;
            int res = 0;

            // go through str from end - 1
            for (int i = str.Length - 1; i >= 0; i--)
            {
                char digit = str[i];
                int index = Array.IndexOf(digits, digit);

                // check if letter is correct
                if (index == -1)
                {
                    // check if the number is negative
                    if ( i == 0 && digit == '-')
                    {
                        res *= -1;
                        continue;
                    }

                    throw new ArgumentException($"Invalid char {digit}");
                }

                // Adds or substract value of current digit depending on previous digit
                res += digitsValues[index] < val
                    ? -digitsValues[index]
                    : digitsValues[index];
                val = digitsValues[index];
            }

            return res;
        }

        
        public override string ToString()
        {
            if(Value == 0)
            {
                return "N";
            }

            int n = Value;
            string res = "";

            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            // adds - to res if the value is negative
            if(n < 0)
            {
                n = n * -1;
                res += "-";
            }

            // go through all values array
            for(int i = 0; i < values.Length; i++)
            {
                // decrease n till n become less than current value and add that much letter to res
                while(n >= values[i])
                {
                    n -= values[i];
                    res += parts[i];
                }
            }

            return res;
        }
    }
}
