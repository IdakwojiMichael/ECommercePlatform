using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Address : BaseEntity
{
    public Guid CustomerId { get; private set; }

    public string AddressLine { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string State { get; private set; } = null!;

    public string Country { get; private set; } = null!;

    public string? PostalCode { get; private set; }

    public string? PhoneNumber { get; private set; }

    public bool IsDefault { get; private set; }

    public Customer Customer { get; private set; } = null!;

    private Address()
    {
    }

    public Address(
        Guid customerId,
        string addressLine,
        string city,
        string state,
        string country,
        string? postalCode = null,
        string? phoneNumber = null,
        bool isDefault = false)
    {
        CustomerId = customerId;
        AddressLine = addressLine;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        IsDefault = isDefault;
    }

    public void Update(
        string addressLine,
        string city,
        string state,
        string country,
        string? postalCode,
        string? phoneNumber)
    {
        AddressLine = addressLine;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
    }

    public void SetAsDefault()
    {
        IsDefault = true;
    }

    public void RemoveAsDefault()
    {
        IsDefault = false;
    }
}