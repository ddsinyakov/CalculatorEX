using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public static class MenuResources
    {
        public static string Culture = "en-US";
        public static String AskLang()
             => "Choose language / Оберіть мову\n    1: English\n    2: Українська\n    -> ";

        public static String Number(int number, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Римське число #{number}: ",
                "en-US" => $"Roman number #{number}: ",
                _ => throw new ArgumentException()
            };

        public static String Result(RomanNumber res, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Результат -> {res} / {res.Value}",
                "en-US" => $"Result -> {res} / {res.Value}",
                _ => throw new ArgumentException()
            };
    }
}
