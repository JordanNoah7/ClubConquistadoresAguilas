using Models;

namespace Application.IService;

public interface IAttendanceService
{
    Task<bool> Insert(Attendance model);
}