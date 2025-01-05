using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class SpiralMatris
    {
        static void Main()
        {
            Console.Write("Matris boyutunu girin (NxN): ");
            int N = int.Parse(Console.ReadLine());

            int[,] matris = new int[N, N];
            SpiralMatrisOlustur(matris, N);
            MatrisYazdir(matris, N);

            // Sonucu görmek için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nEkranı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static void SpiralMatrisOlustur(int[,] matris, int N)
        {
            int sayi = 1;
            int sol = 0, sag = N - 1;
            int ust = 0, alt = N - 1;

            while (sayi <= N * N)
            {
                // Sol -> Sağ yönünde ilerleme
                for (int i = sol; i <= sag; i++)
                {
                    matris[ust, i] = sayi++;
                }
                ust++;

                // Yukarı -> Aşağı yönünde ilerleme
                for (int i = ust; i <= alt; i++)
                {
                    matris[i, sag] = sayi++;
                }
                sag--;

                // Sağ -> Sol yönünde ilerleme
                for (int i = sag; i >= sol; i--)
                {
                    matris[alt, i] = sayi++;
                }
                alt--;

                // Aşağı -> Yukarı yönünde ilerleme
                for (int i = alt; i >= ust; i--)
                {
                    matris[i, sol] = sayi++;
                }
                sol++;
            }
        }

        static void MatrisYazdir(int[,] matris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matris[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
