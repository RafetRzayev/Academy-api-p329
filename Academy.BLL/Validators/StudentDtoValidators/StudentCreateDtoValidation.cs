using Academy.BLL.Dtos.Student;
using FluentValidation;

namespace Academy.BLL.Validators.StudentDtoValidators
{
    public class StudentCreateDtoValidation : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.Age).GreaterThanOrEqualTo(16).WithMessage("Yas 16-dan kicik ola bilmez").LessThanOrEqualTo(60).WithMessage("Yas 60dan kicik olmalidir");
        }
    }
}
