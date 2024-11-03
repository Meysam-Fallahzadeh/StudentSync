using Microsoft.Extensions.DependencyInjection;
using StudentSync.Application.Students;

namespace StudentSync.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicatoinServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentApplicationService, StudentApplicatonService>();

        return services;    
    }
}
