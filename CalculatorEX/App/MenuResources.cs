using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        // ask for input expression
        public String InputExpression(string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Введіть Вираз -> ",
                "en-US" => $"Input Expression -> ",
                _ => throw new ArgumentException()
            };

        // throws invalid expression message
        public String GetInvalidExpressionMessage(string expression, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Неприпустимий Вираз",
                "en-US" => $"Invalid Expression: {expression}",
                _ => throw new ArgumentException()
            };

        // throws invalid operation message
        public String GetInvalidOperationMessage(string operation, string? culture = null)
            => (culture ?? Culture) switch
            {
                "uk-UA" => $"Неприпустима Операція {operation}",
                "en-US" => $"Invalid Operation: {operation}",
                _ => throw new ArgumentException()
            };
    }
}
