using Academy.BLL.Services.Contracts;
using Academy.BLL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Academy.BLL
{
    public static class BussinessLogicLayerServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IGroupService, GroupManager>();
            services.AddScoped<ITeacherService, TeacherManager>();
            services.AddScoped<ITeacherGroupService, TeacherGroupManager>();

            return services;
        }
    }
}
