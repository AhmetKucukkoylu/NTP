using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamanIslemleri
{
    public struct Zaman
    {
        // Saat ve Dakika özellikleri
        public int Hour { get; set; }
        public int Minute { get; set; }

        // Yapıcı metod: Saat ve dakikayı alır, geçersizse 0 yapar
        public Zaman(int hour, int minute)
        {
            // Geçerli bir saat aralığı kontrolü (0-23)
            Hour = (hour >= 0 && hour <= 23) ? hour : 0;
            // Geçerli bir dakika aralığı kontrolü (0-59)
            Minute = (minute >= 0 && minute <= 59) ? minute : 0;
        }

        // Zamanın toplam dakika değerini döndüren metot
        public int ToplamDakika()
        {
            return Hour * 60 + Minute;
        }

        // İki zaman arasındaki farkı dakika olarak hesaplayan metot
        public static int Fark(Zaman zaman1, Zaman zaman2)
        {
            return Math.Abs(zaman1.ToplamDakika() - zaman2.ToplamDakika());
        }

        // Zamanı ekrana yazdırmak için bir metot
        public void Yazdir()
        {
            Console.WriteLine($"Saat: {Hour:D2}:{Minute:D2}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Zaman nesnelerini oluşturuyoruz
            Zaman zaman1 = new Zaman(14, 30); // 14:30
            Zaman zaman2 = new Zaman(10, 15); // 10:15

            // Zamanları yazdırıyoruz
            Console.WriteLine("Birinci Zaman:");
            zaman1.Yazdir();
            Console.WriteLine("İkinci Zaman:");
            zaman2.Yazdir();

            // Zamanların toplam dakika cinsinden değerini yazdırıyoruz
            Console.WriteLine("\nBirinci Zamanın Toplam Dakikası: " + zaman1.ToplamDakika());
            Console.WriteLine("İkinci Zamanın Toplam Dakikası: " + zaman2.ToplamDakika());

            // İki zaman arasındaki farkı dakikalar cinsinden hesaplıyoruz
            int fark = Zaman.Fark(zaman1, zaman2);
            Console.WriteLine($"\nİki zaman arasındaki fark: {fark} dakika");

            // Geçersiz bir zaman örneği (Saat 25, Dakika 61 gibi)
            Zaman zaman3 = new Zaman(25, 61); // Geçersiz saat ve dakika
            Console.WriteLine("\nGeçersiz Zaman:");
            zaman3.Yazdir(); // 00:00 olarak ayarlanmalı

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}