namespace Api.Features.Users.Store;

public class UserStoreReq : UserModel
{
    public string Password { get; set; } = null!;
}

public class UserStoreRes : UserStoreReq
{
    public Guid Id { get; set; }
}
