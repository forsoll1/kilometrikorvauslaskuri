using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Edustajienhallinta
{
    public class PoistaEdustaja : EHToiminnot
    {

        List<Myyntiedustaja> edustajat = new List<Myyntiedustaja>();

        public PoistaEdustaja(List<Myyntiedustaja> edustajat)
        {
            base.kuvaus = "Poista myyntiedustaja";
            base.luku = "2";
            this.edustajat = edustajat;
        }
        public override void Suorita()
        {
            Console.WriteLine("\nTallennettujen myyntiedustajien poistaminen");
            while (true)
            {
                Funktiot.ListaaEdustajat(edustajat);

                if (edustajat.Count > 0)
                {
                    Console.WriteLine("\nAnna poistettavaa myyntiedustajaa vastaava numero (tyhjä syöte poistuu): ");
                    string valinta = Console.ReadLine();
                    if (valinta.Length == 0)
                    {
                        break;
                    }

                    int numero;
                    while (!int.TryParse(valinta, out numero) || numero < 1 || numero > edustajat.Count)
                    {
                        Console.WriteLine("Valitse jokin listan numeroista");
                        valinta = Console.ReadLine();
                    }
                    if (edustajat[numero - 1].getMatkat().Count > 0)
                    {
                        Console.WriteLine("Valitsemallesi myyntiedustajalle on kirjattu työmatkoja. Matkojen tiedot menetetään jos päätät jatkaa. Peruuta toiminto syöttämällä 'P', tyhjä syöte jatkaa");
                        string varmistus = Console.ReadLine().ToLower();
                        if (varmistus.Equals("p"))
                        {
                            continue;
                        }
                    }
                    edustajat.RemoveAt(numero - 1);
                    Tallennus.TallennaTiedostoon(edustajat);
                    continue;
                }
                break;
            }

        }
    }
}
