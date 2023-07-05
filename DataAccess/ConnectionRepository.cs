using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class ConnectionRepository
{
    protected IConfiguration Configuration;

    public ConnectionRepository(IConfiguration configuration)
    {
        Configuration = configuration;
    }
}