using ECommercePlatform.Application.DTOs;

namespace ECommercePlatform.Application.Interfaces;

public interface IRegistrationService
{
    Task<bool> RegisterAsync(RegisterCustomerDto dto);
}