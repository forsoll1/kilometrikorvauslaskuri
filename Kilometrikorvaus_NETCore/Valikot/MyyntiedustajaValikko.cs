using Kilometrikorvaus_NETCore.Edustajienhallinta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Valikot
{
    public class MyyntiedustajaValikko : Valikko
    {
        private List<Myyntiedustaja> myyntiedustajat;

        public MyyntiedustajaValikko(List<Myyntiedustaja> edustajat)
        {
            base.luku = "1";
            base.kuvaus = "Tallenna/poista myyntiedustajia";
            this.myyntiedustajat = edustajat;
        }

        public override void Avaa()
        {
            List<EHToiminnot> toiminnot = new List<EHToiminnot>();
            toiminnot.Add(new LuoMyyntiedustaja(myyntiedustajat));
            toiminnot.Add(new PoistaEdustaja(myyntiedustajat));
            toiminnot.Add(new ListaaEdustajat(myyntiedustajat));

            string syote;
            do
            {
                ValikkoTeksti(toiminnot);
                syote = Console.ReadLine();
                foreach (EHToiminnot toiminto in toiminnot)
                {
                    if (syote.Equals(toiminto.luku))
                    {
                        toiminto.Suorita();
                    }
                }
            } while (!syote.Equals(""));
        }

        private void ValikkoTeksti(List<EHToiminnot> toiminnot)
        {
            Console.WriteLine("\nTallenna tai poista myyntiedustajia\n");
            Console.WriteLine("Valitse toiminto (tyhjä syöte poistuu alkuvalikkoon)\n");
            foreach (EHToiminnot x in toiminnot)
            {
                Console.WriteLine("{0} - {1}", x.luku, x.kuvaus);
            }
        }
    }
}
