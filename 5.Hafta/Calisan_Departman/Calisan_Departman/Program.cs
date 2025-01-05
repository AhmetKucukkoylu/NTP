using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calisan_Departman
{
    class Program
    {
        static void Main(string[] args)
        {
            Departman dep1 = new Departman("It", "Ankara");
            Departman dep2 = new Departman("Reklam","Antalya");

            Calisan calisan = new Calisan("Ahmet","Yönetici",dep1);

            Calisan calisan2 = new Calisan("Beşir","Yatırımcı",dep2);

            Calisan calisan3 = new Calisan("Ali","İşçi",new Departman("Amele","Hatay"));

            calisan.BilgiGoster();

            Console.ReadLine();



        }
    }

    class Departman
    {
       public string Ad { get; set; }
       public string Lokasyon { get; set; }

        public Departman(string Ad,string Lokasyon)
        {
            this.Ad = Ad;
            this.Lokasyon = Lokasyon;
        }

    }
    class Calisan
    {
       public string Ad { get; set; }
       public string Pozisyon { get; set; }
       public  Departman Departman { get; set; }


        public Calisan(string Ad,string Pozisyon,Departman Departman)
        {
            this.Ad = Ad;
            this.Pozisyon = Pozisyon;
            this.Departman = Departman;
        }


        public void DepartmanAtama(Departman departman) {

            this.Departman = departman;

        }

        public void BilgiGoster()
        {
            Console.WriteLine($"Ad:{Ad},Pozisyon:{Pozisyon},Departman:{Departman.Ad},Lokasyon:{Departman.Lokasyon}");
        }
    }
}
