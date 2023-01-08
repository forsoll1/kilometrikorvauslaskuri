using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class PoistaMatka : MHToiminnot
    {
        List<Myyntiedustaja> edustajat;
        public PoistaMatka(List<Myyntiedustaja> edustajat)
        {
            base.luku = "5";
            base.kuvaus = "Poista tallennettu työmatka";
            this.edustajat = edustajat;
        }

        public override void Suorita(Myyntiedustaja edustaja)
        {
            List<Matka> lista = edustaja.getMatkat();
            if (lista.Count == 0)
            {
                Console.WriteLine("\nEi maksamattomia korvauksia");
                return;
            }
            Console.WriteLine("");
            while (true)
            {
                Funktiot.ListaaMatkat(edustaja);
                Console.WriteLine("\nAnna poistettavaa työmatkaa vastaava numero (tyhjä syöte poistuu): ");
                string valinta = Console.ReadLine();
                if (valinta.Length == 0)
                {
                    break;
                }

                int numero;
                while (!int.TryParse(valinta, out numero) || numero < 1 || numero > lista.Count)
                {
                    Console.WriteLine("Valitse jokin listan numeroista");
                    valinta = Console.ReadLine();
                    if (valinta.Length == 0) { return; }
                }
                
                edustaja.addKorvaus(-1*(lista[numero - 1].getKilometrikorvaus() + lista[numero - 1].getPaivaraha()));
                lista.RemoveAt(numero - 1);
                Tallennus.TallennaTiedostoon(edustajat);
                continue;
            }
        }
    }
}
