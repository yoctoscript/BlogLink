using BlogLink.Models;
using BlogLink.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BlogLink.Services;

public class ApiKeyService
{
    private readonly ApplicationRepository applicationRepository;
    public ApiKeyService(ApplicationRepository applicationRepository)
    {
        this.applicationRepository = applicationRepository;
    }
    public string CreateApiKey(IdentityUser identityUser)
    {
        var userApiKey = new UserApiKey()
        {
            Value = Guid.NewGuid().ToString(),
            IdentityUserId = identityUser.Id
        };
        applicationRepository.UserApiKeys.Add(userApiKey);
        applicationRepository.SaveChanges();

        return userApiKey.Value;
    }
}