namespace Api.Features.Users.ResetPassword;

public class UserResetPasswordReq
{
    public string NewPassword { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
