using Kilometrikorvaus_NETCore.Matkojenhallinta;
using Kilometrikorvaus_NETCore.Valikot;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kilometrikorvaus_NETCore
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Myyntiedustaja> myyntiedustajat = new List<Myyntiedustaja>();

            if (File.Exists("kilometrikorvaus.xml"))
            {
                myyntiedustajat = Tallennus.LueTiedosto();
            }


            List<Valikko> paatoiminnot = new List<Valikko>();

            paatoiminnot.Add(new MyyntiedustajaValikko(myyntiedustajat));
            paatoiminnot.Add(new MatkojenHallinta(myyntiedustajat));
            paatoiminnot.Add(new KorvaustenKoonti(myyntiedustajat));   

            string syote;
            do
            {
                ValikkoTeksti(paatoiminnot);
                syote = Console.ReadLine();
                foreach (Valikko toiminto in paatoiminnot)
                {
                    if (syote.Equals(toiminto.luku))
                    {
                        toiminto.Avaa();
                    }
                }
            } while (!syote.Equals(""));
            static void ValikkoTeksti(List<Valikko> paatoiminnot)
            {
                Console.WriteLine("\nPäävalikko\n");
                Console.WriteLine("Syötä toimintoa vastaava luku (tyhjä syöte poistuu ohjelmasta)\n");
                foreach (Valikko x in paatoiminnot)
                {
                    Console.WriteLine("{0} - {1}", x.luku, x.kuvaus);
                }
            }
        }
    }
}
