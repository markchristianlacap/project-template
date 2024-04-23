namespace Api.Features.Users.ResetPassword;

public class Validator : Validator<UserResetPasswordReq>
{
    public Validator()
    {
        RuleFor(x => x.NewPassword).NotNull().NotEmpty();
        RuleFor(x => x.ConfirmPassword)
            .NotNull()
            .NotEmpty()
            .Equal(x => x.NewPassword)
            .WithMessage("Confirm password must be equal to new password");
    }
}
