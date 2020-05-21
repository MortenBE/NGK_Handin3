using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using static BCrypt.Net.BCrypt;
using NGK_Handin3.Models;

namespace NGK_Handin3
{
    public class SeedDate
    {
        public const int BcryptWorkfactor = 10;

        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Accounts.Any())
                SeedAccounts(context);
        }

        public static void SeedAccounts(ApplicationDbContext context)
        {
            context.Users.Add(
                new User
                {
                    Email = "boss@m.dk",
                    FirstName = "Test",
                    LastName ="Test",
                    PwHash = HashPassword("asdfQWER", BcryptWorkfactor),
                    IsWeatherStation = true
                });
            context.SaveChanges();
        }
    }
}
