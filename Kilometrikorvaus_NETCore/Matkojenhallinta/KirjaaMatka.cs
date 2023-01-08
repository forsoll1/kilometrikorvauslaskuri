using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class KirjaaMatka : MHToiminnot
    {
        List<Myyntiedustaja> edustajat;
        public KirjaaMatka(List<Myyntiedustaja> edustajat)
        {
            base.luku = "1";
            base.kuvaus = "Kirjaa uusi matka";
            this.edustajat = edustajat;
        }

        public override void Suorita(Myyntiedustaja edustaja)
        {
            // Valmiina vuoden 2021 korvaukset. Voidaan muuttaa matkakohtaisesti
            double kk = 0.44;
            double puoliPR = 20;
            double kokoPR = 44;

            string pvm;
            string lahtoAika;
            string paluuAika;
            double kilometrit;

            Console.WriteLine("Oletusarvona vuoden 2021 korvaukset: Kilometrikorvaus {0} e/kk, Puolipäiväraha {1}e, Päiväraha {2}e", kk, puoliPR, kokoPR);
            Console.WriteLine("Haluatko muuttaa käytössä olevat korvaukset? K/E");
            string vastaus = Console.ReadLine().ToLower();
            if (vastaus == "k")
            {
                MuutaKorvaukset(kk, puoliPR, kokoPR, out kk, out puoliPR, out kokoPR);
            }
            // Pyydetään antamaan matkaa koskevat tiedot. Syötteiden muoto tarkastetaan, jos syöte on vääränlainen pyydetään uusi. 
            // Tarkistetaan myös, että lähtöaika ei ole paluuaikaa myöhemmin

            Console.WriteLine("\nAnna työmatkan päivämäärä (esim. 12/3/2012)");
            pvm = Funktiot.dateCheck();
            Console.WriteLine("\nAnna lähtöaika (esim. 7:00): ");
            lahtoAika = Funktiot.timeCheck();
            Console.WriteLine("\nAnna paluuaika (esim. 18:00): ");
            paluuAika = Funktiot.timeCheck();
            bool check = Funktiot.LahtoAiemminKuinPaluu(lahtoAika, paluuAika);
            if (!check)
            {
                Console.WriteLine("Lähtöajan täytyy olla paluuaikaa pienempi. Matkaa ei kirjattu. ");
                return;
            }
            Console.WriteLine("\nAnna ajetut kilometrit: ");
            kilometrit = Funktiot.isDouble();

            // Luodaan tietojen pohjalta uusi Matka-objekti, joka lisätään valittuna olevan myyntiedustajan matkat-listaan. Samalla matkasta kertyneet korvaukset lisätään edustajan tietoihin. 

            Matka uusi = new Matka(kilometrit, kk, lahtoAika, paluuAika, kokoPR, puoliPR, pvm);
            edustaja.addMatka(uusi);
            Tallennus.TallennaTiedostoon(edustajat);

            Console.WriteLine("\nKirjatun työmatkan tiedot: ");
            Console.WriteLine(uusi.getTiedot());
            Console.WriteLine("Palataan valikkoon...");

        }
        private void MuutaKorvaukset(double kk_v, double puoliPR_v, double kokoPR_v, out double kk, out double puoliPR, out double kokoPR)
        {
            Console.WriteLine("\nAnna uusi kilometrikorvauksen arvo (nykyinen: {0}): ", kk_v);
            kk = Funktiot.isDouble("Epäkelpo syöte, yritä uudelleen (esim. 0,55): ");

            Console.WriteLine("\nAnna uusi puolipäivärahan arvo (nykyinen {0}): ", puoliPR_v);
            puoliPR = Funktiot.isDouble("Epäkelpo syöte, yritä uudelleen (esim. 22): ");

            Console.WriteLine("\nAnna uusi päivärahan arvo (nykyinen: {0}): ", kokoPR_v);
            kokoPR = Funktiot.isDouble("Epäkelpo syöte, yritä uudelleen (esim. 35): ");

            Console.WriteLine("Korvauksien arvot muutettu \n");
        }
    }
}
