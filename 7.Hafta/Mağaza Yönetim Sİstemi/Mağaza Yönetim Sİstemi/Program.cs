using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mağaza_Yönetim_Sİstemi
{// Soyut Urun Sınıfı
    public abstract class Urun
    {
        public string Ad { get; private set; }
        public decimal Fiyat { get; private set; }

        protected Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public abstract decimal HesaplaOdeme();

        public abstract void BilgiYazdir();
    }

    // Kitap Sınıfı
    public class Kitap : Urun
    {
        public string Yazar { get; private set; }

        public Kitap(string ad, decimal fiyat, string yazar) : base(ad, fiyat)
        {
            Yazar = yazar;
        }

        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.10m); // %10 vergi ekleniyor
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Kitap: {Ad}, Yazar: {Yazar}, Fiyat: {Fiyat:C}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    // Elektronik Sınıfı
    public class Elektronik : Urun
    {
        public string Marka { get; private set; }

        public Elektronik(string ad, decimal fiyat, string marka) : base(ad, fiyat)
        {
            Marka = marka;
        }

        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.25m); // %25 vergi ekleniyor
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine($"Elektronik: {Ad}, Marka: {Marka}, Fiyat: {Fiyat:C}, Ödenecek Tutar: {HesaplaOdeme():C}");
        }
    }

    // Test Programı
    class Program
    {
        static void Main(string[] args)
        {
            List<Urun> urunler = new List<Urun>();

            // Ürünleri oluşturma
            Kitap kitap1 = new Kitap("Sırça Fanus", 50, "Sylvia Plath");
            Elektronik elektronik1 = new Elektronik("Dizüstü Bilgisayar", 5000, "Dell");

            urunler.Add(kitap1);
            urunler.Add(elektronik1);

            // Ürün bilgilerini yazdırma
            Console.WriteLine("--- Ürün Bilgileri ---");
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }
        }
    }
}