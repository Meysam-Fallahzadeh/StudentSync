using Microsoft.Extensions.DependencyInjection;
using StudentSync.Contracts.Students;
using StudentSync.Data.Ef.Students;

namespace StudentSync.Data.Ef
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFRepository(this IServiceCollection service)
        {
            service.AddScoped<IStudentRepository, StudentRepository>();

            return service;
        }
    }
}
