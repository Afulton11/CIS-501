using System;
namespace designassessment.Clients
{
    public abstract class RebateClient : RebateAccount
    {
        protected RebateClient(double rebatePercentage)
        {
            RebatePercentage = rebatePercentage;
        }

        protected double RebatePercentage { get; }

        public double getRebate(double totalSales) =>
            totalSales - (totalSales * RebatePercentage);
    }
}
