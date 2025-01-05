using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayinTarlasi
{
    class Program
    {
        static void Main()
        {
            bool playAgain = true;
            while (playAgain)
            {
                PlayGame();
                Console.WriteLine("Tekrar oynamak ister misiniz? (E/H):");
                string response = Console.ReadLine().Trim().ToUpper();
                playAgain = response == "E";
            }
        }

        static void PlayGame()
        {
            int rows = 20, cols = 20; // Oyun alanı boyutları
            int mineCount = 50;        // Mayın sayısı
            char[,] board = new char[rows, cols];
            bool[,] mines = new bool[rows, cols];
            bool[,] revealed = new bool[rows, cols]; // Açılan hücreleri takip eder
            bool[,] flags = new bool[rows, cols];     // Bayrakları takip eder

            InitializeBoard(board);
            PlaceMines(mines, mineCount);

            bool gameOver = false;
            int flagsPlaced = 0;

            while (!gameOver)
            {
                Console.Clear();
                DisplayBoard(board, revealed, flags, mineCount - flagsPlaced);
                Console.WriteLine("Bir hücre seçin (örnek: 2 3):");
                string[] input = Console.ReadLine().Split();

                if (input.Length != 2 ||
                    !int.TryParse(input[0], out int x) ||
                    !int.TryParse(input[1], out int y) ||
                    x < 0 || x >= rows ||
                    y < 0 || y >= cols)
                {
                    Console.WriteLine("Geçersiz giriş! Tekrar deneyin.");
                    Console.WriteLine("Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Bayrak koymak için 'B', açmak için herhangi bir tuşa basın:");
                string moveType = Console.ReadLine().Trim().ToUpper();

                if (moveType == "B")
                {
                    flags[x, y] = !flags[x, y];
                    flagsPlaced += flags[x, y] ? 1 : -1;
                }
                else
                {
                    if (flags[x, y])
                    {
                        Console.WriteLine("Bu hücre bayraklı! Bayrağı kaldırmadan açamazsınız.");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        continue;
                    }

                    if (mines[x, y])
                    {
                        revealed[x, y] = true;
                        board[x, y] = '*';
                        Console.Clear();
                        DisplayBoard(board, revealed, flags, mineCount - flagsPlaced);
                        Console.WriteLine("Mayına bastınız! Oyun bitti.");
                        RevealAllMines(mines, revealed);
                        DisplayBoard(board, revealed, flags, mineCount - flagsPlaced);
                        gameOver = true;
                    }
                    else
                    {
                        RevealCell(board, revealed, mines, x, y);
                        if (IsWin(revealed, mines))
                        {
                            Console.Clear();
                            DisplayBoard(board, revealed, flags, mineCount - flagsPlaced);
                            Console.WriteLine("Tebrikler, tüm mayınlardan kaçındınız!");
                            gameOver = true;
                        }
                    }
                }
            }
        }

        static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = '-';
        }

        static void PlaceMines(bool[,] mines, int mineCount)
        {
            Random rand = new Random();
            int placed = 0;

            while (placed < mineCount)
            {
                int x = rand.Next(mines.GetLength(0));
                int y = rand.Next(mines.GetLength(1));
                if (!mines[x, y])
                {
                    mines[x, y] = true;
                    placed++;
                }
            }
        }

        static void RevealCell(char[,] board, bool[,] revealed, bool[,] mines, int x, int y)
        {
            if (x < 0 || x >= board.GetLength(0) ||
                y < 0 || y >= board.GetLength(1) ||
                revealed[x, y])
            {
                return;
            }

            revealed[x, y] = true;
            int adjacentMines = CountAdjacentMines(mines, x, y);
            board[x, y] = adjacentMines > 0 ? adjacentMines.ToString()[0] : ' ';

            if (adjacentMines == 0)
            {
                // Çevresel boş hücreleri de aç
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0)
                            RevealCell(board, revealed, mines, x + i, y + j);
                    }
                }
            }
        }

        static int CountAdjacentMines(bool[,] mines, int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newX < mines.GetLength(0) &&
                        newY >= 0 && newY < mines.GetLength(1) &&
                        mines[newX, newY])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static void DisplayBoard(char[,] board, bool[,] revealed, bool[,] flags, int remainingMines)
        {
            Console.WriteLine($"Kalan Mayın: {remainingMines}");
            Console.Write("    "); // Satır numaralarının hizalanması için boşluk

            // Sütun numaralarını yazdır
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(j.ToString().PadLeft(3)); // Sütun numaralarını düzgün hizalar
            }
            Console.WriteLine();

            // Oyun tahtasını yazdır
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(i.ToString().PadLeft(3) + " "); // Satır numaralarını hizala
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (revealed[i, j])
                    {
                        Console.Write(board[i, j] + "  "); // Açılmış hücre
                    }
                    else if (flags[i, j])
                    {
                        Console.Write("F  "); // Bayraklı hücre
                    }
                    else
                    {
                        Console.Write("-  "); // Kapalı hücre
                    }
                }
                Console.WriteLine();
            }
        }

        static void RevealAllMines(bool[,] mines, bool[,] revealed)
        {
            for (int i = 0; i < mines.GetLength(0); i++)
            {
                for (int j = 0; j < mines.GetLength(1); j++)
                {
                    if (mines[i, j])
                    {
                        revealed[i, j] = true;
                    }
                }
            }
        }

        static bool IsWin(bool[,] revealed, bool[,] mines)
        {
            for (int i = 0; i < revealed.GetLength(0); i++)
            {
                for (int j = 0; j < revealed.GetLength(1); j++)
                {
                    if (!revealed[i, j] && !mines[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}