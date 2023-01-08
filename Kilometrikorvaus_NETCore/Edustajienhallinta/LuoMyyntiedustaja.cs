using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Edustajienhallinta
{
    class LuoMyyntiedustaja : EHToiminnot
    {

        List<Myyntiedustaja> edustajat = new List<Myyntiedustaja>();

        public LuoMyyntiedustaja(List<Myyntiedustaja> edustajat)
        {
            base.kuvaus = "Luo myyntiedustaja";
            base.luku = "1";
            this.edustajat = edustajat;
        }
        public override void Suorita()
        {
            // Edustajien luonti on hyvin yksinkertaista ja vaatii vain nimen syöttämisen. Luotu objekti lisätään pääohjelman myyntiedustajat-listaan. 

            Console.WriteLine("\nAnna myyntiedustajan nimi (tyhjä syöte poistuu edelliseen valikkoon)");
            string nimi = Console.ReadLine();

            if (nimi.Length == 0)
            {
                return;
            }
            else
            {
                edustajat.Add(new Myyntiedustaja(nimi));
                Tallennus.TallennaTiedostoon(edustajat);
                Console.WriteLine("Myyntiedustaja luotu!\n");
            }
        }
    }
}
