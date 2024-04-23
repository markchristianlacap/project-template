using System.Reflection;
using Api.Database.Interceptors;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class ApiDbContext(
    DbContextOptions<ApiDbContext> options,
    AuditInterceptor? auditInterceptor = null
) : DbContext(options)
{
    private readonly AuditInterceptor? _auditInterceptor = auditInterceptor;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_auditInterceptor != null)
            optionsBuilder.AddInterceptors(_auditInterceptor);
    }

    public DbSet<User> Users { get; set; } = null!;
}
