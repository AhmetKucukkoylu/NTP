using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapMakinesi
{
    class Program
    {
        // İlk sürüm: İki tam sayıyı toplar.
        public static int Topla(int a, int b)
        {
            return a + b;
        }

        // İkinci sürüm: Üç tam sayıyı toplar.
        public static int Topla(int a, int b, int c)
        {
            return a + b + c;
        }

        // Üçüncü sürüm: Bir dizi tam sayıyı toplar.
        public static int Topla(int[] sayilar)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam;
        }

        static void Main(string[] args)
        {
            // İlk sürümü test edelim.
            Console.WriteLine("İki sayının toplamı: " + Topla(5, 10)); // 15

            // İkinci sürümü test edelim.
            Console.WriteLine("Üç sayının toplamı: " + Topla(5, 10, 20)); // 35

            // Üçüncü sürümü test edelim.
            int[] dizi = { 5, 10, 15, 20 };
            Console.WriteLine("Dizinin toplamı: " + Topla(dizi)); // 50

            // Ekranın açık kalması için
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}