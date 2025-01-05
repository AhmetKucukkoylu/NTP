using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafikisigiDurum
{
    public enum TrafikIsigiDurumu
    {
        Red,    // Kırmızı ışık
        Yellow, // Sarı ışık
        Green   // Yeşil ışık
    }

    public class TrafikIsigi
    {
        // Trafik ışığı durumu belirten bir metot
        public static string DurumaGoreIslem(TrafikIsigiDurumu durum)
        {
            switch (durum)
            {
                case TrafikIsigiDurumu.Red:
                    return "Dur! Işık kırmızı, geçiş yasak.";
                case TrafikIsigiDurumu.Yellow:
                    return "Dikkat! Işık sarı, hazırlıklı ol.";
                case TrafikIsigiDurumu.Green:
                    return "Geçiş serbest! Işık yeşil.";
                default:
                    return "Geçersiz ışık durumu.";
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Trafik ışığının durumunu simüle ediyoruz
            TrafikIsigiDurumu durum = TrafikIsigiDurumu.Green;

            // Duruma göre yapılacak işlemi ekrana yazdırıyoruz
            Console.WriteLine(TrafikIsigi.DurumaGoreIslem(durum));

            // Durumları değiştirerek başka örnekler gösteriyoruz
            durum = TrafikIsigiDurumu.Red;
            Console.WriteLine(TrafikIsigi.DurumaGoreIslem(durum));

            durum = TrafikIsigiDurumu.Yellow;
            Console.WriteLine(TrafikIsigi.DurumaGoreIslem(durum));

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}