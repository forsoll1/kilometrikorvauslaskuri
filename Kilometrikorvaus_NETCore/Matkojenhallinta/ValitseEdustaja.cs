using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class ValitseEdustaja : MHToiminnot
    {
        List<Myyntiedustaja> edustajat;
        public Myyntiedustaja valittu_edustaja { get; set; }
        public ValitseEdustaja(List<Myyntiedustaja> edustajat)
        {
            base.luku = "6";
            base.kuvaus = "Valitse uusi myyntiedustaja";
            this.edustajat = edustajat;
        }

        public override void Suorita(Myyntiedustaja edustaja)
        {
            {
                Console.WriteLine("\nValitse myyntiedustaja: ");
                Funktiot.ListaaEdustajat(edustajat);
                string valinta = Console.ReadLine();
                int numero;
                while (!int.TryParse(valinta, out numero) || numero < 1 || numero > edustajat.Count)
                {
                    Console.WriteLine("Valitse jokin listan numeroista");
                    valinta = Console.ReadLine();
                }
                this.valittu_edustaja = edustajat[numero - 1];
            }
        }
    }
}
