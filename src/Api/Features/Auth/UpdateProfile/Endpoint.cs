using Api.Database;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Auth.UpdateProfile;

public class Endpoint : Endpoint<UserUpdateProfileReq>
{
    public ApiDbContext Db { get; set; } = null!;
    public IUserService UserService { get; set; } = null!;

    public override void Configure()
    {
        Put("/update-profile");
    }

    public override async Task HandleAsync(UserUpdateProfileReq req, CancellationToken ct)
    {
        var userId = UserService.UserId;
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == userId, ct);
        if (user is null)
        {
            await SendForbiddenAsync(ct);
            return;
        }
        user.Name = req.Name;
        user.Email = req.Email;
        await Db.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
