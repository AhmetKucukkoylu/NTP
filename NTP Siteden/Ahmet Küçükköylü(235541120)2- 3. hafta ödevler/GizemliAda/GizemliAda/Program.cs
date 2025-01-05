using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizemliAda
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verilen sayı dizisi
            int[] numbers = { 3, 5, 8 };
            // Geçerli operatörler
            char[] operators = { '+', '-', '*', '/' };

            // Geçerli ifadelerin listesi
            List<string> validExpressions = new List<string>();

            // Tüm olasılıkları hesapla
            GenerateExpressions(numbers, operators, "", 0, validExpressions);

            // Sonuçları konsolda yazdır
            Console.WriteLine("Geçerli ifadeler:");
            foreach (var expression in validExpressions)
            {
                Console.WriteLine(expression);
            }

            // Konsolun kapanmaması için bir tuşa basılmasını bekle
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void GenerateExpressions(int[] numbers, char[] operators, string currentExpression, int index, List<string> validExpressions)
        {
            if (index == numbers.Length)
            {
                // Eğer son sayıya ulaşıldıysa, ifadeyi değerlendir
                try
                {
                    double result = EvaluateExpression(currentExpression);
                    if (result > 0)
                    {
                        validExpressions.Add(currentExpression);
                    }
                }
                catch
                {
                    // İfade geçersizse, hata fırlatmayı yoksay
                }
                return;
            }

            // Sayıyı ekle
            if (index == 0)
            {
                GenerateExpressions(numbers, operators, numbers[index].ToString(), index + 1, validExpressions);
            }
            else
            {
                // Önce operatörü ekle
                foreach (char op in operators)
                {
                    GenerateExpressions(numbers, operators, currentExpression + " " + op + " " + numbers[index], index + 1, validExpressions);
                }
            }

            // Sayıyı sadece ekleyerek de devam et
            GenerateExpressions(numbers, operators, currentExpression + " " + numbers[index], index + 1, validExpressions);
        }

        static double EvaluateExpression(string expression)
        {
            // Geçerli bir C# matematik ifadesini değerlendir
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, ""));
        }
    }
}