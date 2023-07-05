using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class ContextRepository
{
    protected IConfiguration Configuration;

    public ContextRepository(IConfiguration configuration)
    {
        Configuration = configuration;
    }
}