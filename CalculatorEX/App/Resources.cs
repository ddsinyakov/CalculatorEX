using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public static class Resources
    {
        public static string Culture = "en-US";

        public static String GetInvalidCharMessage(char c)
            => $"Invalid char '{c}'";

        public static String GetInvalidTypeMessage(int d, String type)
            => $"obj{d}: type '{type}' not supported";

        public static String GetMisplacedNMessage()
            => "'N' is not allowed in context";

        public static String GetEmptyStringMessage(string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => "Порожній рядок неприпустимий",
                "en-US" => "Empty string not allowed",
                _ => throw new ArgumentException()
            };
    }
}
