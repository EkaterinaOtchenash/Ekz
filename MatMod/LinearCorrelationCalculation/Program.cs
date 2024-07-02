using System;

namespace LinearCorrelationCalculation
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
            double[] y = new double[n];

            Console.WriteLine("\nВведите значения массива X:");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out x[i]))
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку:");
                }
            }

            Console.WriteLine("\nВведите значения массива Y:");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out y[i]))
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку:");
                }
            }

            double rxy = Corr(x, y);

            Console.WriteLine("\nКоэффициент линейной корреляции rxy = " + rxy);

            Console.WriteLine("Наличие линейной взаимосвязи между параметрами Х и У: " + PrintAns(rxy));


            Console.WriteLine("\nРаботу выполнил студент: [Ваше имя]");
            Console.WriteLine("Группа: [Ваша группа]");
        }
        static double Corr (double[] ar1, double[] ar2)
        {
            double n = ar1.Length;
            double x = 0;
            double y = 0;
            double s2x = 0;
            double s2y = 0;
            double xy = 0;
            double r = 0;
            for (int i = 0; i < n; ++i)
            {
                x += ar1[i] * 1/n;
                y += ar2[i] * 1/n;
                s2x += Math.Pow(ar1[i], 2) * 1/n;
                s2y += Math.Pow(ar2[i], 2) * 1/n;
                xy += 1/n * ar1[i]*ar2[i];
            }
            s2x -= Math.Pow(x, 2);
            s2y -= Math.Pow(y, 2);
            xy -= x*y;

            r = xy/ (Math.Sqrt(s2x) * Math.Sqrt(s2y));

            if(r >= 0.9)
            {
                double a = xy / s2x;
                double b = y - (x * a);
                Console.WriteLine("\na = " + a);
                Console.WriteLine("b = " + b);
            }
            return r;
        }

        public static string PrintAns(double rs)
        {
            string result = "";

            if (Math.Abs(rs) >= 0.95 && Math.Abs(rs) <= 1.0)
            {
                result = "Практически функциональная зависимость";
            }
            else if (Math.Abs(rs) >= 0.7 && Math.Abs(rs) < 0.95)
            {
                result = "Связь сильная (тесная)";
            }
            else if (Math.Abs(rs) >= 0.5 && Math.Abs(rs) < 0.7)
            {
                result = "Связь средняя (умеренная)";
            }
            else if (Math.Abs(rs) >= 0.2 && Math.Abs(rs) < 0.5)
            {
                result = "Связь слабая";
            }
            else if (Math.Abs(rs) >= 0 && Math.Abs(rs) < 0.2)
            {
                result = "Связь практически отсутствует";
            }

            return result;

        }
    }
}
