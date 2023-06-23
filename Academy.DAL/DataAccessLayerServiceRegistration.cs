using Microsoft.Extensions.DependencyInjection;
using Academy.DAL.Repositories.Contracts;
using Academy.DAL.Repositories;

namespace Academy.DAL
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepositoryAsync<>), typeof(EfCoreRepositoryAsync<>));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherGroupRepository, TeacherGroupsRepository>();

            return services;
        }
    }
}
