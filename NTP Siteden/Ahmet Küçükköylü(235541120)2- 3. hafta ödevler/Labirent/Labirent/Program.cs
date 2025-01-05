using System;
using System.Collections.Generic;
using System.Linq;

namespace Laurent
{
    class Program
    {
        static bool CanEnter(int x, int y)
        {
            // x ve y asal mı?
            if (!IsPrime(x) || !IsPrime(y))
                return false;

            // x + y, x * y'ye tam bölünebilir mi?
            if ((x + y) == 0 || (x * y) % (x + y) != 0)
                return false;

            return true;
        }

        static bool FindPath(int x, int y, int M, int N, List<(int x, int y)> path)
        {
            // Hedef noktaya ulaşıldı mı?
            if (x == M - 1 && y == N - 1)
            {
                path.Add((x, y));
                return true;
            }

            // Geçerli bir hücre mi?
            if (x < 0 || y < 0 || x >= M || y >= N || !CanEnter(x, y))
                return false;

            // Hücreyi kaydet
            path.Add((x, y));

            // Aşağı, yukarı, sağ, sol yönlerine hareket et
            if (FindPath(x + 1, y, M, N, path) ||  // Aşağı
                FindPath(x - 1, y, M, N, path) ||  // Yukarı
                FindPath(x, y + 1, M, N, path) ||  // Sağ
                FindPath(x, y - 1, M, N, path))     // Sol
            {
                return true;
            }

            // Eğer yol bulunamazsa hücreyi kaldır
            path.RemoveAt(path.Count - 1);
            return false;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int M = 5; // Labirentin satır sayısı
            int N = 5; // Labirentin sütun sayısı

            // Labirentteki adımların kaydedileceği bir liste
            List<(int x, int y)> path = new List<(int, int)>();

            // Başlangıç noktasından hedef noktasına yol bulma
            if (FindPath(0, 0, M, N, path))
            {
                Console.WriteLine("Şehre giden yol:");
                foreach (var step in path)
                {
                    Console.WriteLine($"({step.x}, {step.y})");
                }
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }

            // Konsolun kapanmaması için bir tuşa basılmasını bekle
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}