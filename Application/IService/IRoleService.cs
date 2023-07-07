using Models;

namespace Application.IService;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetRoles();
}