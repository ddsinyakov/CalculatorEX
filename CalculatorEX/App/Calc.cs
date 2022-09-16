using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class Calc
    {
        public MenuResources Resources { get; set; }

        public Calc(MenuResources resources)
        {
            Resources = resources;
        }

        private void AskLang()
        {
            // Ask user for language
            while (true)
            {
                Console.Write(Resources.AskLang());
                var lang = Console.ReadLine();

                // Evaluate choosen language
                if (lang == "1")
                {
                    Resources.Culture = "en-US";
                    break;
                }
                if (lang == "2")
                {
                    Resources.Culture = "uk-UA";
                    break;
                }
            }
        }

        public void Run()
        {
            AskLang(); 
            RomanNumber res = null!;

            // repeats untill user enter valid expression
            do
            {
                // ask Expression
                Console.Write(Resources.InputExpression());
                // user input expression
                String? userInput = Console.ReadLine() ?? "";   

                try
                {
                    // evaluate expression
                    res = EvalExpression(userInput);        
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (res is null);

            // Show result
            Console.WriteLine(Resources.Result(res));
        }

        public RomanNumber EvalExpression(String expression)
        {
            // split expression on two numbers and operation
            String[] parts = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // expression is invalid
            if (parts.Length != 3)                                                              
                throw new ArgumentException(Resources.GetInvalidExpressionMessage(expression));

            // operation is invalid
            if (Array.IndexOf(RomanNumber.Operations, parts[1]) == -1)                          
                throw new ArgumentException(Resources.GetInvalidOperationMessage(parts[1]));    
                                                                                
            RomanNumber rn1 = new RomanNumber(RomanNumber.Parse(parts[0]));     // build roman number 1
            RomanNumber rn2 = new RomanNumber(RomanNumber.Parse(parts[2]));     // build roman number 2
            RomanNumber res = parts[1] == RomanNumber.Operations[0]             // counts result of expression
                ? rn1.Add(rn2)
                : rn1.Sub(rn2);

            return res;
        }
    }
}
