using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevamEdenDizi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int input;

            // Kullanıcıdan sayı girişi al
            Console.WriteLine("Tam sayıları girin (Durdurmak için 0 girin):");

            while (true)
            {
                input = int.Parse(Console.ReadLine());

                if (input == 0) break; // 0 girildiğinde döngüyü sonlandır
                numbers.Add(input); // Sayıyı listeye ekle
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Hiçbir sayı girilmedi.");
            }
            else
            {
                // Diziyi sıralama
                numbers.Sort();
                List<string> ranges = new List<string>();
                int start = numbers[0];
                int end = start;

                // Ardışık sayıları tespit etme
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] == end + 1)
                    {
                        end = numbers[i]; // Ardışık ise grubu genişlet
                    }
                    else
                    {
                        // Grup sona erdiğinde grubu kaydet
                        ranges.Add(start == end ? $"{start}" : $"{start}-{end}");
                        start = numbers[i];
                        end = start;
                    }
                }

                // Son grubu da ekle
                ranges.Add(start == end ? $"{start}" : $"{start}-{end}");

                // Sonuçları ekrana yazdırma
                Console.WriteLine("Ardışık sayı grupları: " + string.Join(", ", ranges));
            }

            // Konsolun hemen kapanmaması için bekleme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadLine();
        }
    }
}