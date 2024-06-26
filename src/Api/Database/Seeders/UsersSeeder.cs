﻿using Api.Entities;

namespace Api.Database.Seeders;

public static class UsersSeeder
{
    public static void Seed(ApiDbContext context)
    {
        var admin = new User
        {
            Name = "Admin",
            Email = "admin@admin.com",
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword("password"),
            IsActive = true,
        };
        if (!context.Users.Any(u => u.Email == admin.Email))
        {
            context.Users.Add(admin);
        }
        context.SaveChanges();
    }
}
