using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);

    Task<bool> ExistsByEmailAsync(string email);
}