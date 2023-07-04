using Academy.BLL.Services.Contracts;
using Academy.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Academy.BLL.Mapping;
using FluentValidation;
using Academy.BLL.Dtos.Student;
using Academy.BLL.Validators.StudentDtoValidators;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace Academy.BLL
{
    public static class BussinessLogicLayerServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            //services.AddScoped<IValidator<StudentCreateDto>, StudentCreateDtoValidation>();
            //services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<StudentCreateDtoValidation>());
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IGroupService, GroupManager>();
            services.AddScoped<ITeacherService, TeacherManager>();
            services.AddScoped<ITeacherGroupService, TeacherGroupManager>();

            return services;
        }
    }
}
