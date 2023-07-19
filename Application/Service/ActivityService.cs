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
}