using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urun_SiparisDecimal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Urun_Siparis_Sistemi
    {
        class Program
        {
            static void Main(string[] args)
            {

                Urun urun1 = new Urun("Laptop", 15000);
                Urun urun2 = new Urun("Mouse", 200);

                Siparis siparis1 = new Siparis();

                
                siparis1.UrunEkle(urun1);
                siparis1.UrunEkle(urun2);

               
                urun1.UrunBilgisi();
                urun2.UrunBilgisi();

                
                Console.WriteLine($"\nSipariş Tarihi: {siparis1.Tarih}");
                Console.WriteLine($"Sipariş Toplamı: {siparis1.Toplam:C}");

                Console.ReadLine();
            }
        }

        class Urun
        {
            public string Ad { get; set; }
            private int Fiyat { get; set; }

            public Urun(string ad, int fiyat)
            {
                Ad = ad;
                Fiyat = fiyat;
            }

            public void UrunBilgisi()
            {
                Console.WriteLine($"\nÜrün Adı: {Ad}");
                Console.WriteLine($"Fiyat: {Fiyat:C}");
            }

            public int GetFiyat()
            {
                return Fiyat;
            }
        }

        class Siparis
        {
            public DateTime Tarih { get; set; }
            public decimal Toplam { get; set; }
            private List<Urun> Urunler { get; set; }

            public Siparis()
            {
                Tarih = DateTime.Now;
                Toplam = 0;
                Urunler = new List<Urun>();
            }

            public void UrunEkle(Urun urun)
            {
                Urunler.Add(urun);
                Toplam += urun.GetFiyat();
            }
        }
    }
}
