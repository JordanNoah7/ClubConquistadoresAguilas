﻿using Models;

namespace Domain;

public interface IAttendanceRepository
{
    Task<bool> Insert(Attendance model);
}