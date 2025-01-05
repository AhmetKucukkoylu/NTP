using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev_Oda
{

    class Program
    {
        static void Main(string[] args)
        {
            Ev ev1 = new Ev("Bahçelievler Mah. No:5", 120);
            Ev ev2 = new Ev("Çiçek Sok. No:12", 85);

            Oda salon = new Oda("Salon", 30, "Laminant");
            Oda mutfak = new Oda("Mutfak", 15, "Seramik");
            Oda yatak1 = new Oda("Yatak Odası", 20, "Halı");
            Oda yatak2 = new Oda("Çocuk Odası", 18, "Parke");

            ev1.OdaEkle(salon);
            ev1.OdaEkle(mutfak);
            ev1.OdaEkle(yatak1);

            ev2.OdaEkle(yatak2);
            ev2.OdaEkle(new Oda("Oturma Odası", 25, "Laminant"));

            ev1.OdalariListele();
            ev2.OdalariListele();

            Console.WriteLine("\nOda Detayları:");
            salon.OdaBilgileriniGoster();
            mutfak.OdaBilgileriniGoster();

            Console.ReadLine();
        }
    }
    class Ev
    {
        public string Adres { get; set; }
        public int MetreKare { get; set; }
        private List<Oda> Odalar { get; set; }

        public Ev(string adres, int metreKare)
        {
            Adres = adres;
            MetreKare = metreKare;
            Odalar = new List<Oda>();
        }

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }

        public void OdalariListele()
        {
            Console.WriteLine($"\n{Adres} adresindeki {MetreKare}m² evin odaları:");
            foreach (var oda in Odalar)
            {
                Console.WriteLine($"- {oda.OdaAdi} ({oda.MetreKare}m²)");
            }
        }
    }

    class Oda
    {
        public string OdaAdi { get; set; }
        public int MetreKare { get; set; }
        public string ZeminTipi { get; set; }

        public Oda(string odaAdi, int metreKare, string zeminTipi)
        {
            OdaAdi = odaAdi;
            MetreKare = metreKare;
            ZeminTipi = zeminTipi;
        }

        public void OdaBilgileriniGoster()
        {
            Console.WriteLine($"{OdaAdi} - {MetreKare}m² - Zemin: {ZeminTipi}");
        }
    }

  

}
