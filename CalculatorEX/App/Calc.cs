using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class Calc
    {
        public MenuResources Resources { get; set; }

        public void Run()
        {
            // Ask language
            while (true)
            {
                Console.Write(Resources.AskLang());
                var lang = Console.ReadLine();

                if (lang == "1")
                {
                    Resources.Culture = "en-US";
                    break;
                }
                else if (lang == "2")
                {
                    Resources.Culture = "uk-UA";
                    break;
                }

                Console.Clear();
            }

            Console.Clear();

            var rns = new RomanNumber?[2] { null, null }; 

            for (int i = 0; i < rns.Length; i++)
            {
                do
                {
                    try
                    {
                        Console.Write(Resources.Number(i + 1));
                        rns[i] = new RomanNumber(RomanNumber.Parse(Console.ReadLine()!));
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (rns[i] == null);
            }

            // show result
            Console.WriteLine(Resources.Result(rns[0]!.Add(rns[1]!)));
        }
    }
}
