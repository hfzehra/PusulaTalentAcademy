using System.Text.Json;

namespace LongestVowelSubsequence
{
    internal class LongestVowelSubsequenceAsJson
    {
        public static string LongestVowelSubsequenceAsJsonFunc(List<string> kelimeler)
        {
            if (kelimeler == null || kelimeler.Count == 0)
                return JsonSerializer.Serialize(new List<object>());

            char[] sesli = { 'a', 'e', 'i', 'o', 'u' };
            var sonuc = new List<object>();

            foreach (var kelime in kelimeler)
            {
                string yeniKelime = kelime.ToLower();
                string sesliDizi = "";
                string enUzunSesliDizi = "";

                foreach (char c in yeniKelime)
                {
                    if (sesli.Contains(c))
                    {
                        sesliDizi += c;
                    }
                    else
                    {
                        if (sesliDizi.Length > enUzunSesliDizi.Length)
                            enUzunSesliDizi = sesliDizi;
                        sesliDizi = "";
                    }
                }

                if (sesliDizi.Length > enUzunSesliDizi.Length)
                    enUzunSesliDizi = sesliDizi;

                sonuc.Add(new
                {
                    word = kelime,
                    sequence = enUzunSesliDizi,
                    length = enUzunSesliDizi.Length
                });
            }

            return JsonSerializer.Serialize(sonuc);
        }

        static void Main(string[] args)
        {
            var kelime1 = new List<string> { "aeiou", "bcd", "aaa" };
            Console.WriteLine(LongestVowelSubsequenceAsJsonFunc(kelime1));
            Console.WriteLine("-----------");

            var kelime2 = new List<string> { "miscellaneous", "queue", "sky", "cooperative" };
            Console.WriteLine(LongestVowelSubsequenceAsJsonFunc(kelime2));
            Console.WriteLine("-----------");

            var kelime3 = new List<string>();
            Console.WriteLine(LongestVowelSubsequenceAsJsonFunc(kelime3));

        }
    }
}
