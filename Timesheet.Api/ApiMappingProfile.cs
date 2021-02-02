using AutoMapper;
using Timesheet.Api.Models;
using Timesheet.Domain.Models;

namespace Timesheet.Api
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateTimeLogRequest, TimeLog>();
            
            
            CreateMap<CreateEmployeeRequest,Employee>().ReverseMap();
            
            CreateMap<CreateEmployeeRequest, ChiefEmployee>()
                .IncludeBase<CreateEmployeeRequest,Employee>();
            
            CreateMap<CreateEmployeeRequest, FreelancerEmployee>()
                .IncludeBase<CreateEmployeeRequest,Employee>();
            
            CreateMap<CreateEmployeeRequest, StaffEmployee>()
                .IncludeBase<CreateEmployeeRequest,Employee>();
           
        }
    }
}