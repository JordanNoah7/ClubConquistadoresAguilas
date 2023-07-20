using Models;

namespace Application.IService;

public interface IPersonService
{
    Task<bool> Insert(Person model);
    Task<bool> InsertParent(Person model);
    
    Task<bool> Update(Person model);
    Task<bool> UpdateParent(Person model);
    
    Task<bool> DeletePerson(int id);
    
    Task<Person> GetPathfinderById(int id);
    Task<Person> GetPersonClassById(int id);
    Task<Person> GetParentById(int id);
    Task<Person> GetPersonById(int id);
    
    Task<IEnumerable<Person>> GetCounselors();
    Task<IEnumerable<Person>> GetManagers();
    Task<IEnumerable<Person>> GetInstructors();
    Task<IEnumerable<Person>> GetFathers();
    Task<IEnumerable<Person>> GetPathfinders();
    Task<IEnumerable<Person>> GetParents();
    Task<IEnumerable<Person>> GetPathfindersByUnit(int id);
    Task<IEnumerable<Person>> GetMembersByUnit(int id);
}