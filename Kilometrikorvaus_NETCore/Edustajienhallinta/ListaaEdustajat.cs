using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Edustajienhallinta
{
    class ListaaEdustajat : EHToiminnot
    {
        List<Myyntiedustaja> edustajat = new List<Myyntiedustaja>();

        public ListaaEdustajat(List<Myyntiedustaja> edustajat)
        {
            base.kuvaus = "Listaa myyntiedustajat";
            base.luku = "3";
            this.edustajat = edustajat;
        }
        public override void Suorita()
        {
            Funktiot.ListaaEdustajat(this.edustajat);
        }
    }
}
