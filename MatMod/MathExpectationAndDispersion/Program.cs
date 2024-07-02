using System;

namespace MathExpectationAndDispersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива (целое число больше 1):");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 1)
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку:");
            }

            double[] x = new double[n];
            double[] p = new double[n];

            Console.WriteLine("\nВведите значения массива X:");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out x[i]))
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку:");
                }
            }

            Console.WriteLine("\nВведите значения массива P (вероятности):");
            double sumP = 0;
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out p[i]) || p[i] < 0 || p[i] > 1)
                {
                    Console.WriteLine("Некорректный ввод. Вероятность должна быть числом от 0 до 1. Повторите попытку:");
                }
                sumP += p[i];
            }

            if (Math.Abs(sumP - 1) > 0.001)
            {
                Console.WriteLine("\nСумма вероятностей не равна 1. Проверьте введенные данные и повторите попытку.");
                return;
            }

            double mathExpectation = 0;
            double dispersion = 0;

            for (int i = 0; i < n; i++)
            {
                mathExpectation += x[i] * p[i];
                dispersion += Math.Pow(x[i], 2) * p[i];
            }

            dispersion = dispersion - Math.Pow(mathExpectation, 2);

            Console.WriteLine("\nКоличество значений n = " + n);
            Console.WriteLine("Математическое ожидание М(Х) = " + mathExpectation);
            Console.WriteLine("Дисперсия D(X) = " + dispersion);

            Console.WriteLine("\nРаботу выполнил студент: [Ваше имя]");
            Console.WriteLine("Группа: [Ваша группа]");
        }
    }
}
