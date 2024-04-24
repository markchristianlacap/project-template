using Api.Enums;
using Humanizer;

namespace Api.Features.Auth.GetUser;

public class GetUserRes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
    public string RoleDesc => Role.Humanize(LetterCasing.Title);
}
