using System;
using NGK_Handin3.Models;

namespace NGK_Handin3
{
    public class SeedDate
    {
        public SeedDate()
        {
        }
        public static void SeedAccounts(ApplicationDbContext context)
        {
            context.Accounts.AddRange(
                // Seed manager
                new Account
                {
                    Email = "Weather@station.dk",
                    PwHash = "Weather123",
                    IsWeatherStation = true
                });
        }
    }
}
