using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Api.Models;
using Timesheet.BussinessLogic.Exceptions;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly IMapper _mapper;
        public TimesheetController(ITimeSheetService timeSheetService, IMapper mapper)
        {
            _timeSheetService = timeSheetService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<bool> TrackTime(CreateTimeLogRequest request)
        {
            try
            {
                var lastName = (string)HttpContext.Items["LastName"];
                var timeLog = _mapper.Map<TimeLog>(request);
                var result = _timeSheetService.TrackTime(timeLog, lastName);
                return Ok(result);
                
            }
            catch(TooManyHoursException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
