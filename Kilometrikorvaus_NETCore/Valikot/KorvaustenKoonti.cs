using Kilometrikorvaus_NETCore.Raportointi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Valikot
{
    class KorvaustenKoonti : Valikko
    {
        private List<Myyntiedustaja> myyntiedustajat;

        public KorvaustenKoonti(List<Myyntiedustaja> edustajat)
        {
            base.luku = "3";
            base.kuvaus = "Matkakorvausten koonti";
            this.myyntiedustajat = edustajat;
        }

        public override void Avaa()
        {
            if (!OnkoMatkoja())
            {
                Console.WriteLine("\nEi tarkasteltavia matkakorvauksia");
                return;
            }

            List<int> vuodet = HaeVuodet();

            List<KKToiminnot> toiminnot = new List<KKToiminnot>();
            toiminnot.Add(new MaksamattomatKorvauksetYhteensa(myyntiedustajat));
            toiminnot.Add(new VuosittaisetKorvaukset(myyntiedustajat, vuodet));
            toiminnot.Add(new EdustajienVuotuisetKorvaukset(myyntiedustajat, vuodet));

            string syote;
            do
            {
                ValikkoTeksti(toiminnot);
                syote = Console.ReadLine();
                foreach (KKToiminnot toiminto in toiminnot)
                {
                    if (syote.Equals(toiminto.Luku))
                    {
                        toiminto.Suorita();
                    }
                }
            } while (!syote.Equals(""));
        }

        public bool OnkoMatkoja()
        {
            int matkoja = 0;
            foreach (Myyntiedustaja x in myyntiedustajat)
            {
                if (x.getMatkat().Count > 0) { matkoja++; }
            }
            if (matkoja > 0) { return true; }
            return false;
        }

        public List<int> HaeVuodet()
        {
            List<int> vuodet = new List<int>();
            foreach (var x in myyntiedustajat)
            {
                foreach (var y in x.getMatkat())
                {
                    int vuosi = y.getTag();
                    if (vuodet.Contains(vuosi))
                    {
                        continue;
                    }
                    else
                    {
                        vuodet.Add(vuosi);
                    }
                }
            }
            vuodet.Sort();
            return vuodet;
        }

        private void ValikkoTeksti(List<KKToiminnot> toiminnot)
        {
            Console.WriteLine("\nKorvausten raportointi\n");
            Console.WriteLine("Valitse toiminto (tyhjä syöte poistuu alkuvalikkoon)\n");
            foreach (KKToiminnot x in toiminnot)
            {
                Console.WriteLine("{0} - {1}", x.Luku, x.Kuvaus);
            }
        }
    }
}
