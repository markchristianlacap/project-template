using Api.Database;
using Mapster;

namespace Api.Features.Users.Index;

public class Endpoint : Endpoint<UserPagedReq, PagedRes<UserRowRes>>
{
    public ApiDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Get("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserPagedReq req, CancellationToken ct)
    {
        var query = Db.Users.AsQueryable();
        if (!string.IsNullOrEmpty(req.Search))
        {
            query = query.Where(u => u.Name.Contains(req.Search) || u.Email.Contains(req.Search));
        }
        var res = await query.ProjectToType<UserRowRes>().ToPagedAsync(req, ct);
        Response = res;
    }
}
