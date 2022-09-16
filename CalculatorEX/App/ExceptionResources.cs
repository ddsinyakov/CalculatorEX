using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    // some template messages for errors
    public static class ExceptionResources
    {
        // localization setting
        public static string Culture = "en-US";

        public static String GetInvalidCharMessage(char c, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Неприпустимий символ '{c}'",
                "en-US" => $"Invalid char '{c}'",
                _ => throw new ArgumentException()
            };

        public static String GetInvalidTypeMessage(String type, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"obj: типу '{type}' не підтримується",
                "en-US" => $"obj: type '{type}' not supported",
                _ => throw new ArgumentException()
            };
        
        public static String GetMisplacedNMessage(string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => "'N' неприпустимий у цьому контексті",
                "en-US" => "'N' is not allowed in context",
                _ => throw new ArgumentException()
            };

        public static String GetEmptyStringMessage(string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => "Порожній рядок неприпустимий",
                "en-US" => "Empty string not allowed",
                _ => throw new ArgumentException()
            };
    }
}
