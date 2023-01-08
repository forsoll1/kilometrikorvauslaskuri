using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Raportointi
{
    public abstract class KKToiminnot
    {
        public string Kuvaus { get; set; }
        public string Luku { get; set; }
        public abstract void Suorita();
    }
}
