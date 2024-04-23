using Api.Database;
using Api.Enums;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Users.ResetPassword;

public class Endpoint : Endpoint<UserResetPasswordReq>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Put("/users/{id:guid}/reset-password");
        Roles(nameof(Role.Admin));
    }

    public override async Task HandleAsync(UserResetPasswordReq req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(req.NewPassword);
        await Db.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}
