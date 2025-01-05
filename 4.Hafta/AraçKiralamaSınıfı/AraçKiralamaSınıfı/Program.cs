using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AraçKiralamaSınıfı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir kiralık araç oluştur
            KiralikArac arac = new KiralikArac("34ABC123", 150m);

            // Araç bilgilerini göster
            Console.WriteLine($"Araç Plakası: {arac.Plaka}");
            Console.WriteLine($"Günlük Ücret: {arac.GunlukUcret} TL");
            Console.WriteLine($"Araç Müsait Mi? {(arac.MusaitMi ? "Evet" : "Hayır")}");

            // Aracı kiralama işlemi
            arac.AraciKirala();
            Console.WriteLine($"Araç kiralandı. Şu an müsait mi? {(arac.MusaitMi ? "Evet" : "Hayır")}");

            // Aracı teslim etme işlemi
            arac.AraciTeslimEt();
            Console.WriteLine($"Araç teslim edildi. Şu an müsait mi? {(arac.MusaitMi ? "Evet" : "Hayır")}");

            // Konsolun kapanmasını önlemek için bekletme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    public class KiralikArac
    {
        // Özellikler
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        public bool MusaitMi { get; private set; }

        // Yapıcı metot: Plaka ve günlük ücreti başlatır, MusaitMi varsayılan olarak true
        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true; // Varsayılan olarak araç müsait
        }

        // Aracı kiralama metodu
        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine("Araç başarıyla kiralandı.");
            }
            else
            {
                Console.WriteLine("Araç zaten kirada, kiralama işlemi yapılamaz.");
            }
        }

        // Aracı teslim etme metodu
        public void AraciTeslimEt()
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine("Araç başarıyla teslim edildi.");
            }
            else
            {
                Console.WriteLine("Araç zaten teslim edilmiş durumda.");
            }
        }
    }
}