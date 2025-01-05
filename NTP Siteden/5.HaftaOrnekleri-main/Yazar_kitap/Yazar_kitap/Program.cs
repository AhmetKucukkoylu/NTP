using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazar_kitap
{
    class Program
    {
        static void Main(string[] args)
        {
            Yazar yazar = new Yazar("Victor Hugo", "Fransa");

            Kitap kitap1 = new Kitap("Sefiller", "ISBN123");
            Kitap kitap2 = new Kitap("Notre Dame'ın Kamburu", "ISBN456");

            yazar.KitapEkle(kitap1);
            yazar.KitapEkle(kitap2);

            foreach (Kitap kitap in yazar.Kitaplar)
            {
                Console.WriteLine($"Kitap: {kitap.Baslik}, ISBN: {kitap.isbn}");
            }

            Console.ReadLine();
        }
    }

    class Kitap
    {
        public string Baslik { get; set; }
        public string isbn { get; set; }

        public Kitap(string Baslik, string isbn)
        {
            this.Baslik = Baslik;
            this.isbn = isbn;
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string Ad, string Ulke)
        {
            this.Ad = Ad;
            this.Ulke = Ulke;
            this.Kitaplar = new List<Kitap>(); 
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }
}
