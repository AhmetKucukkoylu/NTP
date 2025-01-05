using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsKonum
{
    public struct GPSKonumu
    {
        // Enlem ve Boylam özellikleri
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Yapıcı metod: Enlem ve Boylam değerlerini alır
        public GPSKonumu(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // Haversine formülünü kullanarak iki GPS konumu arasındaki mesafeyi hesaplayan metot
        public static double MesafeHesapla(GPSKonumu konum1, GPSKonumu konum2)
        {
            // Dünya yarıçapı (km cinsinden)
            const double R = 6371.0;

            // Enlem ve boylam farklarını radyan cinsine çevirme
            double lat1 = DegerToRadyan(konum1.Latitude);
            double lon1 = DegerToRadyan(konum1.Longitude);
            double lat2 = DegerToRadyan(konum2.Latitude);
            double lon2 = DegerToRadyan(konum2.Longitude);

            // Enlem ve boylam farkları
            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            // Haversine formülü
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Mesafeyi hesapla
            double mesafe = R * c;

            return mesafe;
        }

        // Dereceyi radyana dönüştüren yardımcı metot
        private static double DegerToRadyan(double derece)
        {
            return derece * (Math.PI / 180.0);
        }
    }

    class Program
    {
        static void Main()
        {
            // İki GPS konumu oluşturuyoruz
            GPSKonumu konum1 = new GPSKonumu(40.7128, -74.0060); // New York (Enlem: 40.7128, Boylam: -74.0060)
            GPSKonumu konum2 = new GPSKonumu(34.0522, -118.2437); // Los Angeles (Enlem: 34.0522, Boylam: -118.2437)

            // Mesafeyi hesaplıyoruz
            double mesafe = GPSKonumu.MesafeHesapla(konum1, konum2);

            // Sonucu ekrana yazdırıyoruz
            Console.WriteLine($"New York ile Los Angeles arasındaki mesafe: {mesafe:F2} kilometre");

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}