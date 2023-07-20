using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<Activity> GetActivitie(int id)
    {
        try
        {
            return await _activityRepository.GetActivitie(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Activity>> GetActivities()
    {
        try
        {
            return await _activityRepository.GetActivities();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> Insert(Activity model)
    {
        try
        {
            return await _activityRepository.Insert(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<IEnumerable<Person>> GetParticipants(int id)
    {
        try
        {
            return await _activityRepository.GetParticipants(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetNoParticipants(int id)
    {
        try
        {
            return await _activityRepository.GetNoParticipants(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> InsertParticipant(int activityId, int personId)
    {
        try
        {
            return await _activityRepository.InsertParticipant(activityId, personId);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateActivity(Activity model)
    {
        try
        {
            return await _activityRepository.UpdateActivity(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeleteActivity(int id)
    {
        try
        {
            return await _activityRepository.DeleteActivity(id);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeleteParticipant(int activityId, int personId)
    {
        try
        {
            return await _activityRepository.DeleteParticipant(activityId, personId);
        }
        catch (Exception e)
        {
            return false;
        }
    }
}