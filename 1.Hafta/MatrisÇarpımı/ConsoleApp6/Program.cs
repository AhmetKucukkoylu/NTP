using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class MatrisCarpimi
    {
        static void Main()
        {
            // Kullanıcıdan NxN matris boyutunu alıyoruz
            Console.Write("Matris boyutunu girin (NxN): ");
            int N = int.Parse(Console.ReadLine());

            // İlk ve ikinci matrisleri oluşturuyoruz
            int[,] matris1 = new int[N, N];
            int[,] matris2 = new int[N, N];
            int[,] sonucMatris = new int[N, N];

            // İlk matrisi kullanıcıdan alıyoruz
            Console.WriteLine("Birinci matrisin elemanlarını girin:");
            MatrisOku(matris1, N);

            // İkinci matrisi kullanıcıdan alıyoruz
            Console.WriteLine("İkinci matrisin elemanlarını girin:");
            MatrisOku(matris2, N);

            // İki matrisin çarpımını hesaplıyoruz
            MatrisCarp(matris1, matris2, sonucMatris, N);

            // Sonuç matrisini ekrana yazdırıyoruz
            Console.WriteLine("Matrislerin çarpım sonucu:");
            MatrisYazdir(sonucMatris, N);

            // Sonucu görmek için bir tuşa basmayı bekliyoruz
            Console.WriteLine("\nEkrani kapatmak için bir tuşa basın...");
            Console.ReadKey();  // Konsolun hemen kapanmasını önlemek için
        }

        // Matrisi kullanıcıdan okuma fonksiyonu
        static void MatrisOku(int[,] matris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"Matris[{i},{j}] = ");
                    matris[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        // İki matrisin çarpımını hesaplayan fonksiyon
        static void MatrisCarp(int[,] matris1, int[,] matris2, int[,] sonucMatris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sonucMatris[i, j] = 0; // Başlangıç değeri
                    for (int k = 0; k < N; k++)
                    {
                        sonucMatris[i, j] += matris1[i, k] * matris2[k, j];
                    }
                }
            }
        }

        // Matrisi ekrana yazdıran fonksiyon
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