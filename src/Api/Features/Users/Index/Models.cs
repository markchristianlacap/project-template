using Api.Database;
using Humanizer;

namespace Api.Features.Users.Index;

public class UserRowRes : UserModel
{
    public Guid Id { get; set; }
    public string RoleDesc => Role.Humanize(LetterCasing.Title);
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class UserPagedReq : PagedReq
{
    public string? Search { get; set; }
}
