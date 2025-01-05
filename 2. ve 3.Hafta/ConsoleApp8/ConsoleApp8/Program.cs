using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan dizi boyutunu al
            Console.Write("Kaç adet sayı gireceksiniz? ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            // Kullanıcıdan tam sayıları al
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Sayı {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Diziyi sıralama
            Array.Sort(numbers);
            Console.WriteLine("Sıralanmış dizi: " + string.Join(", ", numbers));

            // Kullanıcıdan aranacak sayıyı al
            Console.Write("Aramak istediğiniz sayıyı girin: ");
            int target = int.Parse(Console.ReadLine());

            // İkili arama algoritması ile sayıyı kontrol etme
            bool found = BinarySearch(numbers, target);

            // Sonucu ekrana yazdır
            if (found)
                Console.WriteLine($"{target} sayısı dizide bulunuyor.");
            else
                Console.WriteLine($"{target} sayısı dizide bulunmuyor.");

            // Konsolun hemen kapanmaması için bekleme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadLine();
        }

        // İkili arama metodu
        static bool BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == target)
                    return true;
                else if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }
    }
}
