using System.Security.Claims;
using Api.Database;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Login;

public class Endpoint : Endpoint<LoginReq>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Post("login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginReq req, CancellationToken ct)
    {
        var user = await Db
            .Users.Where(u => u.Email == req.Email)
            .Select(u => new { u.Password, u.Id })
            .FirstOrDefaultAsync(ct);
        if (user is null)
        {
            ThrowError("Invalid email or password. Please try again.");
        }
        // check password
        if (!BCrypt.Net.BCrypt.EnhancedVerify(req.Password, user.Password))
        {
            ThrowError("Invalid email or password. Please try again.");
        }

        await CookieAuth.SignInAsync(u =>
        {
            u.Claims.Add(new(ClaimTypes.NameIdentifier, user.Id.ToString()));
        });
    }
}
