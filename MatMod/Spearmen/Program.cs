namespace Program
{
    class Prog
    {
        public static void Main(string[] args)
        {
             int n = 10;
             int[] answer1 = new int[n];
             int[] answer2 = new int[n];
             Console.WriteLine("Enter the values for the first array:");
             for (int i = 0; i < n; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out answer1[i]))
                {
                    Console.WriteLine("Invalid input. Enter an integer.");
                }
            }

        Console.WriteLine("Enter the values for the second array:");
        for (int i = 0; i < n; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out answer2[i]))
            {
                 Console.WriteLine("Invalid input. Enter an integer.");
            }
        }

        double rs = Spear(answer1, answer2);

            Console.WriteLine($"Coefficient of linear correlation Rs = {rs:F4}");
            Console.WriteLine($"The nature of the relationship according to the Chaddock scale: {PrintAns(rs)}");
            Console.WriteLine("The work was done by student: <Your Full Name>");
            Console.WriteLine("Group: <Your Group>");
        }
        
        static double Spear(int[] ans1, int[] ans2)
        {
            int n = ans1.Length;
            int raz = 0;
            int sum = 0;
            double Rs;
            for (int i = 0; i < n; ++i)
            {
                raz = ans1[i] - ans2[i];
                raz = (int)Math.Pow(raz, 2);
                sum += raz;
            }
            Rs = 1 - ((6 * sum)/(n*(Math.Pow(n, 2)-1)));
            return Rs;
        }

        static string PrintAns(double rs)
        {
             string result = "";

            if (rs >= 0.9 && rs <= 1.0)
            {
                result = "Very high positive correlation";
            }
            else if (rs >= 0.7 && rs < 0.9)
            {
                result = "High positive correlation";
            }
            else if (rs >= 0.5 && rs < 0.7)
            {
                result = "Moderate positive correlation";
            }
            else if (rs >= 0.3 && rs < 0.5)
            {
                result = "Low positive correlation";
            }
            else if (rs >= -0.3 && rs < 0.3)
            {
                result = "No or negligible correlation";
            }
            else if (rs >= -0.5 && rs < -0.3)
            {
                result = "Low negative correlation";
            }
            else if (rs >= -0.7 && rs < -0.5)
            {
                result = "Moderate negative correlation";
            }
            else if (rs >= -0.9 && rs < -0.7)
            {
                result = "High negative correlation";
            }
            else if (rs >= -1.0 && rs < -0.9)
            {
                result = "Very high negative correlation";
            }

            return result;
        }
    }
}


    



