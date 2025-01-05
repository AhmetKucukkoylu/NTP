using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekilAlanlari
{
    class Program
    {
        // İlk sürüm: Karenin alanını hesaplar (bir kenar uzunluğu verilerek).
        public static double Alan(int kenar)
        {
            return kenar * kenar;
        }

        // İkinci sürüm: Dikdörtgenin alanını hesaplar (iki kenar uzunluğu verilerek).
        public static double Alan(int uzunluk, int genislik)
        {
            return uzunluk * genislik;
        }

        // Üçüncü sürüm: Dairenin alanını hesaplar (yarıçap verilerek).
        public static double Alan(double yaricap)
        {
            return Math.PI * yaricap * yaricap;
        }

        static void Main(string[] args)
        {
            // İlk sürümü test edelim: Karenin alanı
            Console.WriteLine("Karenin alanı (kenar uzunluğu 5): " + Alan(5)); // 25

            // İkinci sürümü test edelim: Dikdörtgenin alanı
            Console.WriteLine("Dikdörtgenin alanı (uzunluk 5, genişlik 10): " + Alan(5, 10)); // 50

            // Üçüncü sürümü test edelim: Dairenin alanı
            Console.WriteLine("Dairenin alanı (yarıçap 7): " + Alan(7.0)); // 153.93804002589985

            // Ekranın açık kalması için
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}