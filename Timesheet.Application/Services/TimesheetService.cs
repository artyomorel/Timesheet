using System;
using Timesheet.BussinessLogic.Exceptions;
using Timesheet.Domain;
using Timesheet.Domain.Models;
using static Timesheet.BussinessLogic.Services.AuthService;

namespace Timesheet.BussinessLogic.Services
{
    public class TimesheetService : ITimeSheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository, IEmployeeRepository employeeRepository)
        {
            _timesheetRepository = timesheetRepository;
            _employeeRepository = employeeRepository;
        }

        public bool TrackTime(TimeLog timeLog, string lastName)
        {
            var employee = _employeeRepository.Get(lastName);
            
            bool isValid = employee?.CheckInputLog(timeLog) ?? false;

            if (!isValid)
            {
                return false;
            }
            if (IsTooManyHours(timeLog))
            {
                throw new TooManyHoursException($"Too many Hours for {timeLog.Date}");
            }
            _timesheetRepository.Add(timeLog);
            return true;
        }

        private bool IsTooManyHours(TimeLog timeLog)
        {
            var totalHour = _timesheetRepository.GetTotalHourForDate(timeLog.LastName,timeLog.Date) + timeLog.WorkingHours;
            return totalHour > 24;
        }
    }
}
