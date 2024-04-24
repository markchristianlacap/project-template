using Api.Database;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Auth.ChangePassword;

public class Endpoint : Endpoint<ChangePasswordReq>
{
    public ApiDbContext Db { get; set; } = null!;
    public IUserService UserService { get; set; } = null!;

    public override void Configure()
    {
        Put("/change-password");
    }

    public override async Task HandleAsync(ChangePasswordReq req, CancellationToken ct)
    {
        var userId = UserService.UserId;
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == userId, ct);
        if (user is null)
        {
            await SendForbiddenAsync(ct);
            return;
        }
        var correctPass = BCrypt.Net.BCrypt.EnhancedVerify(req.OldPassword, user.Password);
        if (!correctPass)
        {
            ThrowError(x => x.OldPassword, "Old Password is incorrect");
        }
        user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(req.NewPassword);
        await Db.SaveChangesAsync(ct);
    }
}
