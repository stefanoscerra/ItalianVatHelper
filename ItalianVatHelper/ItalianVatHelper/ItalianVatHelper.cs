using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ItalianVatHelper
{
    public class ItalianVatHelper
    {
        public static int CalcCheckDigit(string str)
        {
            if (!Regex.IsMatch(str, @"\d{10}"))
            {
                throw new Exception("A 10 digits string is required");
            }

            var firstFiveOddIndex = str.Where((ch, i) => i % 2 == 0).Select(ch => int.Parse(ch.ToString()));
            int x = firstFiveOddIndex.Sum();

            var evenIndexDigits = str.Where((ch, i) => i % 2 != 0).Select(ch => int.Parse(ch.ToString()));
            int y = evenIndexDigits.Sum(digit =>
            {
                var result = 2 * digit;
                if (result > 9)
                {
                    result -= 9;
                }
                return result;
            });

            int t = (x + y) % 10;
            int c = (10 - t) % 10;

            return c;
        }

        public static bool VerifyCheckDigit(string vatNumber)
        {
            if (!Regex.IsMatch(vatNumber, @"\d{11}"))
            {
                throw new Exception("An 11 digits VAT number is required");
            }

            var oddIndexDigits = vatNumber.Where((ch, i) => i % 2 == 0 && i < vatNumber.Length - 1).Select(ch => int.Parse(ch.ToString()));
            int x = oddIndexDigits.Sum();
            var evenIndexDigits = vatNumber.Where((ch, i) => i % 2 != 0).Select(ch => int.Parse(ch.ToString()));
            int y = evenIndexDigits.Sum(d => 2 * d);
            int z = evenIndexDigits.Where(d => d >= 5).Count();
            int t = (x + y + z) % 10;
            int c = (10 - t) % 10;

            int checkDigit = int.Parse(vatNumber.Last().ToString());
            return checkDigit == c;
        }
    }
}
