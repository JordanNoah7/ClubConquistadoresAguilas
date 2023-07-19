using Models;

namespace Application.IService;

public interface IActivityService
{
    Task<bool> Insert(Activity model);
    Task<bool> InsertParticipant(int activityId, int personId);
    
    Task<bool> UpdateActivity(Activity model);
    
    Task<bool> DeleteActivity(Activity model);
    Task<bool> DeleteParticipant(int activityId, int personId);
    
    Task<Activity> GetActivitie(int id);
    
    Task<IEnumerable<Activity>> GetActivities();
    Task<IEnumerable<Person>> GetParticipants(int id);
    Task<IEnumerable<Person>> GetNoParticipants(int id);
}