using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Kilometrikorvaus_NETCore
{
    [DataContract()]
    public class Myyntiedustaja
    {
        [DataMember] private List<Matka> matkat = new List<Matka>();
        [DataMember] private string nimi;
        [DataMember] private double maksamattomatKorvaukset = 0;
        [DataMember] private double maksetutKorvaukset = 0;
        [DataMember] private double kertyneetKorvaukset = 0;

        public Myyntiedustaja(string nimi)
        {
            this.nimi = nimi;
        }

        public string getNimi()
        {
            return nimi;
        }
        public void addMatka(Matka matka)
        {
            matkat.Add(matka);
            double korvaus = matka.getKilometrikorvaus() + matka.getPaivaraha();
            maksamattomatKorvaukset += korvaus;
            kertyneetKorvaukset += korvaus;
        }
        public List<Matka> getMatkat()
        {
            return matkat;
        }
        public void addKorvaus(double maara)
        {
            maksamattomatKorvaukset += maara;
            kertyneetKorvaukset += maara;
        }
        public void maksaKorvauksia(double maara)
        {
            if (maara >= 0 && maara > maksamattomatKorvaukset)
            {
                maksetutKorvaukset += maksamattomatKorvaukset;
                maksamattomatKorvaukset = 0;
                Console.WriteLine("Yritit maksaa liian suurella summalla, ylimenevää osaa ei huomioitu.");
            }
            else if (maara >= 0)
            {
                maksetutKorvaukset += maara;
                maksamattomatKorvaukset -= maara;
            }
            else
            {
                Console.WriteLine("Et voi yrittää maksaa negatiivisella arvolla");
            }
        }
        public double getMaksetut()
        {
            return maksetutKorvaukset;
        }
        public double getMaksamattomat()
        {
            return maksamattomatKorvaukset;
        }
        public double getKertyneet()
        {
            return kertyneetKorvaukset;
        }
    }
}
