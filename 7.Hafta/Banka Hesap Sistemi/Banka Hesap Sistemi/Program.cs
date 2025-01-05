using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka_Hesap_Sistemi
{
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; }
        string HesapOzeti();
    }

    // Soyut Hesap Sınıfı
    public abstract class Hesap : IBankaHesabi
    {
        public int HesapNo { get; private set; }
        public decimal Bakiye { get; protected set; }
        public DateTime HesapAcilisTarihi { get; private set; }

        protected Hesap(int hesapNo)
        {
            HesapNo = hesapNo;
            Bakiye = 0;
            HesapAcilisTarihi = DateTime.Now;
        }

        public virtual void ParaYatir(decimal miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("Yatirilacak miktar pozitif olmalidir.");
                return;
            }

            Bakiye += miktar;
            Console.WriteLine($"Hesap No: {HesapNo} - {miktar:C} yatirildi. Yeni bakiye: {Bakiye:C}");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("Çekilecek miktar pozitif olmalidir.");
                return;
            }

            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
                return;
            }

            Bakiye -= miktar;
            Console.WriteLine($"Hesap No: {HesapNo} - {miktar:C} cekildi. Yeni bakiye: {Bakiye:C}");
        }

        public abstract string HesapOzeti();
    }

    // BirikimHesabi Sınıfı
    public class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; private set; }

        public BirikimHesabi(int hesapNo, decimal faizOrani) : base(hesapNo)
        {
            FaizOrani = faizOrani;
        }

        public override void ParaYatir(decimal miktar)
        {
            base.ParaYatir(miktar);
            decimal faiz = miktar * FaizOrani / 100;
            Bakiye += faiz;
            Console.WriteLine($"Hesap No: {HesapNo} - Faiz: {faiz:C} eklendi. Yeni bakiye: {Bakiye:C}");
        }

        public override string HesapOzeti()
        {
            return $"Birikim Hesabi - Hesap No: {HesapNo}, Bakiye: {Bakiye:C}, Faiz Orani: {FaizOrani}%";
        }
    }

    // VadesizHesap Sınıfı
    public class VadesizHesap : Hesap
    {
        public decimal IslemUcreti { get; private set; }

        public VadesizHesap(int hesapNo, decimal islemUcreti) : base(hesapNo)
        {
            IslemUcreti = islemUcreti;
        }

        public override void ParaCek(decimal miktar)
        {
            decimal toplamMiktar = miktar + IslemUcreti;

            if (toplamMiktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye (islem ucreti dahil).\n");
                return;
            }

            base.ParaCek(toplamMiktar);
            Console.WriteLine($"Hesap No: {HesapNo} - {IslemUcreti:C} islem ucreti kesildi.");
        }

        public override string HesapOzeti()
        {
            return $"Vadesiz Hesap - Hesap No: {HesapNo}, Bakiye: {Bakiye:C}, Islem Ucreti: {IslemUcreti:C}";
        }
    }

    // Test Programı
    class Program
    {
        static void Main(string[] args)
        {
            List<Hesap> hesaplar = new List<Hesap>();

            // BirikimHesabi oluşturma
            Console.WriteLine("\n--- Birikim Hesabi ---");
            BirikimHesabi birikimHesabi = new BirikimHesabi(1001, 5);
            birikimHesabi.ParaYatir(1000);
            hesaplar.Add(birikimHesabi);

            // VadesizHesap oluşturma
            Console.WriteLine("\n--- Vadesiz Hesap ---");
            VadesizHesap vadesizHesap = new VadesizHesap(2001, 10);
            vadesizHesap.ParaYatir(500);
            vadesizHesap.ParaCek(100);
            hesaplar.Add(vadesizHesap);

            // Hesap özetlerini yazdırma
            Console.WriteLine("\n--- Hesap Özetleri ---");
            foreach (var hesap in hesaplar)
            {
                Console.WriteLine(hesap.HesapOzeti());
            }
        }
    }

}