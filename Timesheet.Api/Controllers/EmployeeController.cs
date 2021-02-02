using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Api.Models;
using Timesheet.Domain;
using Timesheet.Domain.Models;

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
                switch (employeeRequest.Position.ToLower())
                {
                    case "chief":
                        return Ok(_employeeService.Add(_mapper.Map<ChiefEmployee>(employeeRequest)));
                    case "freelancer":
                        return Ok(_employeeService.Add(_mapper.Map<FreelancerEmployee>(employeeRequest)));
                    case "staff":
                        return Ok(_employeeService.Add(_mapper.Map<StaffEmployee>(employeeRequest)));
                }
            }

            return BadRequest();

        }
    }
}