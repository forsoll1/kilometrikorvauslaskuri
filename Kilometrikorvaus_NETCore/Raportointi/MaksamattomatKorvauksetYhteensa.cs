using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Raportointi
{
    public class MaksamattomatKorvauksetYhteensa : KKToiminnot
    {
        List<Myyntiedustaja> edustajat;

        public MaksamattomatKorvauksetYhteensa(List<Myyntiedustaja> edustajat) 
        {
            base.Kuvaus = "Tämänhetkiset maksamattomat korvaukset yhteensä";
            base.Luku = "1";
            this.edustajat = edustajat;
        }

        public override void Suorita()
        {
            double summa = 0;
            foreach (var x in edustajat)
            {
                summa += x.getMaksamattomat();
            }
            Console.WriteLine("\nTämänhetkiset maksamattomat korvaukset: {0} euroa", Math.Round(summa,2));
        }
    }
}
