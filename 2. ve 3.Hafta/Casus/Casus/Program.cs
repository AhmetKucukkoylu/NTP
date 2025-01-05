using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Şifreli mesajı burada tanımlayın
            string encryptedMessage = "şifreli mesajınızı buraya yazın"; // Örnek bir şifreli mesaj

            // Mesajı çöz
            string decryptedMessage = DecryptMessage(encryptedMessage);

            // Sonucu konsolda yazdır
            Console.WriteLine("Orijinal Mesaj: " + decryptedMessage);

            // Konsolun kapanmaması için bir tuşa basılmasını bekle
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static string DecryptMessage(string encryptedMessage)
        {
            StringBuilder originalMessage = new StringBuilder();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                char encryptedChar = encryptedMessage[i];
                int position = i + 1; // Pozisyon 1'den başlar

                // Her karakterin ASCII değeri
                int encryptedAsciiValue = (int)encryptedChar;

                // Fibonacci değerini hesapla
                int fibonacciValue = Fibonacci(position);

                // Mod çözümleme
                int asciiValue;

                // Asal sayı kontrolü
                if (IsPrime(position))
                {
                    asciiValue = (encryptedAsciiValue + 100) % 100; // Asal pozisyon
                }
                else
                {
                    asciiValue = (encryptedAsciiValue + 256) % 256; // Asal değil
                }

                // Orijinal ASCII değerini bul
                int originalAsciiValue = asciiValue / fibonacciValue;

                // Orijinal karakteri ekle
                originalMessage.Append((char)originalAsciiValue);
            }

            return originalMessage.ToString();
        }

        static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1 || n == 2) return 1;

            int a = 1, b = 1, c = 0;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}