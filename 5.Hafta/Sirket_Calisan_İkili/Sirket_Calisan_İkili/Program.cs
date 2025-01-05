using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirket_Calisan_İkili
{
    class PRogram
    {
        static void Main(string[] args)
        {
            // Şirket nesnelerini oluştur
            Sirket sirket1 = new Sirket("Techno A.Ş.", "İstanbul");
            Sirket sirket2 = new Sirket("Digital Corp.", "Ankara");

            // Çalışan nesnelerini oluştur
            Calisan calisan1 = new Calisan("Ali Yılmaz", "Yazılım Mühendisi", 15000);
            Calisan calisan2 = new Calisan("Ayşe Kara", "Proje Yöneticisi", 20000);
            Calisan calisan3 = new Calisan("Mehmet Demir", "Grafik Tasarımcı", 12000);
            Calisan calisan4 = new Calisan("Zeynep Ak", "Veri Analisti", 14000);

            // Çalışanları şirketlere ekle
            sirket1.CalisanEkle(calisan1);
            sirket1.CalisanEkle(calisan2);
            sirket2.CalisanEkle(calisan3);
            sirket2.CalisanEkle(calisan4);

            // Şirket bilgilerini ve çalışanlarını yazdır
            Console.WriteLine($"Şirket: {sirket1.Ad}");
            Console.WriteLine($"Lokasyon: {sirket1.Lokasyon}");
            Console.WriteLine("Çalışanlar:");
            foreach (var calisan in sirket1.Calisanlar)
            {
                Console.WriteLine($"- {calisan.Ad}, Pozisyon: {calisan.Pozisyon}, Maaş: {calisan.Maas:C}");
            }

            Console.WriteLine($"\nŞirket: {sirket2.Ad}");
            Console.WriteLine($"Lokasyon: {sirket2.Lokasyon}");
            Console.WriteLine("Çalışanlar:");
            foreach (var calisan in sirket2.Calisanlar)
            {
                Console.WriteLine($"- {calisan.Ad}, Pozisyon: {calisan.Pozisyon}, Maaş: {calisan.Maas:C}");
            }

            // Çalışan perspektifinden şirket bilgisini yazdır
            Console.WriteLine($"\n{calisan1.Ad} çalışanının şirketi: {calisan1.Sirket.Ad}");
            Console.WriteLine($"{calisan3.Ad} çalışanının şirketi: {calisan3.Sirket.Ad}");

            Console.ReadLine();
        }
    }
   
}

class Sirket
{
    public string Ad { get; set; }
    public string Lokasyon { get; set; }
    public List<Calisan> Calisanlar { get; set; }

    public Sirket(string ad, string lokasyon)
    {
        Ad = ad;
        Lokasyon = lokasyon;
        Calisanlar = new List<Calisan>();
    }

    public void CalisanEkle(Calisan calisan)
    {
        if (!Calisanlar.Contains(calisan))
        {
            Calisanlar.Add(calisan);
            calisan.SirketAta(this);
        }
    }
}

class Calisan
{
    public string Ad { get; set; }
    public string Pozisyon { get; set; }
    public decimal Maas { get; set; }
    public Sirket Sirket { get; set; }

    public Calisan(string ad, string pozisyon, decimal maas)
    {
        Ad = ad;
        Pozisyon = pozisyon;
        Maas = maas;
    }

    public void SirketAta(Sirket sirket)
    {
        if (Sirket != sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this))
            {
                sirket.Calisanlar.Add(this);
            }
        }
    }
}


