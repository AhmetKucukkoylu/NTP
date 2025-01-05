using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmasikSayiHesaplama
{
    public struct KarmaşikSayı
    {
        // Gerçek ve sanal kısımlar
        public double Real { get; set; }
        public double Imaginary { get; set; }

        // Yapıcı metod: Gerçek ve sanal kısmı alır
        public KarmaşikSayı(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Karmaşık sayıları toplama işlemi
        public static KarmaşikSayı operator +(KarmaşikSayı a, KarmaşikSayı b)
        {
            return new KarmaşikSayı(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        // Karmaşık sayıları çıkarma işlemi
        public static KarmaşikSayı operator -(KarmaşikSayı a, KarmaşikSayı b)
        {
            return new KarmaşikSayı(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        // Sonucu "a + bi" formatında döndüren ToString metodu
        public override string ToString()
        {
            // Eğer sanal kısım sıfır ise sadece gerçek kısmı göster
            if (Imaginary == 0)
                return $"{Real}";
            // Eğer sanal kısım negatifse, - işareti ekle
            else if (Imaginary < 0)
                return $"{Real} - {-Imaginary}i";
            else
                return $"{Real} + {Imaginary}i";
        }
    }

    class Program
    {
        static void Main()
        {
            // Karmaşık sayılar oluşturuyoruz
            KarmaşikSayı sayi1 = new KarmaşikSayı(3, 4);  // 3 + 4i
            KarmaşikSayı sayi2 = new KarmaşikSayı(1, 2);  // 1 + 2i

            // Karmaşık sayıları ekliyoruz
            KarmaşikSayı toplam = sayi1 + sayi2;
            Console.WriteLine($"Toplama Sonucu: {toplam}");

            // Karmaşık sayıları çıkarıyoruz
            KarmaşikSayı fark = sayi1 - sayi2;
            Console.WriteLine($"Çıkarma Sonucu: {fark}");

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}