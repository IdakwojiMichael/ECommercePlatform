using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommercePlatform.Persistence.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(bool Succeeded, Guid UserId)> CreateUserAsync(
        Guid customerId,
        string email,
        string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        user.SetCustomerId(customerId);

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return (false, Guid.Empty);
        }

        return (true, user.Id);
    }
}