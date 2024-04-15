using Api.Database;
using Api.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.GetUser;

public class Endpoint : EndpointWithoutRequest<GetUserRes>
{
    public IUserService UserService { get; set; } = null!;
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Get("/user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var userId = UserService.UserId;
        var user = await Db
            .Users.ProjectToType<GetUserRes>()
            .FirstOrDefaultAsync(x => x.Id == userId, ct);
        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        Response = user;
    }
}
