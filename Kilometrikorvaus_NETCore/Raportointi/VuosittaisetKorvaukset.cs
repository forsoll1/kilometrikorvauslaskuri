using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Raportointi
{
    public class VuosittaisetKorvaukset : KKToiminnot
    {
        private List<Myyntiedustaja> edustajat;
        private List<int> vuodet;

        public VuosittaisetKorvaukset(List<Myyntiedustaja> edustajat, List<int> vuodet)
        {
            base.Kuvaus = "Vuosittain kertyneet korvaukset";
            base.Luku = "2";
            this.edustajat = edustajat;
            this.vuodet = vuodet;
        }

        public override void Suorita()
        {
            Console.WriteLine("");
            foreach (var x in vuodet)
            {
                double vuosi_summa = 0;
                foreach (var y in edustajat)
                {
                    foreach (var z in y.getMatkat())
                    {
                        if (x == Convert.ToInt32(z.getTag()))
                        {
                            vuosi_summa += z.getKilometrikorvaus() + z.getPaivaraha();
                        }
                    }
                }
                Console.WriteLine("Vuonna {0} kertyneet korvaukset: {1} euroa", x, Math.Round(vuosi_summa,2));
            }
        }
    }
}
