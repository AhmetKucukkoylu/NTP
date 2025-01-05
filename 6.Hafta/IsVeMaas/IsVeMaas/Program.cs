using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsVeMaas
{
    public enum CalisanRol
    {
        Manager,  // Yönetici
        Developer, // Yazılım Geliştirici
        Designer,  // Tasarımcı
        Tester     // Test Uzmanı
    }

    public class MaaşHesaplayici
    {
        // Maaş hesaplama metodu
        public static double MaasHesapla(CalisanRol rol)
        {
            switch (rol)
            {
                case CalisanRol.Manager:
                    return 8000;  // Yöneticinin maaşı
                case CalisanRol.Developer:
                    return 6000;  // Yazılım geliştiricinin maaşı
                case CalisanRol.Designer:
                    return 5000;  // Tasarımcının maaşı
                case CalisanRol.Tester:
                    return 4000;  // Test uzmanının maaşı
                default:
                    throw new ArgumentException("Geçersiz çalışan rolü.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Farklı roller için maaş hesaplaması yapalım
            CalisanRol rol = CalisanRol.Manager;
            Console.WriteLine($"Yönetici maaşı: {MaaşHesaplayici.MaasHesapla(rol)} TL");

            rol = CalisanRol.Developer;
            Console.WriteLine($"Yazılım Geliştirici maaşı: {MaaşHesaplayici.MaasHesapla(rol)} TL");

            rol = CalisanRol.Designer;
            Console.WriteLine($"Tasarımcı maaşı: {MaaşHesaplayici.MaasHesapla(rol)} TL");

            rol = CalisanRol.Tester;
            Console.WriteLine($"Test Uzmanı maaşı: {MaaşHesaplayici.MaasHesapla(rol)} TL");

            // Çıkmak için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}