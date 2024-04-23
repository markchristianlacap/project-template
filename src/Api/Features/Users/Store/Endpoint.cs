using Api.Database;
using Api.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Store;

public class Endpoint : Endpoint<UserStoreReq, UserStoreRes>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Post("/users");
    }

    public override async Task HandleAsync(UserStoreReq req, CancellationToken ct)
    {
        var emailExist = await Db.Users.Where(x => x.Email == req.Email).AnyAsync(ct);
        if (emailExist)
        {
            ThrowError(x => x.Email, "Email already exist");
        }
        var user = req.Adapt<User>();
        user.IsActive = true;
        await Db.Users.AddAsync(user, ct);
        await Db.SaveChangesAsync(ct);
        var res = user.Adapt<UserStoreRes>();
        Response = res;
    }
}
