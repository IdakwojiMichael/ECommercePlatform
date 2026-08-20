namespace ECommercePlatform.Application.Interfaces;

public interface IIdentityService
{
    Task<(bool Succeeded, Guid UserId)> CreateUserAsync(
        Guid customerId,
        string email,
        string password);
}