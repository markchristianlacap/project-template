namespace Api.Features.Auth.ChangePassword;

public class Validator : Validator<ChangePasswordReq>
{
    public Validator()
    {
        RuleFor(x => x.OldPassword).NotEmpty().NotNull();
        RuleFor(x => x.NewPassword).NotEmpty().NotNull();
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .NotNull()
            .Equal(x => x.NewPassword)
            .WithMessage("Confirm password must match new password");
    }
}
