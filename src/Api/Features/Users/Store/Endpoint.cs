using Api.Database;
using Api.Entities;
using Mapster;

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
        var user = req.Adapt<User>();
        await Db.Users.AddAsync(user, ct);
        await Db.SaveChangesAsync(ct);
        var res = user.Adapt<UserStoreRes>();
        Response = res;
    }
}
