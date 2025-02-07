using System;
using System.Linq;
using System.Security.Cryptography;
using HarvestHubAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new HarvestHubContext(
                   serviceProvider.GetRequiredService<DbContextOptions<HarvestHubContext>>()))
        {
            // Periksa apakah ada data
            if (context.Users.Any())
            {
                return;   // DB telah di-seed
            }

            // Generate password hash and salt
            string password = "admin";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // Tambahkan data pengguna
            context.Users.AddRange(
                new User
                {
                    Username = "admin",
                    UserPassword = password,
                    UserGivenName = "Admin",
                    UserEmailAddress = "admin@example.com",
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserStatus = "Active",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            );

            context.SaveChanges();
        }
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}