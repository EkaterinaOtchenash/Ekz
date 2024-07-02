using System;

namespace OptimalPriceCalculation
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

            double[] s = new double[n];
            int[] k = new int[n];

            Console.WriteLine("\nВведите значения массива S (цены в порядке возрастания):");
            for (int i = 0; i < n; i++)
            {
                while (!double.TryParse(Console.ReadLine(), out s[i]) || (i > 0 && s[i] <= s[i - 1]))
                {
                    Console.WriteLine("Некорректный ввод. Цены должны быть указаны в порядке возрастания. Повторите попытку:");
                }
            }

            Console.WriteLine("\nВведите значения массива K (количество респондентов):");
            for (int i = 0; i < n; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out k[i]) || k[i] < 0)
                {
                    Console.WriteLine("Некорректный ввод. Количество респондентов должно быть целым неотрицательным числом. Повторите попытку:");
                }
            }

            Console.WriteLine("\nВведите значение себестоимости на товар:");
            double cost;
            while (!double.TryParse(Console.ReadLine(), out cost))
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку:");
            }

            int belowCostCount = 0;
            double maxProfit = 0;
            int maxProfitIndex = -1;
            double demandSum = 0;

            Console.WriteLine("\nЦенаi\tКол-воi\tСпросi\tПрибыльi");

            for (int i = 0; i < n; i++)
            {
                double demand = (double)k[i] * (s[n - 1] - s[i]) / (s[n - 1] - s[0]);
                demandSum += demand;
                double profit = (s[i] - cost) * demand;

                if (s[i] < cost)
                {
                    belowCostCount++;
                }

                if (profit > maxProfit)
                {
                    maxProfit = profit;
                    maxProfitIndex = i;
                }

                Console.WriteLine("{0}\t{1}\t{2:F2}\t{3:F2}", s[i], k[i], demand, profit);
            }

            Console.WriteLine("\nКоличество значений ниже себестоимости: " + belowCostCount);
            Console.WriteLine("Максимальная прибыль: " + maxProfit);
            Console.WriteLine("Цена, обеспечивающая максимальную прибыль: " + s[maxProfitIndex]);
            Console.WriteLine("Спрос на товар для оптимальной цены: " + ((double)k[maxProfitIndex] * (s[n - 1] - s[maxProfitIndex]) / (s[n - 1] - s[0])).ToString("F2"));

            Console.WriteLine("\nРаботу выполнил студент: [Ваше имя]");
            Console.WriteLine("Группа: [Ваша группа]");
        }
    }
}
