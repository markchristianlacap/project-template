namespace Api.Features.Auth.UpdateProfile;

public class UserUpdateProfileReq
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}
