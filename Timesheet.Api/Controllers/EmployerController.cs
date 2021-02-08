using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Api.Models;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController: ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployerController(IEmployeeService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<bool> Add(CreateEmployerRequest employerRequest)
        {
            switch (employerRequest.Position)
            {
                case Position.Chef:
                    return _service.Add(_mapper.Map<ChiefEmployee>(employerRequest));
                case Position.Staff:
                    return _service.Add(_mapper.Map<StaffEmployee>(employerRequest));
                case Position.Freelancer:
                    return _service.Add(_mapper.Map<FreelancerEmployee>(employerRequest));
                default:
                    return BadRequest();
            }
        }
    }
}