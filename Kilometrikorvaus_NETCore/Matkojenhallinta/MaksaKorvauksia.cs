using System;
using System.Collections.Generic;
using System.Text;

namespace Kilometrikorvaus_NETCore.Matkojenhallinta
{
    class MaksaKorvauksia : MHToiminnot
    {

        List<Myyntiedustaja> edustajat;
        public MaksaKorvauksia(List<Myyntiedustaja> edustajat)
        {
            base.luku = "2";
            base.kuvaus = "Kuittaa korvauksia maksetuiksi";
            this.edustajat = edustajat;
        }
        public override void Suorita(Myyntiedustaja edustaja)
        {
            // Myyntiedustajalle kirjattuja korvauksia voidaan "maksaa" pois. Käyttäjä antaman syötteen arvo vähennetään edustajan "maksamattomat"-muuttujasta ja lisätään "maksetut"-muuttujaan. 

            if (edustaja.getMaksamattomat() == 0)
            {
                Console.WriteLine("\nEi maksamattomia korvauksia");
                return;
            }
            Console.WriteLine("\nMaksamattomia korvauksia: " + edustaja.getMaksamattomat());
            Console.WriteLine("Kuinka suurella summalla haluat kuitata korvauksia maksetuiksi?");

            double maksa_korvauksia = Funktiot.isDouble();
            edustaja.maksaKorvauksia(maksa_korvauksia);
            Tallennus.TallennaTiedostoon(edustajat);

            Console.WriteLine("\nHenkilölle " + edustaja.getNimi() + " maksettu " + maksa_korvauksia);
            Console.WriteLine("Maksettuja: " + edustaja.getMaksetut() + "  Maksamattomia: " + edustaja.getMaksamattomat());
            return;
        }
    }
}
