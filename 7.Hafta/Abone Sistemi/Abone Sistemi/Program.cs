using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abone_Sistemi
{
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void BildirimGonder(string mesaj);
    }

    // IAbone Arayüzü
    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    // Yayinci Sınıfı
    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
            Console.WriteLine("Abone eklendi.");
        }

        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
            Console.WriteLine("Abone çıkarıldı.");
        }

        public void BildirimGonder(string mesaj)
        {
            Console.WriteLine($"Yayıncı: '{mesaj}' mesajı gönderiliyor...");
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    // Abone Sınıfı
    public class Abone : IAbone
    {
        public string Ad { get; private set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} güncelleme aldı: {mesaj}");
        }
    }

    // Test Programı
    class Program
    {
        static void Main(string[] args)
        {
            Yayinci yayinci = new Yayinci();

            // Aboneler oluşturuluyor
            Abone abone1 = new Abone("Ahmet");
            Abone abone2 = new Abone("Ayşe");
            Abone abone3 = new Abone("Mehmet");

            // Aboneler yayıncıya ekleniyor
            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Yayıncıdan bildirim gönderiliyor
            yayinci.BildirimGonder("Yeni bir makale yayınlandı!");

            // Bir abone çıkarılıyor
            yayinci.AboneCikar(abone2);

            // Yeniden bildirim gönderiliyor
            yayinci.BildirimGonder("Bir başka makale yayınlandı!");
        }
    }

}