using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkSistemi
{
    class OtoparkSistemi
    {
        private string[,] katlar; // Otopark katları

        // Kurucu metod: Otopark sistemini başlatır
        public OtoparkSistemi(int katSayisi, int parkYeriSayisi)
        {
            katlar = new string[katSayisi, parkYeriSayisi];

            // Başlangıçta bütün park yerlerini boş ("Empty") olarak ayarlıyoruz
            for (int kat = 0; kat < katSayisi; kat++)
            {
                for (int parkYeri = 0; parkYeri < parkYeriSayisi; parkYeri++)
                {
                    katlar[kat, parkYeri] = "Empty";
                }
            }
        }

        // İndeksleyici (indexer): Belirli bir kat ve park yerine erişir
        public string this[int kat, int parkYeri]
        {
            get
            {
                // Geçerli bir kat ve park yeri kontrolü
                if (kat >= 0 && kat < katlar.GetLength(0) && parkYeri >= 0 && parkYeri < katlar.GetLength(1))
                {
                    return katlar[kat, parkYeri];
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz kat veya park yeri.");
                }
            }
            set
            {
                // Geçerli bir kat ve park yeri kontrolü
                if (kat >= 0 && kat < katlar.GetLength(0) && parkYeri >= 0 && parkYeri < katlar.GetLength(1))
                {
                    katlar[kat, parkYeri] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz kat veya park yeri.");
                }
            }
        }

        // Otoparkta bir park yerine araç park etme
        public void AracParkEt(int kat, int parkYeri, string aracPlakasi)
        {
            if (kat >= 0 && kat < katlar.GetLength(0) && parkYeri >= 0 && parkYeri < katlar.GetLength(1))
            {
                if (katlar[kat, parkYeri] == "Empty")
                {
                    katlar[kat, parkYeri] = aracPlakasi;
                    Console.WriteLine($"Araç {aracPlakasi} başarıyla park etti.");
                }
                else
                {
                    Console.WriteLine($"Park yeri zaten dolu. Park yeri: {kat}, {parkYeri}.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz kat veya park yeri.");
            }
        }

        // Otoparktan araç çıkarma
        public void AracCikart(int kat, int parkYeri)
        {
            if (kat >= 0 && kat < katlar.GetLength(0) && parkYeri >= 0 && parkYeri < katlar.GetLength(1))
            {
                if (katlar[kat, parkYeri] != "Empty")
                {
                    Console.WriteLine($"Araç {katlar[kat, parkYeri]} başarıyla çıkartıldı.");
                    katlar[kat, parkYeri] = "Empty";
                }
                else
                {
                    Console.WriteLine("Park yeri zaten boş.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz kat veya park yeri.");
            }
        }

        // Otoparkın durumunu yazdırma
        public void OtoparkDurumunuYazdir()
        {
            for (int kat = 0; kat < katlar.GetLength(0); kat++)
            {
                Console.WriteLine($"Kat {kat + 1}:");
                for (int parkYeri = 0; parkYeri < katlar.GetLength(1); parkYeri++)
                {
                    Console.Write($"[{katlar[kat, parkYeri]}] ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 3 kat ve her katta 5 park yeri olan bir otopark sistemi oluşturuyoruz
            OtoparkSistemi otopark = new OtoparkSistemi(3, 5);

            // Otoparkın durumunu yazdırıyoruz
            Console.WriteLine("Otoparkın Durumu:");
            otopark.OtoparkDurumunuYazdir();

            // Bir aracı park etme
            Console.WriteLine("\nAraç park etme:");
            otopark.AracParkEt(1, 2, "34ABC123");

            // Otoparkın durumunu tekrar yazdırıyoruz
            otopark.OtoparkDurumunuYazdir();

            // Bir araç çıkartma
            Console.WriteLine("\nAraç çıkartma:");
            otopark.AracCikart(1, 2);

            // Otoparkın durumunu tekrar yazdırıyoruz
            otopark.OtoparkDurumunuYazdir();

            // Geçersiz bir park yerine araç park etmeye çalışalım
            Console.WriteLine("\nGeçersiz park yerine araç park etme:");
            otopark.AracParkEt(3, 6, "45XYZ987");

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}