using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Edustajienhallinta
{
    public abstract class EHToiminnot
    {
        public string kuvaus { get; set; }
        public string luku { get; set; }
        public abstract void Suorita();
    }
}
