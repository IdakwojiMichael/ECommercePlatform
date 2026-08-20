using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ECommerceDbContext _context;

    public CustomerRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Customers
            .AnyAsync(x => x.Email == email);
    }
}