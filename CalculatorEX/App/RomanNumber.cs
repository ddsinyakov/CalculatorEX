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

        public RomanNumber() { }

        public RomanNumber(int num) { Value = num; }

        #region Parse/ToString

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
                    if (i == 0 && digit == '-' && str.Length != 1)
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
            if (Value == 0)
            {
                return "N";
            }

            int n = Value;
            string res = "";

            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            // adds - to res if the value is negative
            if (n < 0)
            {
                n = n * -1;
                res += "-";
            }

            // go through all values array
            for (int i = 0; i < values.Length; i++)
            {
                // decrease n till n become less than current value and add that much letter to res
                while (n >= values[i])
                {
                    n -= values[i];
                    res += parts[i];
                }
            }

            return res;
        }

        #endregion

        #region Add 
        public RomanNumber Add(RomanNumber other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return new RomanNumber(other.Value + this.Value);
        }

        public RomanNumber Add(int other)
        {
            return Add(new RomanNumber(other));
        }

        public RomanNumber Add(string other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return Add(new RomanNumber(Parse(other)));
        }
        #endregion

        #region static Add

        public static RomanNumber Add(int first, int second) {
            var n1 = new RomanNumber(first);
            var n2 = new RomanNumber(second);
            return n1.Add(n2);
        }

        public static RomanNumber Add(RomanNumber first, RomanNumber second)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first));

            return new RomanNumber(first.Add(second));
        }

        public static RomanNumber Add(string first, string second)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first));

            var rn1 = new RomanNumber(RomanNumber.Parse(first));
            var rn2 = new RomanNumber(RomanNumber.Parse(second));

            return new RomanNumber(rn1.Add(rn2));
        }

        public static RomanNumber Add(RomanNumber first, int second)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first));

            return new RomanNumber(first.Add(second));
        }

        public static RomanNumber Add(RomanNumber first, string second)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first));

            return new RomanNumber(first.Add(second));
        }

        #endregion

        #region static Add with objects

        public static RomanNumber Add(object obj1, object obj2)
        {
            var pars = new object[] { obj1, obj2 };
            var res = new RomanNumber(0);
            RomanNumber rnI;

            for (int i = 0; i < pars.Length; i++)
            {
                if (pars[i] is null) throw new ArgumentNullException($"obj{i + 1}");

                if (pars[i] is int val) rnI = new RomanNumber(val);
                else if (pars[i] is String str) rnI = new RomanNumber(Parse(str));
                else if (pars[i] is RomanNumber rn) rnI = rn;
                else throw new ArgumentException($"obj{i + 1}: type unsupported");

                res = res.Add(rnI);
            }

            return res;
        }

        #endregion
    }
}
