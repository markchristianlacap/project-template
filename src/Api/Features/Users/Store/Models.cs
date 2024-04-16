namespace Api.Features.Users.Store;

public class UserStoreReq
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class UserStoreRes : UserStoreReq
{
    public Guid Id { get; set; }
}
