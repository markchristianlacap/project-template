using Api.Enums;

namespace Api.Features.Users;

public class UserModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
    public bool IsActive { get; set; } = false;
}
