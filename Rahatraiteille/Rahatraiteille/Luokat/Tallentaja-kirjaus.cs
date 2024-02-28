using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rahatraiteille.Luokat
{
    internal class Tallentaja_kirjaus
    {
        private const string TIEDOSTO_NIMI = "kirjaukset.json";

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

        public static void TallennaKirjaukset(List<Kirjaus> kirjaukset)
        {
            try
            {
                var jsonKirjauslista = JsonSerializer.Serialize(kirjaukset);
                File.WriteAllText(GetJsonPath(), jsonKirjauslista); // bin ->
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }


        public static List<Kirjaus> LataaKirjaukset()
        {
            try
            {
                string polku = GetJsonPath();
                string raakaJson = File.ReadAllText(polku);
                var kirjauslista = JsonSerializer.Deserialize<List<Kirjaus>>(raakaJson);

                if (kirjauslista == null || kirjauslista.Count == 0) return new List<Kirjaus>();

                return kirjauslista;
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            return new List<Kirjaus>();
        }
    }
}
