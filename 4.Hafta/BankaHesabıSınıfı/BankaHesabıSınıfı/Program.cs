using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaHesabıSınıfı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Yeni bir BankaHesabi nesnesi oluştur
            BankaHesabi hesap = new BankaHesabi("123456789", 1000m);

            // Başlangıç bakiyesini ekrana yazdır
            Console.WriteLine($"Hesap Numarası: {hesap.HesapNumarasi}");
            Console.WriteLine($"Başlangıç Bakiyesi: {hesap.Bakiye} TL");

            // Para yatırma işlemi
            hesap.ParaYatir(500m);
            Console.WriteLine($"Para yatırma işleminden sonra bakiye: {hesap.Bakiye} TL");

            // Para çekme işlemi - başarılı
            hesap.ParaCek(200m);
            Console.WriteLine($"Para çekiminden sonra bakiye: {hesap.Bakiye} TL");

            // Para çekme işlemi - başarısız (yetersiz bakiye)
            hesap.ParaCek(1500m);
            Console.WriteLine($"Son bakiye: {hesap.Bakiye} TL");

            // Konsolun kapanmasını önlemek için bekleme ekliyoruz
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    public class BankaHesabi
    {
        // Özellikler
        public string HesapNumarasi { get; private set; }
        private decimal bakiye;

        // Bakiye özelliği için yalnızca sınıf içinden erişilebilen set metodu
        public decimal Bakiye
        {
            get { return bakiye; }
            private set { bakiye = value; }
        }

        // Yapıcı metot: Hesap numarası ve ilk bakiyeyi başlatır
        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        // Para Yatırma metodu
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Güncel Bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yatırılacak miktar pozitif olmalıdır.");
            }
        }

        // Para Çekme metodu
        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel Bakiye: {Bakiye} TL");
            }
            else if (miktar > 0)
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
            }
            else
            {
                Console.WriteLine("Çekilecek miktar pozitif olmalıdır.");
            }
        }
    }