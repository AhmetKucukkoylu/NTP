using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main()
        {
            // Kullanıcıdan N değerini alıyoruz
            Console.Write("N sayısını girin: ");
            int N = int.Parse(Console.ReadLine());

            // Asal sayıların toplamını hesaplıyoruz
            int toplam = AsalSayilarinToplaminiBul(N);

            // Sonucu ekrana yazdırıyoruz
            Console.WriteLine($"1'den {N}'e kadar olan asal sayıların toplamı: {toplam}");

            // Sonucu görmek için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nEkrani kapatmak için bir tuşa basın...");
            Console.ReadKey();  // Konsolun hemen kapanmasını önlemek için
        }

        // N'e kadar olan asal sayıların toplamını bulmak için fonksiyon
        static int AsalSayilarinToplaminiBul(int N)
        {
            int toplam = 0;

            for (int i = 2; i <= N; i++)
            {
                if (AsalMi(i))
                {
                    toplam += i;
                }
            }

            return toplam;
        }

        // Bir sayının asal olup olmadığını kontrol eden fonksiyon
        static bool AsalMi(int sayi)
        {
            if (sayi < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0)
                    return false;
            }

            return true;
        }
    }
}
