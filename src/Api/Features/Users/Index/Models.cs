using Api.Database;

namespace Api.Features.Users.Index;

public class UserRowRes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class UserPagedReq : PagedReq
{
    public string? Search { get; set; }
}
