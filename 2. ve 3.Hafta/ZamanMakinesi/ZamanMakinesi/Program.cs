using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamanMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geçerli tarihler:");

            // Bugünün tarihi
            DateTime today = DateTime.Today;

            // 2000 ile 3000 yılları arasında geçerli tarihler
            for (int year = 2000; year <= 3000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    // Ayın gün sayısını al
                    int daysInMonth = DateTime.DaysInMonth(year, month);

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        DateTime date = new DateTime(year, month, day);

                        // Bugünden sonraki tarihler
                        if (date > today && IsValidDate(day, month, year))
                        {
                            Console.WriteLine($"{day:D2}/{month:D2}/{year}"); // Çıktı formatı
                        }
                    }
                }
            }

            // Konsolun kapanmaması için bir tuşa basılmasını bekle
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static bool IsValidDate(int day, int month, int year)
        {
            // Gün asal sayı mı?
            if (!IsPrime(day))
                return false;

            // Ayın basamakları toplamı çift mi?
            if (!IsEvenDigitSum(month))
                return false;

            // Yıl rakamları toplamı, yılın dörtte birinden küçük mü?
            if (!IsDigitSumLessThanQuarter(year))
                return false;

            return true;
        }

        // Asal sayı kontrolü
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Ayın basamakları toplamı çift mi?
        static bool IsEvenDigitSum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum % 2 == 0;
        }

        // Yıl rakamları toplamı, yılın dörtte birinden küçük mü?
        static bool IsDigitSumLessThanQuarter(int year)
        {
            int sum = 0;
            int tempYear = year;

            while (tempYear > 0)
            {
                sum += tempYear % 10;
                tempYear /= 10;
            }

            return sum < year / 4;
        }
    }
}