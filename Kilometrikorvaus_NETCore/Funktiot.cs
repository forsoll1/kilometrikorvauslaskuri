using Kilometrikorvaus_NETCore.Valikot;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kilometrikorvaus_NETCore
{
    public static class Funktiot
    {

        public static void ListaaEdustajat(List<Myyntiedustaja> Myyntiedustajat)
        {
            Console.WriteLine("");
            if (Myyntiedustajat.Count == 0)
            {
                Console.WriteLine("Ei tallennettuja myyntiedustajia\n");
                return;
            }
            int counter = 1;
            foreach (var edustaja in Myyntiedustajat)
            {
                Console.WriteLine(counter + " - " + edustaja.getNimi());
                counter++;
            }
            Console.WriteLine("");
        }
        public static void ListaaMatkat(Myyntiedustaja edustaja)
        {
            int counter = 1;
            foreach (Matka matka in edustaja.getMatkat())
            {
                Console.WriteLine(counter + "  " + matka.getTiedot());
                counter++;
            }
        }

        // Syötteiden/muuttujien tarkistuksia

        public static double isDouble(string optionalstring = "Epäkelpo syöte, yritä uudelleen")
        {
            string input = Console.ReadLine();
            double output;

            while (!Double.TryParse(input, out output))
            {
                Console.WriteLine(optionalstring);
                input = Console.ReadLine();
            }
            return output;
        }
        public static string dateCheck()
        {
            string vastaus = Console.ReadLine();
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy","dd/M/yyyy","d/MM/yyyy" };
            var ci = new CultureInfo("fr-FR");
            while (!DateTime.TryParseExact(vastaus, formats, ci, DateTimeStyles.None, out _))
            {
                Console.WriteLine("Epäkelpo syöte, yritä uudelleen (esimerkkimuoto: 12/2/2009");
                vastaus = Console.ReadLine();
            }
            return vastaus;
        }
        public static string timeCheck()
        {
            string vastaus = Console.ReadLine();

            Regex regex = new Regex(@"^[0-2]{0,1}[0-9]\:[0-5]{0,1}[0-9]$");

            Match match = regex.Match(vastaus);
            while (true)
            {
                while (!match.Success)
                {
                    Console.WriteLine("Epäkelpo kellonaika, yritä uudelleen (esimerkki: 18:00) ");
                    vastaus = Console.ReadLine();
                    match = regex.Match(vastaus);
                }

                string[] jako = vastaus.Split(":");
                string yhdistelma = jako[0] + jako[1];

                if (Int32.Parse(yhdistelma)>2400)
                {
                    Console.WriteLine("Epäkelpo kellonaika, yritä uudelleen (esimerkki: 18:00) ");
                    vastaus = Console.ReadLine();
                    continue;
                }
                break;
            }
            
            return vastaus;
        }
        public static bool LahtoAiemminKuinPaluu(string lahto, string paluu)
        {
            string[] lahto_split = lahto.Split(":");
            string[] paluu_split = paluu.Split(":");

            if (Int32.Parse(lahto_split[0] + lahto_split[1]) > Int32.Parse(paluu_split[0] + paluu_split[1]))
            {
                return false;
            }
            return true;

        }
    }
}
