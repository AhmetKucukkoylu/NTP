using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocuk_Ebeveyn
{

    class Program
    {
        static void Main(string[] args)
        {
            Ebeveyn ebeveyn1 = new Ebeveyn("Ahmet", 40);
            Ebeveyn ebeveyn2 = new Ebeveyn("Ayşe", 35);

            Cocuk cocuk1 = new Cocuk("Ali", 10);
            Cocuk cocuk2 = new Cocuk("Mehmet", 8);
            Cocuk cocuk3 = new Cocuk("Zeynep", 5);

            ebeveyn1.CocukEkle(cocuk1);
            ebeveyn1.CocukEkle(cocuk2);
            ebeveyn2.CocukEkle(cocuk3);

            ebeveyn1.CocuklariListele();
            ebeveyn2.CocuklariListele();

            cocuk1.EbeveynBilgisiGoster();
            cocuk2.EbeveynBilgisiGoster();
            cocuk3.EbeveynBilgisiGoster();

            Console.ReadLine();
        }
    }

    class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar { get; set; }

        public Ebeveyn(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
            Cocuklar = new List<Cocuk>();
        }

        public void CocukEkle(Cocuk cocuk)
        {
            if (!Cocuklar.Contains(cocuk))
            {
                Cocuklar.Add(cocuk);
                cocuk.EbeveynAta(this);
            }
        }

        public void CocuklariListele()
        {
            Console.WriteLine($"\n{Ad} isimli ebeveynin çocukları:");
            foreach (var cocuk in Cocuklar)
            {
                Console.WriteLine($"- {cocuk.Ad} ({cocuk.Yas} yaşında)");
            }
        }
    }

    class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        public Cocuk(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void EbeveynAta(Ebeveyn ebeveyn)
        {
            if (Ebeveyn != ebeveyn)
            {
                Ebeveyn = ebeveyn;
            }
        }

        public void EbeveynBilgisiGoster()
        {
            Console.WriteLine($"{Ad} isimli çocuğun ebeveyni: {Ebeveyn.Ad}");
        }
    }

    
}
