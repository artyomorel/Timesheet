using FluentValidation;

namespace Timesheet.Api.Models
{
    public class CreateEmployeeRequest
    {
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal? Bonus { get; set; }
        public string Position { get; set; }
    }

    public class EmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Salary).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(x => x.Bonus).GreaterThanOrEqualTo(0).NotEmpty().NotNull();
            RuleFor(x => x.Position).IsEnumName(typeof(Position)).WithMessage(x=> $"Not found position {x.Position}");

        }
    }
    
    public enum Position
    {
        Chief,
        Staff,
        Freelancer
    }
}