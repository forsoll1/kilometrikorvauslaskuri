using System;
using System.Runtime.Serialization;

namespace Kilometrikorvaus_NETCore
{
    [DataContract()]
    public class Matka
    {
        [DataMember] private int tag;
        [DataMember] private string paivamaara;
        [DataMember] private double kilometrikorvaus;
        [DataMember] private string matka_aika;
        [DataMember] private double paivarahakorvaus;


        public Matka(   double kilometrit, double korvausPerKilometri,
                        string lahtoAika, string paluuAika,
                        double paivaraha, double puoliPaivaraha,
                        string pvm)
        {
            matka_aika = lahtoAika + " - " + paluuAika;
            kilometrikorvaus = Math.Round((kilometrit * korvausPerKilometri), 2);
            paivarahakorvaus = laskePaivaraha(lahtoAika, paluuAika, paivaraha, puoliPaivaraha);
            paivamaara = pvm;
            tag = makeTag(pvm);
        }

        public double getKilometrikorvaus()
        {
            return kilometrikorvaus;
        }
        public string getMatkaaika()
        {
            return matka_aika;
        }
        public double getPaivaraha()
        {
            return paivarahakorvaus;
        }
        public int getTag()
        {
            return tag;
        }
        private double laskePaivaraha(string lahtoAika, string paluuAika, double paivaraha, double puoliPaivaraha)
        {
            string[] lahto_jako = lahtoAika.Split(':');
            string[] paluu_jako = paluuAika.Split(':');

            DateTime date1 = new DateTime(2010, 1, 1, Convert.ToInt32(lahto_jako[0]), Convert.ToInt32(lahto_jako[1]), 0);
            DateTime date2 = new DateTime(2010, 1, 1, Convert.ToInt32(paluu_jako[0]), Convert.ToInt32(paluu_jako[1]), 0);

            TimeSpan interval = date2 - date1;
            if (interval.TotalHours > 10.0)
            {
                return paivaraha;
            }
            else if (interval.TotalHours > 6.0)
            {
                return puoliPaivaraha;
            }
            else
            {
                return 0;
            }
        }
        
        private int makeTag(string pvm)
        {
            string[] split = pvm.Split("/");
            return Int32.Parse(split[2]);
        }
        public string getTiedot()
        {
            return "Päivämäärä: " + paivamaara + "  Matka-aika: " + matka_aika + "  Kilometrikorvaus: " + kilometrikorvaus + "  Päiväraha: " + paivarahakorvaus;
        }
    }
}
