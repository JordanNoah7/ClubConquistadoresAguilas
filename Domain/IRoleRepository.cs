using Models;

namespace Domain;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetRoles();
}