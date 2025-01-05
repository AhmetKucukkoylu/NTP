using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrançTahtasi
{
    class SatrancTasi
    {
        private string[,] tahta;

        // Satranç tahtasını 8x8 boyutunda başlatan kurucu metod
        public SatrancTasi()
        {
            tahta = new string[8, 8];

            // Tahtadaki her kareyi boş ("") olarak başlatıyoruz.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tahta[i, j] = "";
                }
            }

            // Tahtadaki başlangıç taşlarını yerleştiriyoruz
            // Beyaz taşlar
            tahta[0, 0] = "Rook";    // A1
            tahta[0, 1] = "Knight";  // B1
            tahta[0, 2] = "Bishop";  // C1
            tahta[0, 3] = "Queen";   // D1
            tahta[0, 4] = "King";    // E1
            tahta[0, 5] = "Bishop";  // F1
            tahta[0, 6] = "Knight";  // G1
            tahta[0, 7] = "Rook";    // H1

            // Beyaz piyonlar
            for (int i = 0; i < 8; i++)
            {
                tahta[1, i] = "Pawn";  // A2 - H2
            }

            // Siyah taşlar
            tahta[7, 0] = "Rook";    // A8
            tahta[7, 1] = "Knight";  // B8
            tahta[7, 2] = "Bishop";  // C8
            tahta[7, 3] = "Queen";   // D8
            tahta[7, 4] = "King";    // E8
            tahta[7, 5] = "Bishop";  // F8
            tahta[7, 6] = "Knight";  // G8
            tahta[7, 7] = "Rook";    // H8

            // Siyah piyonlar
            for (int i = 0; i < 8; i++)
            {
                tahta[6, i] = "Pawn";  // A7 - H7
            }
        }

        // İndeksleyici (indexer) - Satranç tahtasında bir kareye taş yerleştirir veya taş bilgisini alır.
        public string this[int satir, int sutun]
        {
            get
            {
                // Geçerli bir kare kontrolü
                if (satir >= 0 && satir < 8 && sutun >= 0 && sutun < 8)
                {
                    return tahta[satir, sutun];
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz kare! Satranç tahtasında böyle bir kare yok.");
                }
            }
            set
            {
                // Geçerli bir kare kontrolü
                if (satir >= 0 && satir < 8 && sutun >= 0 && sutun < 8)
                {
                    tahta[satir, sutun] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Geçersiz kare! Taş yerleştirilemez.");
                }
            }
        }

        // Satranç tahtasını ekrana yazdırma
        public void TahtayiYazdir()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string kare = tahta[i, j] == "" ? "[ ]" : $"[{tahta[i, j]}]";
                    Console.Write(kare + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Satranç tahtası oluşturuluyor
            SatrancTasi tahta = new SatrancTasi();

            // Tahtayı yazdırıyoruz
            Console.WriteLine("Satranç Tahtası Durumu:");
            tahta.TahtayiYazdir();

            // Kullanıcıdan bir kareye taş yerleştirme veya taşı öğrenme isteyelim
            Console.WriteLine("\nBir kareye taş yerleştirelim.");
            Console.Write("Satır (0-7): ");
            int satir = int.Parse(Console.ReadLine());
            Console.Write("Sütun (0-7): ");
            int sutun = int.Parse(Console.ReadLine());
            Console.Write("Yerleştirilecek taşı girin (örn. Queen, Knight, vb.): ");
            string tas = Console.ReadLine();

            try
            {
                tahta[satir, sutun] = tas;  // Taşı yerleştir
                Console.WriteLine("Taş başarıyla yerleştirildi.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);  // Hata mesajı
            }

            // Tahtayı tekrar yazdıralım
            Console.WriteLine("\nGüncellenmiş Satranç Tahtası Durumu:");
            tahta.TahtayiYazdir();

            // Geçersiz bir kareye erişim denemesi
            try
            {
                Console.WriteLine("\nGeçersiz bir kareye erişim denemesi:");
                Console.WriteLine(tahta[8, 8]); // Geçersiz kare
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