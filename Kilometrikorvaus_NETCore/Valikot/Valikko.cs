using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Valikot
{
    public abstract class Valikko
    {
        public string luku;
        public string kuvaus;
        public abstract void Avaa();
    }
}
