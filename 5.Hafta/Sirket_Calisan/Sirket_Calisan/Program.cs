using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirket_Calisan
{
    class Program
    {
        static void Main(string[] args)
        {
            Sirket sirket1 = new Sirket(1, "Teknoloji A.Ş.", "İstanbul");
            Sirket sirket2 = new Sirket(2, "Yazılım Ltd.", "Ankara");

            Calisan calisan1 = new Calisan(101, "Ali", "Yılmaz", "Yazılım", 15000);
            Calisan calisan2 = new Calisan(102, "Ayşe", "Demir", "İK", 12000);
            Calisan calisan3 = new Calisan(103, "Mehmet", "Kaya", "Pazarlama", 13000);

            sirket1.CalisanEkle(calisan1);
            sirket1.CalisanEkle(calisan2);
            sirket2.CalisanEkle(calisan3);

            sirket1.SirketBilgileriniGoster();
            sirket1.CalisanlariListele();

            sirket2.SirketBilgileriniGoster();
            sirket2.CalisanlariListele();

            calisan1.MaasArtir(2000);
            calisan1.CalisanBilgileriniGoster();

            Console.ReadLine();
        }
    }
    class Sirket
    {
        public int Id { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        private List<Calisan> Calisanlar { get; set; }

        public Sirket(int id, string sirketAdi, string adres)
        {
            Id = id;
            SirketAdi = sirketAdi;
            Adres = adres;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }

        public void CalisanlariListele()
        {
            Console.WriteLine($"\n{SirketAdi} şirketinin çalışanları:");
            foreach (var calisan in Calisanlar)
            {
                Console.WriteLine($"- {calisan.Ad} {calisan.Soyad} ({calisan.Departman})");
            }
        }

        public void SirketBilgileriniGoster()
        {
            Console.WriteLine($"Şirket ID: {Id}");
            Console.WriteLine($"Şirket Adı: {SirketAdi}");
            Console.WriteLine($"Adres: {Adres}");
        }
    }

    class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Departman { get; set; }
        public double Maas { get; set; }

        public Calisan(int id, string ad, string soyad, string departman, double maas)
        {
            Id = id;
            Ad = ad;
            Soyad = soyad;
            Departman = departman;
            Maas = maas;
        }

        public void MaasArtir(double artis)
        {
            Maas += artis;
        }

        public void CalisanBilgileriniGoster()
        {
            Console.WriteLine($"\nÇalışan ID: {Id}");
            Console.WriteLine($"Ad Soyad: {Ad} {Soyad}");
            Console.WriteLine($"Departman: {Departman}");
            Console.WriteLine($"Maaş: {Maas:C}");
        }
    }

   
}
