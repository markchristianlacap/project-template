using Api.Database;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.Update;

public class Endpoint : Endpoint<UserUpdateReq>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Put("/users/{id:guid}");
    }

    public override async Task HandleAsync(UserUpdateReq req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var emailExist = await Db.Users.Where(x => x.Email == req.Email && x.Id != id).AnyAsync(ct);
        if (emailExist)
        {
            ThrowError(x => x.Email, "Email already exist");
        }
        req.Adapt(user);
        await Db.SaveChangesAsync(ct);
    }
}
