using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetRoles()
    {
        return await _roleRepository.GetRoles();
    }
}