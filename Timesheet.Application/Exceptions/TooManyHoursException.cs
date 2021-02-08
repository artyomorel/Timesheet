using System;

namespace Timesheet.BussinessLogic.Exceptions
{
    public class TooManyHoursException: Exception
    {
        public TooManyHoursException(string message): base(message) 
        {
        }
    }
}