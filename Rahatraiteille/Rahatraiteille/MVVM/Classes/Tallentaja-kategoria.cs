using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Rahatraiteille.MVVM.Classes
{
    internal class Tallentaja_kategoria
    {
        private const string TIEDOSTO_NIMI = "kategoriat.json";

        public static string testi()
        {
            return TIEDOSTO_NIMI;
        }

        private static string GetJsonPath()
        {
            string polku = System.Reflection.Assembly.GetExecutingAssembly().Location;
            polku = Path.GetDirectoryName(polku);
            string oikeaPolku = Path.Combine(polku, TIEDOSTO_NIMI);

            return oikeaPolku;
        }

        public static void TallennaKategoriat(List<Kategoria> kategoriat)
        {
            try
            {
                var jsonKategorialista = JsonSerializer.Serialize(kategoriat);
                File.WriteAllText(GetJsonPath(), jsonKategorialista); // bin ->
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public static List<Kategoria> LataaKategoriat()
        {
            try
            {
                string polku = GetJsonPath();
                string raakaJson = File.ReadAllText(polku);
                var kategorialista = JsonSerializer.Deserialize<List<Kategoria>>(raakaJson);

                if (kategorialista == null || kategorialista.Count == 0) return new List<Kategoria>();

                return kategorialista;
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            return new List<Kategoria>();
        }
    }
}
