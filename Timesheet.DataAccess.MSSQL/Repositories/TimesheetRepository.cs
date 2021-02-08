using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.DataAccess.MSSQL.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly TimesheetContext _context;
        private readonly IMapper _mapper;

        public TimesheetRepository(TimesheetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(TimeLog timeLog)
        {
            var totalHour = _context.TimeLogs
                .Where(x => x.Date == timeLog.Date && x.LastName == timeLog.LastName)
                .Sum(x=>x.WorkingHours)
                + timeLog.WorkingHours;
            if (totalHour > 24)
            {
                return false;
            }
            var timeLogEntity = _mapper.Map<Entities.TimeLog>(timeLog);
            
            _context.TimeLogs.Add(timeLogEntity);
            _context.SaveChanges();
            return true;
        }

        public void Update(TimeLog timeLog)
        {
            var timeLogEntities = _mapper.Map<Entities.TimeLog>(timeLog);
            _context.TimeLogs.Update(timeLogEntities);
            _context.SaveChanges();
        }

        public TimeLog Get(int timeLogId)
        {
            var timeLog = _context.TimeLogs.AsNoTracking().FirstOrDefault(x => x.Id == timeLogId);
            return _mapper.Map<TimeLog>(timeLog);
        }

        public TimeLog[] GetTimeLogs(string lastName)
        {
            var timeLogsEntity = _context.TimeLogs.AsNoTracking().Where(x => x.LastName == lastName).ToArray();
            var timeLogs = _mapper.Map<TimeLog[]>(timeLogsEntity);
            return timeLogs;
        }
    }
}
