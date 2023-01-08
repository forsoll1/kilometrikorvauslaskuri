using NUnit.Framework;
using Kilometrikorvaus_NETCore;
using System.Collections.Generic;

namespace Kilometrikorvaus_NETCoreTestit
{
    public class Tests

    {
        Matka matka = null;
        Myyntiedustaja edustaja = null;

        [SetUp]
        public void Setup()
        {
        }


        // Testejä Myyntiedustajaluokalle

        [Test]
        public void TestaaMyyntiedustajaNimi()
        {
            string nimi = "Pekka";
            edustaja = new Myyntiedustaja(nimi);
            Assert.AreEqual(nimi, edustaja.getNimi());
        }

        [Test]
        public void MaksaKorvausEdustajalle()
        {
            string nimi = "Pekka";
            edustaja = new Myyntiedustaja(nimi);
            edustaja.addKorvaus(10);
            edustaja.maksaKorvauksia(5);
            Assert.AreEqual(5, edustaja.getMaksetut());
        }

        [Test]
        public void MaksaNegatiivinenKorvausEdustajalle()
        {
            string nimi = "Pekka";
            edustaja = new Myyntiedustaja(nimi);
            edustaja.addKorvaus(10);
            edustaja.maksaKorvauksia(-5);
            Assert.AreEqual(0, edustaja.getMaksetut());
        }


        // Testejä Matkaluokalle

        [Test]
        public void KorvausKunAnnetaanMatkaJaKorvausPerKilometri()
        {
            matka = new Matka(100, 0.44, "12:00", "13:00", 10, 20, "12/12/2020");
            Assert.AreEqual(matka.getKilometrikorvaus(), (100 * 0.44));
        }

        [Test]
        public void MuodostaMatkaaika()
        {
            matka = new Matka(0, 0, "12:00", "13:00", 20, 10, "12/12/2020");
            string oletus = "12:00 - 13:00";
            Assert.AreEqual(oletus, matka.getMatkaaika());
        }

        [Test]
        public void AsetaPaivaraha()
        {
            matka = new Matka(0, 0, "7:00", "17:01", 20, 10, "12/12/2020");
            Assert.AreEqual(20, matka.getPaivaraha());
        }

        [Test]
        public void AsetaPuoliPaivaraha()
        {
            matka = new Matka(0, 0, "7:00", "13:01", 20, 10, "12/12/2020");
            Assert.AreEqual(10, matka.getPaivaraha());
        }

        [Test]
        public void AsetaNollaPaivarahaksi()
        {
            matka = new Matka(0, 0, "12:00", "13:00", 20, 10, "12/12/2020");
            Assert.AreEqual(0, matka.getPaivaraha());
        }


        /*
        [Test]
        public void ()
        {

        }
        */



    }
}