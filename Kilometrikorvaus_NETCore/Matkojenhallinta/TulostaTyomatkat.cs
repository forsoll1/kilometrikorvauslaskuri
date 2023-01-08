using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class TulostaTyomatkat : MHToiminnot
    {

        public TulostaTyomatkat()
        {
            base.luku = "4";
            base.kuvaus = "Myyntiedustajan työmatkat";
        }

        public override void Suorita(Myyntiedustaja edustaja)
        {
            if (edustaja.getMatkat().Count == 0)
            {
                Console.WriteLine("\nEi maksamattomia korvauksia");
                return;
            }
            Console.WriteLine("");
            Funktiot.ListaaMatkat(edustaja);
        }
    }
}
