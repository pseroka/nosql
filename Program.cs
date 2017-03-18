using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadLines(@"C:\Users\PC\Desktop\m.csv").Skip(1).Select(row => row.Split(',').Select(item => item.Trim('"')).ToArray()).ToArray();
            List<string[]> results = new List<string[]>();
            Dictionary<string, string[]> countries = new Dictionary<string, string[]>
            {
                { "PL", new [] { "21.0117800", "52.2297700" } }, //Polska
                { "US", new [] { "40.7142700", "-74.0059700" } }, //Stany Zjednoczone
                { "GB", new [] { "-0.1257400", "51.5085300" } }, //Wielka Brytania
                { "DE", new [] { "-0.1257400", "51.5085300" } }, //Niemcy
                { "FR", new [] { "2.3488000", "48.8534100" } }, //Francja
                { "NL", new [] { "4.8896900", "52.3740300" } }, //Holandia
                { "CA", new [] { "-75.6981200", "45.4111700" } }, //Kanada
                { "FI", new [] { "24.9354500", "60.1695200" } }, //Finlandia
                { "SE", new [] { "18.0649000", "59.3325800" } }, //Szwecja
                { "PK", new [] { "73.0432900", "33.7214800" } }, //Pakistan
                { "DK", new [] { "12.5655300", "55.6759400" } }, //Dania
                { "KR", new [] { "126.9784000", "37.5660000" } }, //Korea Południowa
                { "NO", new [] { "10.7460900", "59.9127300" } }, //Norwegia
                { "RU", new [] { "37.6155600", "55.7522200" } }, //Rosja
                { "ES", new [] { "-3.7025600", "40.4165000" } }, //Hiszpania
                { "BR", new [] { "-47.9297200", "-15.7797200" } }, //Brazylia
                { "IT", new [] { "12.5113300", "41.8919300" } }, //Włochy
                { "CL", new [] { "-70.6482700", "-33.4569400" } }, //Chile
                { "MX", new [] { "-99.1276600", "19.4284700" } }, //Meksyk
                { "UA", new [] { "30.5238000", "50.4546600" } }, //Ukraina
                { "PT", new [] { "-9.1333300", "38.7166700" } }, //Portugalia
                { "AR", new [] { "-58.3772300", "-34.6131500" } }, //Argentyna
                { "PR", new [] { "-68.5363900", "-31.5375000" } }, //Puerto Rico
                { "TW", new [] { "121.5318500", "25.0477600" } }, //Tajwan
                { "IE", new [] { "-6.2488900", "53.3330600" } }, //Irlandia
                { "CN", new [] { "116.3972300", "39.9075000" } }, //Chiny
                { "JP", new [] { "139.6917100", "35.6895000" } }, //Japonia
                { "VN", new [] { "105.8411700", "21.0245000" } }, //Wietnam
                { "AU", new [] { "149.1280700", "-35.2834600" } }, //Australia
                { "AT", new [] { "16.3720800", "48.2084900" } }, //Austria
                { "IN", new [] { "77.2244500", "28.6357600" } }, //Indie
                { "CO", new [] { "-74.0817500", "4.6097100" } }, //Kolumbia
                { "SA", new [] { "46.7218500", "24.6877300" } }, //Arabia Saudyjska
                { "NZ", new [] { "174.7755700", "-41.2866400" } }, //Nowa Zelandia
                { "BE", new [] { "4.3487800", "50.8504500" } }, //Belgia
                { "CH", new [] { "7.4474400", "46.9480900" } }, //Szwajcaria
                { "None", new [] { "", "" } }
            };

            foreach (var row in rows)
            {
                string country = row[6];

                if (countries.ContainsKey(country))
                {
                    var r = row.ToList();
                    r.AddRange(countries[country]);
                    results.Add(r.ToArray());
                }
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\PC\Desktop\twitch.csv"))
            {
                foreach (var result in results)
                {
                    file.WriteLine(string.Join(",", result));
                }
            }
        }
    }
}
