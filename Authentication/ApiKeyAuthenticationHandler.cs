using System.Security.Claims;
using System.Text.Encodings.Web;
using BlogLink.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using BlogLink.Models;

namespace BlogLink.Authentication;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string ApiKeyHeader = "Api-Key";
    private readonly ApplicationRepository applicationRepository;
    private readonly UserManager<IdentityUser> userManager;
    public ApiKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        ApplicationRepository applicationRepository,
        UserManager<IdentityUser> userManager
    ) : base(options, logger, encoder, clock)
    {
        this.applicationRepository = applicationRepository;
        this.userManager = userManager;
    }   

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey(ApiKeyHeader))
        {
            return AuthenticateResult.Fail("Header not found");
        }
        var apiKeyToValidate = Request.Headers[ApiKeyHeader].ToString();
        var apiKey = await applicationRepository.UserApiKeys.SingleOrDefaultAsync(x => x.Value == apiKeyToValidate);
        if (apiKey is null)
        {
            return AuthenticateResult.Fail("Invalid key");
        }
        var identityUser = await userManager.FindByIdAsync(apiKey.IdentityUserId);
        if (identityUser is null)
        {
            return AuthenticateResult.Fail("Owner was not found");
        }
        return AuthenticateResult.Success(CreateTicket(identityUser));
    }
    
    private AuthenticationTicket CreateTicket(IdentityUser identityUser)
    {
        var claims = new[]{
            new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
            new Claim(ClaimTypes.Name, identityUser.UserName)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return ticket;
    }
}