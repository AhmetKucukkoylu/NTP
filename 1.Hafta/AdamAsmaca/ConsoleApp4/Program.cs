using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamAsmaca
{
    class Program
    {
        static void Main()
        {
            string[] kelimeler = { "elma", "armut", "muz", "kiraz", "çilek" };
            Random rastgele = new Random();
            string secilenKelime = kelimeler[rastgele.Next(kelimeler.Length)];
            char[] tahminEdilen = new char[secilenKelime.Length];
            for (int i = 0; i < tahminEdilen.Length; i++)
            {
                tahminEdilen[i] = '_';
            }

            List<char> hataliTahminler = new List<char>();
            int can = 6;
            bool oyunBitti = false;

            while (!oyunBitti && can > 0)
            {
                Console.Clear();
                AdamCiz(can);
                Console.WriteLine("Kalan can: " + can);
                Console.WriteLine("Tahmin edilen kelime: " + new string(tahminEdilen));
                Console.WriteLine("Hatalı tahminler: " + string.Join(", ", hataliTahminler));
                Console.Write("Bir harf tahmin edin: ");
                char tahmin = char.Parse(Console.ReadLine().ToLower());

                if (tahminEdilen.Contains(tahmin) || hataliTahminler.Contains(tahmin))
                {
                    Console.WriteLine("Bu harfi zaten tahmin ettiniz. Başka bir harf deneyin.");
                    Console.ReadKey();
                    continue;
                }

                if (secilenKelime.Contains(tahmin))
                {
                    for (int i = 0; i < secilenKelime.Length; i++)
                    {
                        if (secilenKelime[i] == tahmin)
                        {
                            tahminEdilen[i] = tahmin;
                        }
                    }
                }
                else
                {
                    hataliTahminler.Add(tahmin);
                    can--;
                }

                if (new string(tahminEdilen) == secilenKelime)
                {
                    oyunBitti = true;
                    Console.Clear();
                    Console.WriteLine("Tebrikler! Kelimeyi doğru tahmin ettiniz: " + secilenKelime);
                    Console.WriteLine("Oyunu bitirmek için bir tuşa basın...");
                    Console.ReadKey();  // Oyunun bitmesinden sonra ekranın kapanmasını önlemek için
                }

                if (can == 0)
                {
                    Console.Clear();
                    AdamCiz(can);
                    Console.WriteLine("Kaybettiniz! Doğru kelime: " + secilenKelime);
                    Console.WriteLine("Oyunu bitirmek için bir tuşa basın...");
                    Console.ReadKey();  // Oyunun bitmesinden sonra ekranın kapanmasını önlemek için
                }
            }
        }

        static void AdamCiz(int can)
        {
            switch (can)
            {
                case 6:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 5:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 4:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 3:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine(" /|    |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 2:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine(" /|\\   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 1:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine(" /|\\   |");
                    Console.WriteLine(" /     |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
                case 0:
                    Console.WriteLine("  _____");
                    Console.WriteLine("  |    |");
                    Console.WriteLine("  O    |");
                    Console.WriteLine(" /|\\   |");
                    Console.WriteLine(" / \\   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("_______|");
                    break;
            }
        }
    }
}