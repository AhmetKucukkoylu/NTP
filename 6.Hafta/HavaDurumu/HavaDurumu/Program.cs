using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavaDurumu
{
    public enum HavaDurumu
    {
        Sunny,   // Güneşli
        Rainy,   // Yağmurlu
        Cloudy,  // Bulutlu
        Stormy   // Fırtınalı
    }

    public class HavaDurumuTavsiyesi
    {
        // Hava durumu tipine göre tavsiye veren metot
        public static string TavsiyeVer(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    return "Bugün güneşli bir hava var. Dışarıda vakit geçirmek için harika bir gün!";
                case HavaDurumu.Rainy:
                    return "Yağmur yağıyor. Şemsiye almayı unutma!";
                case HavaDurumu.Cloudy:
                    return "Hava bulutlu. Belki biraz serin olabilir, yanına bir ceket al.";
                case HavaDurumu.Stormy:
                    return "Fırtına var! Dışarı çıkmak tehlikeli, güvenli bir yerde kal.";
                default:
                    return "Geçersiz hava durumu!";
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Hava durumu tiplerini simüle ediyoruz
            HavaDurumu durum = HavaDurumu.Sunny;
            Console.WriteLine(HavaDurumuTavsiyesi.TavsiyeVer(durum));

            // Durumları değiştirerek başka tavsiyeler gösteriyoruz
            durum = HavaDurumu.Rainy;
            Console.WriteLine(HavaDurumuTavsiyesi.TavsiyeVer(durum));

            durum = HavaDurumu.Cloudy;
            Console.WriteLine(HavaDurumuTavsiyesi.TavsiyeVer(durum));

            durum = HavaDurumu.Stormy;
            Console.WriteLine(HavaDurumuTavsiyesi.TavsiyeVer(durum));

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}