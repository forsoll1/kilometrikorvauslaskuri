using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Raportointi
{
    class EdustajienVuotuisetKorvaukset : KKToiminnot
    {
        private List<Myyntiedustaja> edustajat;
        private List<int> vuodet;

        public EdustajienVuotuisetKorvaukset(List<Myyntiedustaja> edustajat, List<int> vuodet)
        {
            base.Kuvaus = "Myyntiedustajien vuotuiset työmatkat ja kertyneet korvaukset";
            base.Luku = "3";
            this.edustajat = edustajat;
            this.vuodet = vuodet;
        }

        public override void Suorita()
        {
            Console.WriteLine("");
            foreach (var x in edustajat)
            {
                Console.WriteLine("\n");
                if (x.getMatkat().Count > 0) { Console.WriteLine("Henkilön {0} työmatkat: ", x.getNimi()); }
                double kokonaissumma = 0;
                foreach (var y in vuodet)
                {
                    double osasumma = 0;
                    int counter = 0;
                    foreach (var z in x.getMatkat())
                    {
                        if (y == z.getTag())
                        {
                            Console.WriteLine(z.getTiedot());
                            osasumma += z.getKilometrikorvaus() + z.getPaivaraha();
                            counter++;
                        }
                    }
                    if (counter > 0)
                    {
                        Console.WriteLine("Vuoden {0} korvaukset yhteensä: {1}e \n", y, Math.Round(osasumma,2));
                        kokonaissumma += osasumma;
                    }
                }
                Console.WriteLine("Henkilölle {0} kertyneet matkakorvaukset yhteensä: {1}e \n", x.getNimi(), Math.Round(kokonaissumma,2));
            }
        }
    }
}
