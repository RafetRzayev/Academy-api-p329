using Academy.DAL.Repositories.Contracts;
using Academy.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Academy.DAL.Repositories.Student;

namespace Academy.DAL
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepositoryAsync<>), typeof(EfCoreRepositoryAsync<>));
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
