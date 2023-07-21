using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<bool> Insert(Attendance model)
    {
        try
        {
            return await _attendanceRepository.Insert(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }
}