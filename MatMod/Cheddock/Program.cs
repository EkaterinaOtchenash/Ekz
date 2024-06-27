namespace Pro
{
    class Chedd
    {
        public static void Main(string[] args)
        {
            int [] ar1 = {10, 14, 50, 70};
            int [] ar2 = {8, 20, 60, 100};

            double r = Corr(ar1, ar2);

             Console.WriteLine($"Coefficient of linear correlation Rs = {r:F4}");
             Console.WriteLine($"The nature of the relationship according to the Chaddock scale:{PrintAns(r)}");
        }

        static double Corr (int[] ar1, int[] ar2)
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