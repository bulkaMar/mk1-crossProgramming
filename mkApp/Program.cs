using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MK1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Абсолютний шлях до кореневої директорії проєкту
            string projectDirectory = @"C:\Users\61sun\source\repos\mk1-crossProgramming\mkApp";
            string inputFilePath = args.Length > 0 ? args[0] : Path.Combine(projectDirectory, "INPUT.TXT");
            string outputFilePath = Path.Combine(projectDirectory, "OUTPUT.TXT");

            // Перевірка, чи існує вхідний файл
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл INPUT.TXT не знайдено за шляхом: {inputFilePath}");
                return;
            }

            // Зчитування слова з файлу
            string word = File.ReadAllText(inputFilePath).Trim();

            Dictionary<char, int> letterCount = word.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            long Factorial(int n)
            {
                long result = 1;
                for (int i = 2; i <= n; i++)
                    result *= i;
                return result;
            }

            long totalPermutations = Factorial(word.Length);
            foreach (var count in letterCount.Values)
                totalPermutations /= Factorial(count);

            // Запис результату в файл
            File.WriteAllText(outputFilePath, totalPermutations.ToString());
            Console.WriteLine("MK1");
            Console.WriteLine($"The number of unique word permutations for \"{word}\": {totalPermutations}");
        }
    }
}
