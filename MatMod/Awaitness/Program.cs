namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество значений:");
            int n = int.Parse(Console.ReadLine());

            double[] x = new double[n];
            double[] p = new double[n];
            double sumP = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите значение {i + 1}:");
                x[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Введите вероятность {i + 1}:");
                p[i] = double.Parse(Console.ReadLine());

                sumP += p[i];
            }

            if (Math.Abs(sumP - 1) > 0.001)
            {
                Console.WriteLine("Сумма вероятностей не равна 1. Проверьте введенные данные.");
                return;
            }

            double m = 0;
            double d = 0;

            for (int i = 0; i < n; i++)
            {
                m += x[i] * p[i];
                d += Math.Pow(x[i], 2) * p[i];
            }

            d = d - Math.Pow(m, 2);

            Console.WriteLine($"Количество значений n = {n}");
            Console.WriteLine($"Математическое ожидание М(Х) = {m}");
            Console.WriteLine($"Дисперсия D(X) = {d}");
            Console.WriteLine("Работу выполнил студент: [Ваше имя]");
            Console.WriteLine("Группа: [Ваша группа]");
        }
    }
}