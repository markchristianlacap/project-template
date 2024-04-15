using Api.Entities;

namespace Api.Database.Seeders;

public static class UsersSeeder
{
    public static void Seed(ApiDbContext context)
    {
        var admin = new User
        {
            Name = "Admin",
            Email = "admin@example.com",
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword("omsc.portal@2019"),
        };
        if (!context.Users.Any(u => u.Email == admin.Email))
        {
            context.Users.Add(admin);
        }
        context.SaveChanges();
    }
}
