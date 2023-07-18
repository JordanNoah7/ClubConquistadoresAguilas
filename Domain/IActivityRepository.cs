using Models;

namespace Domain;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> GetActivities();
    Task<bool> Insert(Activity model);
}