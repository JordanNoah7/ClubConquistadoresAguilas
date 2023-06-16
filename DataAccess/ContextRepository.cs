using Infrastructure.Context;

namespace DataAccess.Repositories;

public class ContextRepository
{
    protected readonly ClubConquistadoresAguilasContext _dbContext;

    public ContextRepository(ClubConquistadoresAguilasContext context)
    {
        _dbContext = context;
    }
}