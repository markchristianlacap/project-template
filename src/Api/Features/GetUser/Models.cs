namespace Api.Features.GetUser;

public class GetUserRes
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}