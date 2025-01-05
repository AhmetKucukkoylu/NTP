using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneSınıfı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir kütüphane oluştur
            Kutuphane kutuphane = new Kutuphane();

            // Yeni kitaplar oluştur
            Kitap kitap1 = new Kitap("C# Programlamaya Giriş", "Yazar1");
            Kitap kitap2 = new Kitap("Veri Yapıları ve Algoritmalar", "Yazar2");
            Kitap kitap3 = new Kitap("Temel Matematik", "Yazar3");

            // Kitapları kütüphaneye ekle
            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);
            kutuphane.KitapEkle(kitap3);

            // Kitapları listele
            kutuphane.KitaplariListele();

            // Konsolun kapanmasını önlemek için bekletme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    public class Kitap
    {
        // Kitap özellikleri
        public string Ad { get; private set; }
        public string Yazar { get; private set; }

        // Yapıcı metot
        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }

    public class Kutuphane
    {
        // Kitap listesi
        private List<Kitap> Kitaplar;

        // Yapıcı metot: Kitap listesi boş olarak başlatılır
        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
        }

        // Kitap ekleme metodu
        public void KitapEkle(Kitap yeniKitap)
        {
            this.Kitaplar.Add(yeniKitap); // Kitaplar listesine yeni kitabı ekle
            Console.WriteLine($"{yeniKitap.Ad} adlı kitap kütüphaneye eklendi.");
        }

        // Kitapları listeleme metodu
        public void KitaplariListele()
        {
            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"Ad: {kitap.Ad}, Yazar: {kitap.Yazar}");
            }
        }
    }
}