using Kilometrikorvaus_NETCore.Valikot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class MatkojenHallinta : Valikko
    {
        List<Myyntiedustaja> edustajat;

        public MatkojenHallinta(List<Myyntiedustaja> edustajat)
        {
            base.luku = "2";
            base.kuvaus = "Kirjaa ja käsittele edustajien työmatkoja";
            this.edustajat = edustajat;
        }
        public override void Avaa()
        {
            if (edustajat.Count == 0)
            {
                Console.WriteLine("\nEi tallennettuja myyntiedustajia.");
                return;
            }

            // Pyydetään käyttäjää valitsemaan myyntiedustajien listasta edustaja johon toiminnot kohdistuvat. 
            ValitseEdustaja valitsija = new ValitseEdustaja(edustajat);
            valitsija.Suorita(null);


            List<MHToiminnot> toiminnot = new List<MHToiminnot>();

            toiminnot.Add(new KirjaaMatka(edustajat));
            toiminnot.Add(new MaksaKorvauksia(edustajat));
            toiminnot.Add(new TulostaKorvaukset());
            toiminnot.Add(new TulostaTyomatkat());
            toiminnot.Add(new PoistaMatka(edustajat));
            toiminnot.Add(valitsija);

            string syote;
            do
            {
                ValikkoTeksti(toiminnot, valitsija.valittu_edustaja);
                syote = Console.ReadLine();
                foreach (MHToiminnot toiminto in toiminnot)
                {
                    if (syote.Equals(toiminto.luku))
                    {
                        toiminto.Suorita(valitsija.valittu_edustaja);
                    }
                }
            } while (!syote.Equals(""));
        }

        static void ValikkoTeksti(List<MHToiminnot> paatoiminnot, Myyntiedustaja valittu_edustaja)
        {
            Console.WriteLine("\nMyyntiedustajien työmatkojen kirjaus ja hallinta\n");
            Console.WriteLine("Valittu myyntiedustaja: " + valittu_edustaja.getNimi());
            Console.WriteLine("Syötä toimintoa vastaava luku (tyhjä syöte poistuu alkuvalikkoon)\n");
            foreach (MHToiminnot x in paatoiminnot)
            {
                Console.WriteLine("{0} - {1}", x.luku, x.kuvaus);
            }
        }
    }
}
