using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class Calc
    {
        public void Run()
        {
            while (true)
            {
                Console.Write(MenuResources.AskLang());
                var lang = Console.ReadLine();

                if (lang == "1")
                {
                    MenuResources.Culture = "en-US";
                    break;
                }
                else if (lang == "2")
                {
                    MenuResources.Culture = "uk-UA";
                    break;
                }

                Console.Clear();
            }

            Console.Clear();


            Console.Write(MenuResources.Number(0));
            var rn1 = new RomanNumber(RomanNumber.Parse(Console.ReadLine()!));

            Console.Write(MenuResources.Number(1));
            var rn2 = new RomanNumber(RomanNumber.Parse(Console.ReadLine()!));

            Console.WriteLine(MenuResources.Result(rn1.Add(rn2)));
        }
    }
}
