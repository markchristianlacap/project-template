namespace Api.Features.Login;

public class Validator : Validator<LoginReq>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}
