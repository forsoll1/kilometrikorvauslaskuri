using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Kilometrikorvaus_NETCore
{
    public static class Tallennus
    {

        // Tiedostonimet

        static string km_xml = "kilometrikorvaus.xml";

        // Tiedoston tallennus ja luku

        public static void TallennaTiedostoon(List<Myyntiedustaja> myyntiedustajat)
        {
            if (File.Exists("kilometrikorvaus.xml"))
            {
                FileStream fileStream = File.Open(km_xml, FileMode.Truncate);
                fileStream.Close();
            }
            Stream stream = File.OpenWrite(km_xml);
            DataContractSerializer DataSer = new DataContractSerializer(typeof(List<Myyntiedustaja>));
            DataSer.WriteObject(stream, myyntiedustajat);
            stream.Close();
        }
        public static List<Myyntiedustaja> LueTiedosto()
        {
            Stream stream = File.OpenRead(km_xml);

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
            DataContractSerializer seri = new DataContractSerializer(typeof(List<Myyntiedustaja>));

            List<Myyntiedustaja> ladatutedustajat = (List<Myyntiedustaja>)seri.ReadObject(reader, true);

            reader.Close();
            stream.Close();

            return ladatutedustajat;
        }
    }
}
