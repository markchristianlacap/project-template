namespace Api.Features.Auth.UpdateProfile;

public class Validator : Validator<UserUpdateProfileReq>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull();
    }
}
