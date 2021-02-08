using AutoMapper;
using Timesheet.Api.Models;
using Timesheet.Domain.Models;

namespace Timesheet.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateTimeLogRequest, TimeLog>();
            CreateMap<EmployeeReport, GetEmployeeReportResponse>();
            CreateMap<TimeLog, TimeLogDto>();
            CreateMap<Issue, IssueDto>();

            CreateMap<CreateEmployerRequest, Employee>();
            CreateMap<CreateEmployerRequest, ChiefEmployee>().IncludeBase<CreateEmployerRequest, Employee>();
            CreateMap<CreateEmployerRequest, StaffEmployee>().IncludeBase<CreateEmployerRequest, Employee>();
            CreateMap<CreateEmployerRequest, FreelancerEmployee>().IncludeBase<CreateEmployerRequest, Employee>();
        }
    }
}
