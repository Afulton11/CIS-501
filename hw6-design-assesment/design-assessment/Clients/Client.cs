using System;
namespace designassessment.Clients
{
    public abstract class Client : RebateClient, StarAccount
    {
        protected Client(string clientType, double rebatePercentage)
            : base(rebatePercentage)
        {
            ClientType = clientType;
        }

        protected string ClientType { get; }

        public void AddStarPoints(int points) =>
            Console.WriteLine($"Adding {points} points to {ClientType} Client's Star account");
    }
}
