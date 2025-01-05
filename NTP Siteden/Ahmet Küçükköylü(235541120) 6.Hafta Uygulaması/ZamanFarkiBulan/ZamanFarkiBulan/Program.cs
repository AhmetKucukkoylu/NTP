using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamanFarkiBulan
{
    class Program
    {
        // İlk sürüm: İki tarih arasındaki farkı gün cinsinden hesaplar.
        public static int TarihFarki(DateTime tarih1, DateTime tarih2)
        {
            TimeSpan fark = tarih2 - tarih1;
            return (int)fark.TotalDays;
        }

        // İkinci sürüm: İki tarih arasındaki farkı saat cinsinden hesaplar.
        public static double TarihFarkiSaat(DateTime tarih1, DateTime tarih2)
        {
            TimeSpan fark = tarih2 - tarih1;
            return fark.TotalHours;
        }

        // Üçüncü sürüm: İki tarih arasındaki farkı yıl, ay ve gün cinsinden hesaplar.
        public static string TarihFarkiYilAyGun(DateTime tarih1, DateTime tarih2)
        {
            int yilFarki = tarih2.Year - tarih1.Year;
            int ayFarki = tarih2.Month - tarih1.Month;
            int gunFarki = tarih2.Day - tarih1.Day;

            if (gunFarki < 0)
            {
                ayFarki--;
                gunFarki += DateTime.DaysInMonth(tarih2.Year, tarih2.Month);
            }

            if (ayFarki < 0)
            {
                yilFarki--;
                ayFarki += 12;
            }

            return $"{yilFarki} yıl, {ayFarki} ay, {gunFarki} gün";
        }

        static void Main(string[] args)
        {
            // Örnek tarihler
            DateTime tarih1 = new DateTime(2020, 1, 1);
            DateTime tarih2 = new DateTime(2024, 11, 26);

            // İlk sürümü test edelim: Gün cinsinden fark
            Console.WriteLine("Gün cinsinden fark: " + TarihFarki(tarih1, tarih2)); // Gün sayısı

            // İkinci sürümü test edelim: Saat cinsinden fark
            Console.WriteLine("Saat cinsinden fark: " + TarihFarkiSaat(tarih1, tarih2)); // Saat sayısı

            // Üçüncü sürümü test edelim: Yıl, ay, gün cinsinden fark
            Console.WriteLine("Yıl, Ay, Gün cinsinden fark: " + TarihFarkiYilAyGun(tarih1, tarih2)); // Yıl, Ay, Gün

            // Ekranın açık kalması için
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}