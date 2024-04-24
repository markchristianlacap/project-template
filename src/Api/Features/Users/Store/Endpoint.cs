using Api.Database;
using Api.Entities;
using Api.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Store;

public class Endpoint : Endpoint<UserStoreReq, UserStoreRes>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Post("/users");
        Roles(nameof(Role.Admin));
    }

    public override async Task HandleAsync(UserStoreReq req, CancellationToken ct)
    {
        var emailExist = await Db.Users.Where(x => x.Email == req.Email).AnyAsync(ct);
        if (emailExist)
        {
            ThrowError(x => x.Email, "Email already exist");
        }
        var user = req.Adapt<User>();
        user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password);
        await Db.Users.AddAsync(user, ct);
        await Db.SaveChangesAsync(ct);
        var res = user.Adapt<UserStoreRes>();
        Response = res;
    }
}
