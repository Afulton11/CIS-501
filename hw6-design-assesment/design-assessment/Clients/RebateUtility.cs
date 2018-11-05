using System;
namespace designassessment.Clients
{
    public sealed class RebateUtility
    {
        public static double CalculateRebate(double totalSales, double percentOff)
        {
            return totalSales - (totalSales * percentOff);
        }
    }
}
