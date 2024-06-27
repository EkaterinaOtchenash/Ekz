namespace Pri
{
    public static class Sprosic
    {
        public static void Main(string[] args)
        {
            int costPrice = 310;
            int[] prices = {300, 350, 400, 420, 480, 500, 630, 700, 800};
            int[] resp = {1000, 1200, 1500, 1800, 2000, 1800, 1400, 1200, 850};

            int belowCostCount = 0;
            int maxProfit = 0;
            int maxProfitPrice = 0;
            int optimalDemand = 0;

            for (int i = 0; i < resp.Length; i++)
            {
                if (prices[i] < costPrice)
                {
                    belowCostCount++;
                    continue;
                }

                int profit = (prices[i] - costPrice) * resp[i];
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                    maxProfitPrice = prices[i];
                    optimalDemand = resp[i];
                }
            }

            Console.WriteLine("Number of values below cost price: " + belowCostCount);
            Console.WriteLine("Maximum profit: " + maxProfit);
            Console.WriteLine("Price that yields maximum profit: " + maxProfitPrice);
            Console.WriteLine("Demand for the product at the optimal price: " + optimalDemand);

            Console.WriteLine("Student's name: [Your name]");
            Console.WriteLine("Group: [Your group]");
        }
    }
}