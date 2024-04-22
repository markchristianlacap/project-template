using Api.Database;

namespace Api.Features.Users.Index;

public class UserRowRes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class UserPagedReq : PagedReq
{
    public string? Search { get; set; }
}
