using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class TulostaKorvaukset : MHToiminnot
    {

        public TulostaKorvaukset()
        {
            base.luku = "3";
            base.kuvaus = "Katso maksamattomat ja maksetut korvaukset";
        }
        public override void Suorita(Myyntiedustaja edustaja)
        {
            {
                Console.WriteLine("\nHenkilölle " + edustaja.getNimi() + " maksamattomat korvaukset: " + edustaja.getMaksamattomat() + "e");
                Console.WriteLine("Henkilölle " + edustaja.getNimi() + " maksetut korvaukset: " + edustaja.getMaksetut() + "e");
            }
        }
    }
}
