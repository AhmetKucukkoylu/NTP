using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciNotSİstemi
{
    class OgrenciNotSistemi
    {
        // Ders adı ile notları depolamak için bir sözlük (dictionary) kullanıyoruz.
        private Dictionary<string, double> dersNotlari;

        // OgrenciNotSistemi sınıfının kurucu metodu
        public OgrenciNotSistemi()
        {
            dersNotlari = new Dictionary<string, double>();
        }

        // İndeksleyici (indexer) - Ders adına göre notu alır ve set eder.
        public double this[string dersAdi]
        {
            get
            {
                // Ders adı kontrolü, eğer ders yoksa hata fırlatılır.
                if (dersNotlari.ContainsKey(dersAdi))
                {
                    return dersNotlari[dersAdi];
                }
                else
                {
                    throw new KeyNotFoundException("Bu ders bulunamadı: " + dersAdi);
                }
            }
            set
            {
                // Ders adı kontrolü, eğer ders yoksa eklenir, varsa not değiştirilir.
                dersNotlari[dersAdi] = value;
            }
        }

        // Öğrencinin aldığı tüm dersleri listeleyen bir metot
        public void DersleriListele()
        {
            Console.WriteLine("Alınan Dersler ve Notlar:");
            foreach (var ders in dersNotlari)
            {
                Console.WriteLine($"{ders.Key}: {ders.Value}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci not sistemi oluşturuluyor
            OgrenciNotSistemi ogrenci = new OgrenciNotSistemi();

            // Öğrencinin aldığı derslere not ekleyelim
            ogrenci["Matematik"] = 85.5;
            ogrenci["Fizik"] = 92.0;
            ogrenci["Kimya"] = 78.0;

            // Öğrencinin aldığı dersleri listeleyelim
            ogrenci.DersleriListele();

            // Kullanıcıdan ders adı alıp, o dersin notunu gösterelim.
            Console.Write("\nNotunu öğrenmek istediğiniz dersi girin: ");
            string dersAdi = Console.ReadLine();

            try
            {
                // İndeksleyici aracılığıyla ders notunu alıyoruz
                Console.WriteLine($"{dersAdi} dersinin notu: {ogrenci[dersAdi]}");
            }
            catch (KeyNotFoundException ex)
            {
                // Ders bulunamazsa hata mesajı gösteriliyor
                Console.WriteLine(ex.Message);
            }

            // Geçersiz bir ders adı ile not sorgulaması yapalım
            try
            {
                Console.WriteLine("\nGeçersiz bir ders adı sorgulaması:");
                Console.WriteLine(ogrenci["Biyoloji"]); // Geçersiz ders adı
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message); // Hata mesajı
            }

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}