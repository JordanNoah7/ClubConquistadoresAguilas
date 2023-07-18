using Models;

namespace Application.IService;

public interface IActivityService
{
    Task<IEnumerable<Activity>> GetActivities();
    Task<bool> Insert(Activity model);
}