using ECommercePlatform.Application.DTOs;
using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IIdentityService _identityService;
    private readonly ICustomerRepository _customerRepository;
    private readonly ITransactionManager _transactionManager;

    public RegistrationService(
        IIdentityService identityService,
        ICustomerRepository customerRepository,
        ITransactionManager transactionManager)
    {
        _identityService = identityService;
        _customerRepository = customerRepository;
        _transactionManager = transactionManager;
    }

    public async Task<bool> RegisterAsync(RegisterCustomerDto dto)
    {
        if (dto.Password != dto.ConfirmPassword)
        {
            return false;
        }

        var emailExists = await _customerRepository
            .ExistsByEmailAsync(dto.Email);

        if (emailExists)
        {
            return false;
        }

        await _transactionManager.BeginAsync();

        try
        {
            var customer = new Customer(
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.PhoneNumber);

            await _customerRepository.AddAsync(customer);

            var result = await _identityService.CreateUserAsync(
                customer.Id,
                dto.Email,
                dto.Password);

            if (!result.Succeeded)
            {
                await _transactionManager.RollbackAsync();
                return false;
            }

            await _transactionManager.CommitAsync();

            return true;
        }
        catch
        {
            await _transactionManager.RollbackAsync();
            throw;
        }
    }
}