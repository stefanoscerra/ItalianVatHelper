using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItalianVatHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Italian VAT validator & generator\n");

            long MAX = (long)Math.Pow(10, 10);
            Random r = new Random();
            long random = (long)(MAX * r.NextDouble());
            string format = new string('0', 10);
            string paddedRandom = random.ToString(format);

            int checkDigit = ItalianVatHelper.CalcCheckDigit(paddedRandom);
            string vat = paddedRandom + checkDigit;

            Console.WriteLine("Partita IVA: " + vat);
            bool valid = ItalianVatHelper.VerifyCheckDigit(vat);
            Console.WriteLine("Validity check: " + (valid ? "OK" : "Not valid"));

            Console.WriteLine("\nPress a key to exit...");
            Console.ReadKey();
        }
        
    }
}
