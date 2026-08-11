using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string? PhoneNumber { get; private set; }

    public bool IsActive { get; private set; }

    public ICollection<Address> Addresses { get; private set; }
        = new List<Address>();

    public ICollection<Order> Orders { get; private set; }
        = new List<Order>();

    public ICollection<Review> Reviews { get; private set; }
        = new List<Review>();

    public ICollection<Notification> Notifications { get; private set; }
        = new List<Notification>();

    public Cart? Cart { get; private set; }

    public Wishlist? Wishlist { get; private set; }

    private Customer()
    {
    }

    public Customer(
        string firstName,
        string lastName,
        string email,
        string? phoneNumber = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = true;
    }

    public void Update(
        string firstName,
        string lastName,
        string email,
        string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}