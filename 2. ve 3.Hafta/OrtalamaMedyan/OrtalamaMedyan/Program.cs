using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtalamaMedyan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int input;

            // Kullanıcıdan pozitif tam sayılar alın
            Console.WriteLine("Pozitif tam sayıları girin (Durdurmak için 0 girin):");

            while (true)
            {
                input = int.Parse(Console.ReadLine());

                if (input == 0) break; // 0 girildiğinde döngüyü sonlandır
                if (input > 0) numbers.Add(input); // Pozitif sayıları listeye ekle
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Hiçbir pozitif sayı girilmedi.");
            }
            else
            {
                // Ortalama hesaplama
                double average = numbers.Average();

                // Medyan hesaplama
                numbers.Sort();
                double median;
                int mid = numbers.Count / 2;
                if (numbers.Count % 2 == 0)
                {
                    // Çift sayıda eleman varsa ortadaki iki sayının ortalaması
                    median = (numbers[mid - 1] + numbers[mid]) / 2.0;
                }
                else
                {
                    // Tek sayıda eleman varsa ortadaki sayı
                    median = numbers[mid];
                }

                // Sonuçları ekrana yazdırma
                Console.WriteLine("Ortalama: " + average);
                Console.WriteLine("Medyan: " + median);
            }

            // Konsolun hemen kapanmaması için bekleme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}