using System;
using Timesheet.Domain.Models;

namespace Timesheet.Domain
{
    public interface ITimesheetRepository
    {
        TimeLog[] GetTimeLogs(string lastName);
        void Add(TimeLog timeLog);
        int GetTotalHourForDate(string lastName, DateTime date);
        void Update(TimeLog timeLog);
        TimeLog Get(int timeLogId);
    }
}
