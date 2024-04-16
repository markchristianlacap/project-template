namespace Api.Features.Users.Update;

public class Validator : Validator<UserUpdateReq>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
    }
}
