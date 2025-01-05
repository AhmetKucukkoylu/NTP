using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasta_Doktor
{
    class Program
    {
        static void Main(string[] args)
        {
            Doktor doktor1 = new Doktor("Dr. Ahmet Yılmaz", "Kardiyoloji");
            Doktor doktor2 = new Doktor("Dr. Ayşe Demir", "Nöroloji");

            Hasta hasta1 = new Hasta("Ali Kaya", 45);
            Hasta hasta2 = new Hasta("Zeynep Öz", 35);
            Hasta hasta3 = new Hasta("Mehmet Demir", 55);

            doktor1.HastaEkle(hasta1);
            doktor1.HastaEkle(hasta2);
            doktor2.HastaEkle(hasta3);

            Console.WriteLine($"Doktor: {doktor1.Ad} - {doktor1.Uzmanlik}");
            Console.WriteLine("Hastaları:");
            foreach (var hasta in doktor1.Hastalar)
            {
                Console.WriteLine($"- {hasta.Ad}, {hasta.Yas} yaşında");
            }

            Console.WriteLine($"\nDoktor: {doktor2.Ad} - {doktor2.Uzmanlik}");
            Console.WriteLine("Hastaları:");
            foreach (var hasta in doktor2.Hastalar)
            {
                Console.WriteLine($"- {hasta.Ad}, {hasta.Yas} yaşında");
            }

            Console.WriteLine($"\n{hasta1.Ad}'nın doktoru: {hasta1.Doktor.Ad}");
            Console.WriteLine($"{hasta2.Ad}'in doktoru: {hasta2.Doktor.Ad}");
            Console.WriteLine($"{hasta3.Ad}'in doktoru: {hasta3.Doktor.Ad}");

            Console.ReadLine();
        }
    }

    class Doktor
    {
        public string Ad { get; set; }
        public string Uzmanlik { get; set; }
        public List<Hasta> Hastalar { get; set; }

        public Doktor(string ad, string uzmanlik)
        {
            Ad = ad;
            Uzmanlik = uzmanlik;
            Hastalar = new List<Hasta>();
        }

        public void HastaEkle(Hasta hasta)
        {
            if (!Hastalar.Contains(hasta))
            {
                Hastalar.Add(hasta);
                hasta.DoktorAta(this);
            }
        }
    }

    class Hasta
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Doktor Doktor { get; set; }

        public Hasta(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void DoktorAta(Doktor doktor)
        {
            if (Doktor != doktor)
            {
                Doktor = doktor;
                if (!doktor.Hastalar.Contains(this))
                {
                    doktor.Hastalar.Add(this);
                }
            }
        }
    }
}
