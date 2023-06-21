using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess;

public class ContextRepository
{
    protected readonly ClubConquistadoresAguilasContext _dbContext;
    protected IDbContextTransaction _currentTransaction;

    public ContextRepository(ClubConquistadoresAguilasContext context)
    {
        _dbContext = context;
    }
    
    public async Task BeginTransaction()
    {
        _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _currentTransaction.CommitAsync();
    }

    public async Task Rollback()
    {
        await _currentTransaction.RollbackAsync();
    }
}