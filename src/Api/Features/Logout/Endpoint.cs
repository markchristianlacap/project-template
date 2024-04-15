using FastEndpoints.Security;

namespace Api.Features.Logout;

public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/logout");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await CookieAuth.SignOutAsync();
    }
}
