using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Kitap
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane1 = new Kutuphane(1, "Merkez Kütüphane", "İstanbul");
            Kutuphane kutuphane2 = new Kutuphane(2, "Halk Kütüphanesi", "Ankara");

            Kitap kitap1 = new Kitap(101, "Suç ve Ceza", "Dostoyevski", 687);
            Kitap kitap2 = new Kitap(102, "1984", "George Orwell", 352);
            Kitap kitap3 = new Kitap(103, "Şeker Portakalı", "Vasconcelos", 182);

            kutuphane1.KitapEkle(kitap1);
            kutuphane1.KitapEkle(kitap2);
            kutuphane2.KitapEkle(kitap3);

            kutuphane1.KitaplariListele();
            kutuphane2.KitaplariListele();

            kitap1.KitapBilgileriniGoster();
            kitap2.KitapBilgileriniGoster();
            kitap3.KitapBilgileriniGoster();

            Console.ReadLine();
        }
    }
    class Kutuphane
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        private List<Kitap> Kitaplar { get; set; }

        public Kutuphane(int id, string ad, string adres)
        {
            Id = id;
            Ad = ad;
            Adres = adres;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        public void KitaplariListele()
        {
            Console.WriteLine($"\n{Ad} kütüphanesindeki kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"- {kitap.Ad} ({kitap.Yazar})");
            }
        }
    }

    class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }

        public Kitap(int id, string ad, string yazar, int sayfaSayisi)
        {
            Id = id;
            Ad = ad;
            Yazar = yazar;
            SayfaSayisi = sayfaSayisi;
        }

        public void KitapBilgileriniGoster()
        {
            Console.WriteLine($"\nKitap ID: {Id}");
            Console.WriteLine($"Kitap Adı: {Ad}");
            Console.WriteLine($"Yazar: {Yazar}");
            Console.WriteLine($"Sayfa Sayısı: {SayfaSayisi}");
        }
    }

    
}
