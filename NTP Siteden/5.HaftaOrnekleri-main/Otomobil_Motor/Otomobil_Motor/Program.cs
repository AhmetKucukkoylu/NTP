using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomobil_Motor
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Otomobil otomobil1 = new Otomobil("BMW", "320i", "Benzinli", 2.0, 184);
            Otomobil otomobil2 = new Otomobil("Mercedes", "C200", "Dizel", 1.6, 160);

            
            Console.WriteLine("Birinci Otomobil Bilgileri:");
            otomobil1.OtomobilBilgisi();

            Console.WriteLine("\nİkinci Otomobil Bilgileri:");
            otomobil2.OtomobilBilgisi();

            Console.ReadLine();
        }
    }
    class Motor
    {
        public string MotorTipi { get; set; }
        public double HacimLt { get; set; }
        public int BeygirGucu { get; set; }

        public Motor(string motorTipi, double hacimLt, int beygirGucu)
        {
            MotorTipi = motorTipi;
            HacimLt = hacimLt;
            BeygirGucu = beygirGucu;
        }

        public void MotorBilgisi()
        {
            Console.WriteLine($"Motor Tipi: {MotorTipi}, Hacim: {HacimLt}Lt, Beygir Gücü: {BeygirGucu}HP");
        }
    }

    class Otomobil
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        private readonly Motor Motor; // readonly ile motorun değiştirilmesi engellenir

        public Otomobil(string marka, string model, string motorTipi, double hacimLt, int beygirGucu)
        {
            Marka = marka;
            Model = model;
            Motor = new Motor(motorTipi, hacimLt, beygirGucu); // Otomobil oluşturulduğunda motor da oluşturulur
        }

        public void OtomobilBilgisi()
        {
            Console.WriteLine($"Marka: {Marka}, Model: {Model}");
            Motor.MotorBilgisi();
        }
    }

   
}
