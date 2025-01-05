using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzayMadeni
{
    class Program
    {
        static void Main(string[] args)
        {
            // Örnek enerji matrisini tanımlayın
            int[,] energyCosts = {
            { 1, 3, 1 },
            { 1, 5, 1 },
            { 4, 2, 1 }
        };

            // En az enerji harcayan yolu bul
            int minEnergy = FindMinEnergyPath(energyCosts);

            // Sonucu konsolda yazdır
            Console.WriteLine("En az enerji harcayan yolun maliyeti: " + minEnergy);

            // Konsolun kapanmaması için bir tuşa basılmasını bekle
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static int FindMinEnergyPath(int[,] costs)
        {
            int n = costs.GetLength(0);
            int[,] dp = new int[n, n];

            // Başlangıç hücresinin maliyetini al
            dp[0, 0] = costs[0, 0];

            // İlk satır
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + costs[0, j];
            }

            // İlk sütun
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + costs[i, 0];
            }

            // Diğer hücreler için dinamik programlama
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = costs[i, j] + Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]);
                }
            }

            // (N-1, N-1) hücresinin maliyetini döndür
            return dp[n - 1, n - 1];
        }
    }
}