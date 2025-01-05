using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urun_Siparis
{
    class Program
    {
        static void Main(string[] args)
        {
            Siparis sip1 = new Siparis(DateTime.Now,"Hazırlanıyor");

            Urun iphone = new Urun("iphone 20", "054534534");
            iphone.SiparisVer(sip1);

            Console.ReadLine();
        }
    }
    class Siparis
    {
        public DateTime Tarih { get; set; }

        public string Durum { get; set; }

        public Siparis(DateTime Tarih,string Durum)
        {
            this.Tarih = Tarih;
            this.Durum = Durum;
        }
    }
    class Urun
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }

        public Urun(string Ad,string Telefon)
        {
            this.Ad = Ad;
            this.Telefon = Telefon;
        }
        public void SiparisVer(Siparis siparis)
        {
            Console.WriteLine($"{Ad} için sipariş oluşturuldu!");
            Console.WriteLine($"Sipariş Durumu:{siparis.Durum}");

        }

    }
}
