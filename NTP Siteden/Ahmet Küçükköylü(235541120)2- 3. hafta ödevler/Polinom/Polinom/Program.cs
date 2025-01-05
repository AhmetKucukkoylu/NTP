using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Polinom
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nBirinci polinomu girin (örneğin: 2x^2 + 3x - 5 veya 'exit' ile çıkın): ");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "exit") break;

                Console.WriteLine("İkinci polinomu girin (örneğin: x^2 - 4): ");
                string input2 = Console.ReadLine();
                if (input2.ToLower() == "exit") break;

                Polinom polinom1 = new Polinom(input1);
                Polinom polinom2 = new Polinom(input2);

                Polinom toplam = polinom1 + polinom2;
                Polinom fark = polinom1 - polinom2;

                Console.WriteLine($"\nToplam: {toplam}");
                Console.WriteLine($"Fark: {fark}");
            }
        }
    }

    class Polinom
    {
        private Dictionary<int, int> terms; // Derece -> Katsayı

        public Polinom(string expression)
        {
            terms = new Dictionary<int, int>();
            ParseExpression(expression);
        }

        // Polinom ifadesini parçalar
        private void ParseExpression(string expression)
        {
            expression = expression.Replace(" ", ""); // Boşlukları kaldır
            var termMatches = Regex.Matches(expression, @"([+-]?\d*)x?(\^(\d+))?");

            foreach (Match match in termMatches)
            {
                if (match.Value == "") continue;

                int coefficient = match.Groups[1].Value == "" || match.Groups[1].Value == "+" ? 1 :
                                  match.Groups[1].Value == "-" ? -1 : int.Parse(match.Groups[1].Value);
                int exponent = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) :
                               (match.Groups[2].Success ? 1 : 0);

                if (terms.ContainsKey(exponent))
                    terms[exponent] += coefficient;
                else
                    terms[exponent] = coefficient;
            }
        }

        // Polinom toplama işlemi
        public static Polinom operator +(Polinom p1, Polinom p2)
        {
            Polinom result = new Polinom("");
            foreach (var term in p1.terms)
                result.terms[term.Key] = term.Value;

            foreach (var term in p2.terms)
            {
                if (result.terms.ContainsKey(term.Key))
                    result.terms[term.Key] += term.Value;
                else
                    result.terms[term.Key] = term.Value;
            }
            return result;
        }

        // Polinom çıkarma işlemi
        public static Polinom operator -(Polinom p1, Polinom p2)
        {
            Polinom result = new Polinom("");
            foreach (var term in p1.terms)
                result.terms[term.Key] = term.Value;

            foreach (var term in p2.terms)
            {
                if (result.terms.ContainsKey(term.Key))
                    result.terms[term.Key] -= term.Value;
                else
                    result.terms[term.Key] = -term.Value;
            }
            return result;
        }

        // Polinomu string olarak yazdırma
        public override string ToString()
        {
            List<string> termsList = new List<string>();
            foreach (var term in terms)
            {
                if (term.Value == 0) continue; // Katsayısı sıfır olan terimleri atla

                string coeffStr = term.Value > 0 && termsList.Count > 0 ? "+" + term.Value : term.Value.ToString();
                string termStr = term.Key == 0 ? coeffStr :
                                 term.Key == 1 ? coeffStr + "x" :
                                 $"{coeffStr}x^{term.Key}";
                termsList.Add(termStr);
            }
            return termsList.Count > 0 ? string.Join(" ", termsList) : "0";
        }
    }
}