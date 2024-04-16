namespace Api.Features.Users.Store;

public class Validator : Validator<UserStoreReq>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8);
    }
}
