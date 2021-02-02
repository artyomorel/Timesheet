using System.Linq;
using AutoMapper;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.DataAccess.MSSQL.Repositories
{
    public class TimesheetRepository: ITimesheetRepository
    {
        private readonly TimesheetContext _context;
        private readonly IMapper _mapper;

        public TimesheetRepository(TimesheetContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public TimeLog[] GetTimeLogs(string lastName)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.LastName == lastName);
            
            var timeLogs = _context.TimeLogs.Where(x => x.EmployeeId == employee.Id);
            
            var newTimeLogs = timeLogs.Select(x => _mapper.Map<TimeLog>(x)).ToArray();
            
            return newTimeLogs;
        }

        public void Add(TimeLog timeLog)
        {
            var newTimeLog = _mapper.Map<Entities.TimeLog>(timeLog);
            
            // ReSharper disable once PossibleNullReferenceException
            var employerId = _context.Employees.FirstOrDefault(x => x.LastName == timeLog.LastName).Id;
            newTimeLog.EmployeeId = employerId;
            
            _context.TimeLogs.Add(newTimeLog);
            _context.SaveChanges();
        }
    }
}