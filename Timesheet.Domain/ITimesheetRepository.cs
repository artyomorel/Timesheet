using Timesheet.Domain.Models;

namespace Timesheet.Domain
{
    public interface ITimesheetRepository
    {
        TimeLog[] GetTimeLogs(string lastName);
        bool Add(TimeLog timeLog);
        void Update(TimeLog timeLog);
        TimeLog Get(int timeLogId);
    }
}
