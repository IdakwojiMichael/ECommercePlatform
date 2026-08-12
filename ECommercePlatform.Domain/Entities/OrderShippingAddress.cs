namespace ECommercePlatform.Domain.Entities;

public class OrderShippingAddress
{
    public string AddressLine { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string State { get; private set; } = null!;

    public string Country { get; private set; } = null!;

    public string? PostalCode { get; private set; }

    public string? PhoneNumber { get; private set; }

    private OrderShippingAddress()
    {
    }

    public OrderShippingAddress(
        string addressLine,
        string city,
        string state,
        string country,
        string? postalCode,
        string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(addressLine))
        {
            throw new ArgumentException(
                "Address line is required.",
                nameof(addressLine));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException(
                "City is required.",
                nameof(city));
        }

        if (string.IsNullOrWhiteSpace(state))
        {
            throw new ArgumentException(
                "State is required.",
                nameof(state));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException(
                "Country is required.",
                nameof(country));
        }

        AddressLine = addressLine;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
    }
}