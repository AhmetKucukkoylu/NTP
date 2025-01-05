using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikYonetimSistemi
{
    class Kitaplik
    {
        private string[] kitaplar;

        // Kitaplık sınıfının kurucu metodu, kitap koleksiyonunu başlatır.
        public Kitaplik(int koleksiyonBoyutu)
        {
            kitaplar = new string[koleksiyonBoyutu];
        }

        // İndeksleyici (indexer) - belirli bir indekste kitap adı alır ve set eder.
        public string this[int indeks]
        {
            get
            {
                // Geçerli indeks kontrolü
                if (indeks >= 0 && indeks < kitaplar.Length)
                {
                    return kitaplar[indeks];
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz indeks! Kitap bulunamadı.");
                }
            }
            set
            {
                // Geçerli indeks kontrolü
                if (indeks >= 0 && indeks < kitaplar.Length)
                {
                    kitaplar[indeks] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz indeks! Kitap adı değiştirilemez.");
                }
            }
        }

        // Kitapları listeleyen bir metot (opsiyonel).
        public void KitaplariListele()
        {
            Console.WriteLine("Kitap Koleksiyonu:");
            for (int i = 0; i < kitaplar.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {kitaplar[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Kitaplık oluşturuluyor (5 kitap kapasitesi ile)
            Kitaplik kitaplik = new Kitaplik(5);

            // Kitap koleksiyonunu başlatmak için
            kitaplik[0] = "1984";
            kitaplik[1] = "Savaş ve Barış";
            kitaplik[2] = "Moby Dick";
            kitaplik[3] = "Suç ve Ceza";
            kitaplik[4] = "Bülbülü Öldürmek";

            // Kitapları listele
            kitaplik.KitaplariListele();

            // Kullanıcıdan kitap adı değiştirmesini isteyelim.
            Console.WriteLine("\nBir kitap adı değiştirelim.");
            Console.Write("Değiştirmek istediğiniz kitabın numarasını girin: ");
            int kitapNo = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Yeni kitap adını girin: ");
            string yeniKitapAdi = Console.ReadLine();

            try
            {
                kitaplik[kitapNo] = yeniKitapAdi; // Kitap adı değiştirme
                Console.WriteLine("\nKitap adı başarıyla değiştirildi.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Kitapları yeniden listeleyelim
            kitaplik.KitaplariListele();

            // Geçersiz indeks ile erişim denemesi
            try
            {
                Console.WriteLine("\nGeçersiz bir indeks ile kitap erişim denemesi:");
                Console.WriteLine(kitaplik[10]); // Geçersiz indeks
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message); // Hata mesajı
            }

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}