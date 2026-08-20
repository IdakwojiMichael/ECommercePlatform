using Microsoft.AspNetCore.Identity;

namespace ECommercePlatform.Persistence.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid? CustomerId { get; private set; }

    public void SetCustomerId(Guid customerId)
    {
        CustomerId = customerId;
    }
}