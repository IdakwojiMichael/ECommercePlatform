namespace ECommercePlatform.Application.DTOs;

public class RegisterCustomerDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Password { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;
}