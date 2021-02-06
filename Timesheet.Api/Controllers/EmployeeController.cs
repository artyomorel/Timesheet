using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Api.Models;
using Timesheet.Domain;
using Timesheet.Domain.Models;
using Position = Timesheet.Api.Models.Position;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service,IMapper mapper)
        {
            _employeeService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<bool> Add(CreateEmployeeRequest employeeRequest)
        {
            if (ModelState.IsValid)
            {
                switch (employeeRequest.Position)
                {
                    case nameof(Position.Chief):
                        return Ok(_employeeService.Add(_mapper.Map<ChiefEmployee>(employeeRequest)));
                    case nameof(Position.Freelancer):
                        return Ok(_employeeService.Add(_mapper.Map<FreelancerEmployee>(employeeRequest)));
                    case nameof(Position.Staff):
                        return Ok(_employeeService.Add(_mapper.Map<StaffEmployee>(employeeRequest)));
                }
            }

            return BadRequest();

        }
    }
}