using System.Security.Claims;

namespace Api.Services;

public interface IUserService
{
    Guid? UserId { get; }
}

public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? UserId =>
        Guid.TryParse(
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
            out var id
        )
            ? id
            : null;
}
