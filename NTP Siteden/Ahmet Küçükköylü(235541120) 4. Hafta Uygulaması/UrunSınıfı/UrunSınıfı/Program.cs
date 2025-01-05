using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunSınıfı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir ürün oluştur
            Urun urun = new Urun("Laptop", 5000m);

            // Ürünün bilgilerini göster
            Console.WriteLine($"Ürün Adı: {urun.Ad}");
            Console.WriteLine($"Ürün Fiyatı: {urun.Fiyat} TL");

            // İndirim ayarla ve indirimli fiyatı göster
            urun.Indirim = 20;
            Console.WriteLine($"İndirim Oranı: %{urun.Indirim}");
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()} TL");

            // İndirimi sınır değerleri dışında bir değere ayarla ve kontrol et
            urun.Indirim = 60; // İndirim %50 ile sınırlandırılacak
            Console.WriteLine($"Yeni İndirim Oranı: %{urun.Indirim}");
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()} TL");

            // Konsolun kapanmasını önlemek için bekletme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    public class Urun
    {
        // Özellikler
        public string Ad { get; private set; }
        public decimal Fiyat { get; private set; }
        private decimal indirim;

        // İndirim özelliği için get ve set metotları
        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                // İndirimi 0 ile 50 arasında sınırlandırıyoruz
                if (value < 0)
                    indirim = 0;
                else if (value > 50)
                    indirim = 50;
                else
                    indirim = value;
            }
        }

        // Yapıcı metot: Ürün adı ve fiyat bilgilerini alır
        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
            indirim = 0; // Varsayılan olarak indirim %0
        }

        // Indirimli fiyatı döndüren metot
        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }
}