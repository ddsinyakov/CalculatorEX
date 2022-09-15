using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    // template outputs for menu
    public class MenuResources
    {
        // localization setting
        public string Culture = "en-US";

        // choose language 
        public String AskLang()
             => "Choose language / Оберіть мову\n    1: English\n    2: Українська\n    -> ";

        // write number 
        public String Number(int number, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Римське число #{number}: ",
                "en-US" => $"Roman number #{number}: ",
                _ => throw new ArgumentException()
            };

        // show result
        public String Result(RomanNumber res, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Результат -> {res} / {res.Value}",
                "en-US" => $"Result -> {res} / {res.Value}",
                _ => throw new ArgumentException()
            };
    }
}
