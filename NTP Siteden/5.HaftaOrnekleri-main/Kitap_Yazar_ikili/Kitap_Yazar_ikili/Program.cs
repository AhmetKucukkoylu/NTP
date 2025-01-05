using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_Yazar_ikili
{

    class Program
    {
        static void Main(string[] args)
        {
            Yazar yazar1 = new Yazar("Orhan Pamuk", 71);
            Yazar yazar2 = new Yazar("Elif Şafak", 52);

            Kitap kitap1 = new Kitap("Kar", 2002);
            Kitap kitap2 = new Kitap("Masumiyet Müzesi", 2008);
            Kitap kitap3 = new Kitap("Aşk", 2009);
            Kitap kitap4 = new Kitap("Ustam ve Ben", 2013);

            yazar1.KitapEkle(kitap1);
            yazar1.KitapEkle(kitap2);
            yazar2.KitapEkle(kitap3);
            yazar2.KitapEkle(kitap4);

            Console.WriteLine($"Yazar: {yazar1.Ad}, {yazar1.Yas} yaşında");
            Console.WriteLine("Kitapları:");
            foreach (var kitap in yazar1.Kitaplar)
            {
                Console.WriteLine($"- {kitap.Ad} ({kitap.YayinYili})");
            }

            Console.WriteLine($"\nYazar: {yazar2.Ad}, {yazar2.Yas} yaşında");
            Console.WriteLine("Kitapları:");
            foreach (var kitap in yazar2.Kitaplar)
            {
                Console.WriteLine($"- {kitap.Ad} ({kitap.YayinYili})");
            }

            Console.WriteLine($"\n{kitap1.Ad} kitabının yazarı: {kitap1.Yazar.Ad}");
            Console.WriteLine($"{kitap3.Ad} kitabının yazarı: {kitap3.Yazar.Ad}");
            Console.ReadLine();
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            if (!Kitaplar.Contains(kitap))
            {
                Kitaplar.Add(kitap);
                kitap.YazarAta(this);
            }
        }
    }

    class Kitap
    {
        public string Ad { get; set; }
        public int YayinYili { get; set; }
        public Yazar Yazar { get; set; }

        public Kitap(string ad, int yayinYili)
        {
            Ad = ad;
            YayinYili = yayinYili;
        }

        public void YazarAta(Yazar yazar)
        {
            if (Yazar != yazar)
            {
                Yazar = yazar;
                if (!yazar.Kitaplar.Contains(this))
                {
                    yazar.Kitaplar.Add(this);
                }
            }
        }
    }
}
