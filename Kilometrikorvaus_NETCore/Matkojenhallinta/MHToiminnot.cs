using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    public abstract class MHToiminnot
    {
        public string kuvaus { get; set; }
        public string luku { get; set; }
        public abstract void Suorita(Myyntiedustaja valittu_myyntiedustaja);
    }
}
