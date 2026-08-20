using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommercePlatform.Persistence.Services;

public class TransactionManager : ITransactionManager
{
    private readonly ECommerceDbContext _context;
    private IDbContextTransaction? _transaction;

    public TransactionManager(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task BeginAsync(
        CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database
            .BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(
        CancellationToken cancellationToken = default)
    {
        if (_transaction is null)
        {
            return;
        }

        await _transaction.CommitAsync(cancellationToken);

        await _transaction.DisposeAsync();

        _transaction = null;
    }

    public async Task RollbackAsync(
        CancellationToken cancellationToken = default)
    {
        if (_transaction is null)
        {
            return;
        }

        await _transaction.RollbackAsync(cancellationToken);

        await _transaction.DisposeAsync();

        _transaction = null;
    }
}