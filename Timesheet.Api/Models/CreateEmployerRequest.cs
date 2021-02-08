using FluentValidation;
using Timesheet.Domain.Models;

namespace Timesheet.Api.Models
{
    public class CreateEmployerRequest
    {
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Position Position { get; set; }
        public decimal? Bonus { get; set; }
    }
    public class EmployerRequestFluentValidator: AbstractValidator<CreateEmployerRequest>
    {
        public EmployerRequestFluentValidator()
        {
            RuleFor(x => x.LastName).NotEmpty().NotNull();
            RuleFor(x => x.Bonus).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Salary).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
