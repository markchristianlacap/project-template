using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
}
