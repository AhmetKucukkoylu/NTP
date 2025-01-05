using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgisayar_Islemci
{
    class Program
    {
        static void Main(string[] args)
        {
            // Örnek bilgisayar oluşturma
            Bilgisayar bilgisayar1 = new Bilgisayar("HP", "Intel i7", 3.4, 8);
            Bilgisayar bilgisayar2 = new Bilgisayar("Dell", "AMD Ryzen 7", 4.0, 12);

            // Bilgisayarların işlemci bilgilerini gösterme
            Console.WriteLine($"Bilgisayar 1 ({bilgisayar1.Marka}) işlemci özellikleri:");
            bilgisayar1.Islemci.IslemciBilgisi();

            Console.WriteLine($"\nBilgisayar 2 ({bilgisayar2.Marka}) işlemci özellikleri:");
            bilgisayar2.Islemci.IslemciBilgisi();

            Console.ReadLine();
        }
    }
    class Islemci
    {
        public string Model { get; set; }
        public double HizGHz { get; set; }
        public int CekirdekSayisi { get; set; }

        public Islemci(string model, double hizGHz, int cekirdekSayisi)
        {
            Model = model;
            HizGHz = hizGHz;
            CekirdekSayisi = cekirdekSayisi;
        }

        public void IslemciBilgisi()
        {
            Console.WriteLine($"Model: {Model}, Hız: {HizGHz}GHz, Çekirdek Sayısı: {CekirdekSayisi}");
        }
    }

    class Bilgisayar
    {
        public string Marka { get; set; }
        public Islemci Islemci { get; private set; }  // private set ile dışarıdan değiştirilmesi engellenir

        public Bilgisayar(string marka, string islemciModel, double islemciHiz, int cekirdekSayisi)
        {
            Marka = marka;
            // Bilgisayar oluşturulduğunda işlemci de oluşturulur
            Islemci = new Islemci(islemciModel, islemciHiz, cekirdekSayisi);
        }
    }
}
