using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Ogrenci
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Okul okul = new Okul("Atatürk İlköğretim Okulu");

            
            okul.OgrenciEkle("Ali", "Yılmaz", 101);
            okul.OgrenciEkle("Ayşe", "Demir", 102);
            okul.OgrenciEkle("Mehmet", "Kaya", 103);

            
            okul.OkulBilgisi();

            Console.ReadLine();
        }
    }
    class Ogrenci
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int OgrenciNo { get; set; }

        public Ogrenci(string ad, string soyad, int ogrenciNo)
        {
            Ad = ad;
            Soyad = soyad;
            OgrenciNo = ogrenciNo;
        }

        public void OgrenciBilgisi()
        {
            Console.WriteLine($"Öğrenci: {Ad} {Soyad}, Numara: {OgrenciNo}");
        }
    }

    class Okul
    {
        public string OkulAdi { get; set; }
        private readonly List<Ogrenci> Ogrenciler; // readonly ile liste referansının değiştirilmesi engellenir

        public Okul(string okulAdi)
        {
            OkulAdi = okulAdi;
            Ogrenciler = new List<Ogrenci>();
        }

        public void OgrenciEkle(string ad, string soyad, int ogrenciNo)
        {
            Ogrenciler.Add(new Ogrenci(ad, soyad, ogrenciNo));
        }

        public void OkulBilgisi()
        {
            Console.WriteLine($"\nOkul Adı: {OkulAdi}");
            Console.WriteLine("Öğrenci Listesi:");
            foreach (var ogrenci in Ogrenciler)
            {
                ogrenci.OgrenciBilgisi();
            }
        }
    }

    
}
