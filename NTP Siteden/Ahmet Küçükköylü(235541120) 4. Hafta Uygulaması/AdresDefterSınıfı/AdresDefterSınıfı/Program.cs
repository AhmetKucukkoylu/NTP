using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresDefterSınıfı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir kişi oluştur
            Kisi kisi1 = new Kisi("Ahmet", "Yılmaz", "0555 123 4567");

            // Kişi bilgilerini göster
            Console.WriteLine(kisi1.KisiBilgisi());

            // Başka bir kişi oluştur ve bilgilerini göster
            Kisi kisi2 = new Kisi("Ayşe", "Kara", "0555 987 6543");
            Console.WriteLine(kisi2.KisiBilgisi());

            // Konsolun kapanmasını önlemek için bekletme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    public class Kisi
    {
        // Özellikler
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string TelefonNumarasi { get; private set; }

        // Yapıcı metot: Ad, Soyad ve TelefonNumarasi bilgilerini başlatır
        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        // Kisi bilgilerini döndüren metot
        public string KisiBilgisi()
        {
            return $"Ad Soyad: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}";
        }
    }
}