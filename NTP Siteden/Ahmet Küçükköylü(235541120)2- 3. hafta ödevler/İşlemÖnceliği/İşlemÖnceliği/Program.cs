using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace İşlemÖnceliği
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matematiksel ifadeyi girin (örneğin: 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3): ");
            string expression = Console.ReadLine();

            try
            {
                Console.WriteLine("\nİşlem Adımları:");
                double result = EvaluateExpression(expression);
                Console.WriteLine("\nİfadenin Sonucu: " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }

            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadLine();
        }

        // İfadeyi çözümleyen ve her adımı açıklayan metot
        static double EvaluateExpression(string expression)
        {
            expression = expression.Replace(" ", ""); // Boşlukları kaldır

            // Parantez içlerini çözme
            while (expression.Contains("("))
            {
                int openIndex = expression.LastIndexOf('(');
                int closeIndex = expression.IndexOf(')', openIndex);
                string innerExpression = expression.Substring(openIndex + 1, closeIndex - openIndex - 1);
                double innerResult = EvaluateExpression(innerExpression); // İç ifadeyi çöz
                expression = expression.Substring(0, openIndex) + innerResult + expression.Substring(closeIndex + 1);
                Console.WriteLine($"Parantez işlemi: {innerExpression} -> {innerResult}");
            }

            // Üs alma işlemlerini çözme
            expression = SolveOperators(expression, @"(\d+(\.\d+)?)(\^)(\d+(\.\d+)?)", (a, b) => Math.Pow(a, b), "Üs işlemi");

            // Çarpma ve bölme işlemlerini çözme
            expression = SolveOperators(expression, @"(\d+(\.\d+)?)([*/])(\d+(\.\d+)?)", (a, b) => a * b, "Çarpma/Bölme işlemi");

            // Toplama ve çıkarma işlemlerini çözme
            expression = SolveOperators(expression, @"(\d+(\.\d+)?)([+-])(\d+(\.\d+)?)", (a, b) => a + b, "Toplama/Çıkarma işlemi");

            return double.Parse(expression);
        }

        // İşlem sırasına göre operatörleri çözen yardımcı metot
        static string SolveOperators(string expression, string pattern, Func<double, double, double> operation, string operationName)
        {
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(expression))
            {
                Match match = regex.Match(expression);
                double leftOperand = double.Parse(match.Groups[1].Value);
                double rightOperand = double.Parse(match.Groups[4].Value);
                double result = operation(leftOperand, rightOperand);

                expression = expression.Replace(match.Value, result.ToString());
                Console.WriteLine($"{operationName}: {match.Value} -> {result}");
            }

            return expression;
        }
    }
}