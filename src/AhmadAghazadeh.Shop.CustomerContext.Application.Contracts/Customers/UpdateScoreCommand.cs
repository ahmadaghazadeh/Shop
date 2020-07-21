using System;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers
{
    public class UpdateScoreCommand : Command
    {
        public UpdateScoreCommand(Guid customerId, int score)
        {
            CustomerId = customerId;
            Score = score;
        }

        public Guid CustomerId{ get;private set; }
        public int Score { get; private set; }
    }
}