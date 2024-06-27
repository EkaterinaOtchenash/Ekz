using System;

namespace LinearCorrelation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массивов:");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 1)
            {
                Console.WriteLine("Некорректный ввод. Размерность массива должна быть целым числом больше 1.");
            }

            double[] x = new double[n];
            double[] y = new double[n];

            Console.WriteLine("Введите элементы массива X:");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out x[i]))
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
                }
            }

            Console.WriteLine("Введите элементы массива Y:");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out y[i]))
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
                }
            }

            double rxy = CalculateCorrelationCoefficient(x, y);
            Console.WriteLine($"Коэффициент линейной корреляции rxy = {rxy:F4}");

            if (rxy >= 0.9)
            {
                double a = CalculateRegressionCoefficientA(x, y, rxy);
                double b = CalculateRegressionCoefficientB(x, y, rxy, a);
                Console.WriteLine($"a = {a:F4}");
                Console.WriteLine($"b = {b:F4}");
            }
            else
            {
                Console.WriteLine("Линейная взаимосвязь между параметрами Х и У отсутствует.");
            }

            Console.WriteLine("Работу выполнил студент: [Ваше имя]");
            Console.WriteLine("Группа: [Ваша группа]");
        }

        static double CalculateCorrelationCoefficient(double[] x, double[] y)
        {
            double xAvg = CalculateAverage(x);
            double yAvg = CalculateAverage(y);
            double numerator = 0;
            double denominatorX = 0;
            double denominatorY = 0;

            for (int i = 0; i < x.Length; i++)
            {
                numerator += (x[i] - xAvg) * (y[i] - yAvg);
                denominatorX += Math.Pow(x[i] - xAvg, 2);
                denominatorY += Math.Pow(y[i] - yAvg, 2);
            }

            return numerator / Math.Sqrt(denominatorX * denominatorY);
        }

        static double CalculateAverage(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }

        static double CalculateRegressionCoefficientA(double[] x, double[] y, double rxy)
        {
            double xAvg = CalculateAverage(x);
            double yAvg = CalculateAverage(y);
            double sx = CalculateStandardDeviation(x);
            double sy = CalculateStandardDeviation(y);

            return (sy / sx) * rxy;
        }

        static double CalculateRegressionCoefficientB(double[] x, double[] y, double rxy, double a)
        {
            double xAvg = CalculateAverage(x);
            double yAvg = CalculateAverage(y);

            return yAvg - a * xAvg;
        }

        static double CalculateStandardDeviation(double[] arr)
        {
            double avg = CalculateAverage(arr);
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += Math.Pow(arr[i] - avg, 2);
            }

            return Math.Sqrt(sum / (arr.Length - 1));
        }
    }
}
